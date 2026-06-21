using MediatR;

namespace NotesService.Application.Commands
{
    public record CreateNoteCommand(
        string Title,
        string Description,
         long UserId
    ) : IRequest<bool>;
}
