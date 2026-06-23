using MediatR;
using NotesService.Application.Interfaces;
using NotesService.Application.Queries;
using NotesService.Domain.Entitites;

namespace NotesService.Application.Handlers.QueryHandlers
{
    public class GetNoteByIdHandler
        : IRequestHandler<GetNoteByIdQuery, Note?>
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICacheService _cacheService;

        public GetNoteByIdHandler(INoteRepository noteRepository, ICacheService cacheService)
        {
            _noteRepository = noteRepository;
            _cacheService = cacheService;
        }

        public async Task<Note?> Handle(
            GetNoteByIdQuery request,
            CancellationToken cancellationToken)
        {
            var cacheKey =
    $"note:{request.UserId}:{request.NoteId}";

            var cachedNote =
                await _cacheService.GetAsync<Note>(cacheKey);

            if (cachedNote != null)
            {
                return cachedNote;
            }

            var note =
                await _noteRepository.GetNoteById(
                    request.NoteId,
                    request.UserId);

            await _cacheService.SetAsync(
                cacheKey,
                note,
                TimeSpan.FromMinutes(10));

            return note;
        }
    }
}