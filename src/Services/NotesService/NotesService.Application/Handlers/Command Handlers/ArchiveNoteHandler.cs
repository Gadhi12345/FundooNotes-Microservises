using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers.CommandHandlers
{
    public class ArchiveNoteHandler : IRequestHandler<ArchiveNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public ArchiveNoteHandler(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle(
            ArchiveNoteCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _noteRepository.ArchiveNote(request.NoteId, request.UserId);

            await _cacheService.RemoveAsync($"notes:{request.UserId}");

            return result;
        }
    }
}