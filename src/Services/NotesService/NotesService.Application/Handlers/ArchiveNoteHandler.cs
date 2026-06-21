using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers
{
    public class ArchiveNoteHandler : IRequestHandler<ArchiveNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public ArchiveNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Handle(
            ArchiveNoteCommand request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository.ArchiveNote(
                request.NoteId,
                request.UserId);
        }
    }
}