using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;
using NotesService.Domain.Entitites;

namespace NotesService.Application.Handlers.CommandHandlers
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public CreateNoteHandler(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<bool> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = new Note
            {
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId
            };

            var result = await _noteRepository.CreateNote(note);

            await _cacheService.RemoveAsync($"notes:{request.UserId}");

            return result;
        }
    }
}