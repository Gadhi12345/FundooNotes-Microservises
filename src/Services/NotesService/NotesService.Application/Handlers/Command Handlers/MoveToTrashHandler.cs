using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers.CommandHandlers
{
    public class MoveToTrashHandler : IRequestHandler<MoveToTrashCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public MoveToTrashHandler(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle(
            MoveToTrashCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _noteRepository.MoveToTrash(
        request.NoteId,
        request.UserId);

            await _cacheService.RemoveAsync($"notes:{request.UserId}");

            return result;
        }
    }
}