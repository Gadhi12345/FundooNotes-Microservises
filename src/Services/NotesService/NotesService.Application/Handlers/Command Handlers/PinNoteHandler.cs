using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers.CommandHandlers
{
    public class PinNoteHandler : IRequestHandler<PinNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;
        public PinNoteHandler(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle(
            PinNoteCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _noteRepository.PinNote(
         request.NoteId,
         request.UserId);

            await _cacheService.RemoveAsync($"notes:{request.UserId}");

            return result;
        }
    }
}