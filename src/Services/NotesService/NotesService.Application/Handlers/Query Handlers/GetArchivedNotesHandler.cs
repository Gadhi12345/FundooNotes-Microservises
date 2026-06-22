using MediatR;
using NotesService.Application.Interfaces;
using NotesService.Application.Queries;
using NotesService.Domain.Entitites;

namespace NotesService.Application.Handlers.QueryHandlers
{
    public class GetArchivedNotesHandler
        : IRequestHandler<GetArchivedNotesQuery, List<Note>>
    {
        private readonly INoteRepository _noteRepository;

        public GetArchivedNotesHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<List<Note>> Handle(
            GetArchivedNotesQuery request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository
                .GetArchivedNotes(request.UserId);
        }
    }
}