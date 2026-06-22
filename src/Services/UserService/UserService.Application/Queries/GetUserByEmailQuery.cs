using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Domain.Entities;

namespace UserService.Application.Queries
{
    public record GetUserByEmailQuery(string Email)
        : IRequest<User?>;
}
