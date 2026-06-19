using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
