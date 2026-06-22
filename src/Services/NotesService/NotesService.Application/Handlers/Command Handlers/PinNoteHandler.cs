using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers.CommandHandlers
{
    public class PinNoteHandler : IRequestHandler<PinNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public PinNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Handle(
            PinNoteCommand request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository.PinNote(
                request.NoteId,
                request.UserId);
        }
    }
}