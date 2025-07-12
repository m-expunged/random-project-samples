using IdentityTemplate.Services.Smtp;

namespace IdentityTemplate
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureOptions(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection(SmtpOptions.Section));

            return builder;
        }
    }
}