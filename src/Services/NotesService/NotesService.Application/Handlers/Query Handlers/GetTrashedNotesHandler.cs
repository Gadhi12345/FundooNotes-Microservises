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

        public GetTrashedNotesHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<List<Note>> Handle(
            GetTrashedNotesQuery request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository
                .GetTrashedNotes(request.UserId);
        }
    }
}