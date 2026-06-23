using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers.CommandHandlers
{
    public class RestoreNoteHandler : IRequestHandler<RestoreNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;
        public RestoreNoteHandler(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle(
            RestoreNoteCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _noteRepository.RestoreNote(
         request.NoteId,
         request.UserId);

            await _cacheService.RemoveAsync($"notes:{request.UserId}");

            return result;
        }
    }
}