using CollaboratorService.Application.Commands;
using CollaboratorService.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CollaboratorService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CollaboratorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCollaborator(
            AddCollaboratorRequest request)
        {
            long ownerUserId = Convert.ToInt64(
                User.FindFirstValue("UserId"));

            var result = await _mediator.Send(
                new AddCollaboratorCommand(
                    ownerUserId,
                    request));

            if (!result)
                return BadRequest();

            return Ok("Collaborator added successfully");
        }
    }
}