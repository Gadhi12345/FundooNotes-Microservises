using MediatR;
using UserService.Application.Commands;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        public RegisterUserHandler(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
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

           var result = await _userRepository.RegisterUser(user);

if (result)
{
    await _emailService.SendEmailAsync(
        request.Email,
        "Welcome to User Service",
        "User Registered Successfully");
}

return result;
        }
    }
}