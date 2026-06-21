using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers
{
    public class UpdateNoteHandler :
        IRequestHandler<UpdateNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public UpdateNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Handle(
            UpdateNoteCommand request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository.UpdateNote(
                request.NoteId,
                request.UserId,
                request.Title,
                request.Description);
        }
    }
}