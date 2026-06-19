using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands;

namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest(new
                {
                    Message = "Email already exists"
                });
            }

            return Ok(new
            {
                Message = "User registered successfully"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var token = await _mediator.Send(command);

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Invalid Email or Password");
            }

            return Ok(token);
        }
        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            return Ok("Authorized User");
        }
    }
}