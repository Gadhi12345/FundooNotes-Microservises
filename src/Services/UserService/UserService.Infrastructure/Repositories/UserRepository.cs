using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
