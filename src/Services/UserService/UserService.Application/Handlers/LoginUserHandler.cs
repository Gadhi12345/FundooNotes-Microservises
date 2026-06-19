using BCrypt.Net;
using MediatR;
using UserService.Application.Commands;
using UserService.Application.Interfaces;
using UserService.Application.Services;

namespace UserService.Application.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        public LoginUserHandler(IUserRepository userRepository,IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService= jwtService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.LoginUser(request.Email);

            if (user == null)
            {
                return string.Empty;
            }

            bool isPasswordValid =
                BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isPasswordValid)
            {
                return string.Empty;
            }

            string token = _jwtService.GenerateToken(user.UserId,user.Email);

            return token;
        }
    }
}