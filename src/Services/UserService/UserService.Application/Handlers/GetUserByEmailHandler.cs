using MediatR;
using UserService.Application.Interfaces;
using UserService.Application.Queries;
using UserService.Domain.Entities;

namespace UserService.Application.Handlers
{
    public class GetUserByEmailHandler
        : IRequestHandler<GetUserByEmailQuery, User?>
    {
        private readonly IUserRepository _repository;

        public GetUserByEmailHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User?> Handle(
            GetUserByEmailQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetUserByEmail(request.Email);
        }
    }
}