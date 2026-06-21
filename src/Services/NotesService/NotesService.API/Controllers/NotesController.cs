using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotesService.Application.Commands;
using NotesService.Application.DTOs;
using NotesService.Application.Queries;

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

        [HttpGet]
        public async Task<IActionResult> GetMyNotes()
        {
            var userId =
                Convert.ToInt64(User.FindFirst("UserId")?.Value);

            var query = new GetMyNotesQuery(userId);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(long id)
        {
            var userId =
                Convert.ToInt64(
                    User.FindFirst("UserId")?.Value);

            var query =
                new GetNoteByIdQuery(id, userId);

            var note =
                await _mediator.Send(query);

            if (note == null)
                return NotFound("Note not found");

            return Ok(note);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(
    long id,
    UpdateNoteRequest request)
        {
            var userId =
                Convert.ToInt64(
                    User.FindFirst("UserId")?.Value);

            var command = new UpdateNoteCommand(
                id,
                userId,
                request.Title,
                request.Description);

            var result =
                await _mediator.Send(command);

            if (!result)
                return NotFound("Note not found");

            return Ok("Note Updated Successfully");
        }

        [HttpPut("trash/{noteId}")]
        public async Task<IActionResult> MoveToTrash(long noteId)
        {
            var userId = Convert.ToInt64(
                User.FindFirst("UserId")?.Value);

            var command = new MoveToTrashCommand(
                noteId,
                userId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}