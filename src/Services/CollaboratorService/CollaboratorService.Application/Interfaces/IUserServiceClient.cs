using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.Interfaces
{
    public interface IUserServiceClient
    {
        Task<long?> GetUserIdByEmail(string email);
    }
}
