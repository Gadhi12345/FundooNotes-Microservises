using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string email);
    }
}
