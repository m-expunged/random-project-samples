using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace IdentityTemplate.Services.Smtp
{
    public class SmtpSender(IOptions<SmtpOptions> smtpOptionsAccessor) : IEmailSender
    {
        private readonly SmtpOptions _smtpOptions = smtpOptionsAccessor.Value;

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
            }

            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentException($"'{nameof(subject)}' cannot be null or empty.", nameof(subject));
            }

            if (string.IsNullOrEmpty(htmlMessage))
            {
                throw new ArgumentException($"'{nameof(htmlMessage)}' cannot be null or empty.", nameof(htmlMessage));
            }

            await Execute(email, subject, htmlMessage);
        }

        private async Task Execute(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage();
            message.To.Add(email);
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;
            message.From = new MailAddress(_smtpOptions.Address);

            using var smtp = new SmtpClient(_smtpOptions.Host, _smtpOptions.Port);
            smtp.EnableSsl = _smtpOptions.EnableSsl;
            smtp.Credentials = new NetworkCredential(_smtpOptions.Username, _smtpOptions.Password);

            await smtp.SendMailAsync(message);
        }
    }
}