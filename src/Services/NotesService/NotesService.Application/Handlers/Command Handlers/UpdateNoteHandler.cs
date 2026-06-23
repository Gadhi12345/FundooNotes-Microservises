using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers.CommandHandlers
{
    public class UpdateNoteHandler : IRequestHandler<UpdateNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public UpdateNoteHandler(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var result = await _noteRepository.UpdateNote(request.NoteId,request.UserId,request.Title,request.Description);
            await _cacheService.RemoveAsync($"notes:{request.UserId}");

            return result;
        }
    }
}