using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands;
using UserService.Application.Queries;

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
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
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
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
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

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _mediator.Send(
                new GetUserByEmailQuery(email));

            if (user == null)
                return NotFound("User not found");

            return Ok(new
            {
                user.UserId,
                user.Email
            });
        }
    }
}