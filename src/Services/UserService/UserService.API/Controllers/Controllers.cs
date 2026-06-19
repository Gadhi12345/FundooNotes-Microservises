using MediatR;
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
                return BadRequest("Registration Failed");
            }

            return Ok("User Registered Successfully");
        }
    }
}