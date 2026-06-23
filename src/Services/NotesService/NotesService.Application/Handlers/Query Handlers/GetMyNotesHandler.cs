using MediatR;
using NotesService.Application.Interfaces;
using NotesService.Application.Queries;
using StackExchange.Redis;
using NotesService.Domain.Entitites;

namespace NotesService.Application.Handlers.QueryHandlers
{
    public class GetMyNotesHandler
        : IRequestHandler<GetMyNotesQuery, List<Note>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;
        
        public GetMyNotesHandler(INoteRepository noteRepository,ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
      
        }

        public async Task<List<Note>> Handle(
            GetMyNotesQuery request,
            CancellationToken cancellationToken)
        {

            var cacheKey = $"notes:{request.UserId}";

            var cachedNotes =
                await _cacheService.GetAsync<List<Note>>(cacheKey);

            if (cachedNotes != null)
            {
                return cachedNotes;
            }

            var notes =
                await _noteRepository.GetNotesByUserId(request.UserId);

            await _cacheService.SetAsync(
                cacheKey,
                notes,
                TimeSpan.FromMinutes(10));

            return notes;
        }
    }
}