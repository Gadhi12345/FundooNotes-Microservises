using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesService.Application.Commands;
using NotesService.Application.DTOs;

namespace NotesService.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(CreateNoteRequest request)
        {
            var userId = Convert.ToInt64(User.FindFirst("UserId")?.Value);

            var command = new CreateNoteCommand(
                request.Title,
                request.Description,
                userId
            );

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}