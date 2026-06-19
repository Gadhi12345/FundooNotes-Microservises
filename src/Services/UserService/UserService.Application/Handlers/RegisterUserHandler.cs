using MediatR;
using UserService.Application.Commands;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                MobileNumber = request.MobileNumber
            };

            return await _userRepository.RegisterUser(user);
        }
    }
}