namespace IdentityTemplate.Services.Smtp
{
    public class SmtpOptions
    {
        public static readonly string Section = "Smtp";

        public required string Address { get; init; }

        public required string Username { get; set; }

        public required string Password { get; init; }

        public required string Host { get; init; }

        public int Port { get; init; }

        public bool EnableSsl { get; init; }
    }
}