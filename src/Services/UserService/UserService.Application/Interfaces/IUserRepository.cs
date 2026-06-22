using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.Entities;

namespace UserService.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(User user);
        Task<User?> LoginUser(string email);
        Task<User?> GetUserByEmail(string email);
    }
}
