using MediatR;
using NotesService.Application.Interfaces;
using NotesService.Application.Queries;
using NotesService.Domain.Entitites;

namespace NotesService.Application.Handlers.QueryHandlers
{
    public class GetTrashedNotesHandler
        : IRequestHandler<GetTrashedNotesQuery, List<Note>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public GetTrashedNotesHandler(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<List<Note>> Handle(
            GetTrashedNotesQuery request,
            CancellationToken cancellationToken)
        {
            var cacheKey = $"trashednotes:{request.UserId}";

            var cachedNotes =
                await _cacheService.GetAsync<List<Note>>(cacheKey);

            if (cachedNotes != null)
            {
                return cachedNotes;
            }

            var notes =
                await _noteRepository.GetTrashedNotes(request.UserId);

            await _cacheService.SetAsync(
                cacheKey,
                notes,
                TimeSpan.FromMinutes(10));

            return notes;
        }
    }
}