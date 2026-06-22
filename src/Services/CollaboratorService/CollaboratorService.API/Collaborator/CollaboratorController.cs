using CollaboratorService.Application.Commands;
using CollaboratorService.Application.DTOs;
using CollaboratorService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        long ownerUserId = 1;

        var result = await _mediator.Send(
            new AddCollaboratorCommand(
                ownerUserId,
                request));

        if (!result)
            return BadRequest();

        return Ok("Collaborator added successfully");
    }

    [HttpGet("{noteId}")]
    public async Task<IActionResult> GetCollaboratorsByNoteId(
    long noteId)
    {
        var result = await _mediator.Send(
            new GetCollaboratorsByNoteIdQuery(noteId));

        return Ok(result);
    }

    [HttpGet("shared-notes/{collaboratorEmail}")]
    public async Task<IActionResult> GetSharedNotes(string collaboratorEmail)
    {
        var result = await _mediator.Send(
            new GetSharedNotesQuery(collaboratorEmail));

        return Ok(result);
    }
}