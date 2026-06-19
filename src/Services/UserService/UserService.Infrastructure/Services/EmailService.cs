using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using UserService.Application.Interfaces;

namespace UserService.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient(_configuration["SMTP:Host"])
            {
                Port = int.Parse(_configuration["SMTP:Port"]),
                Credentials = new NetworkCredential(
                    _configuration["SMTP:Email"],
                    _configuration["SMTP:Password"]
                ),
                EnableSsl = true
            };

            var message = new MailMessage(
                _configuration["SMTP:Email"],
                toEmail,
                subject,
                body
            );

            await smtpClient.SendMailAsync(message);
        }
    }
}