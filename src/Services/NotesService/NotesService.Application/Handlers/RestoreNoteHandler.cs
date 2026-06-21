using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers
{
    public class RestoreNoteHandler
        : IRequestHandler<RestoreNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public RestoreNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Handle(
            RestoreNoteCommand request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository.RestoreNote(
                request.NoteId,
                request.UserId);
        }
    }
}