using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.Commands
{
    public class LoginUserCommand:IRequest<string>
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
