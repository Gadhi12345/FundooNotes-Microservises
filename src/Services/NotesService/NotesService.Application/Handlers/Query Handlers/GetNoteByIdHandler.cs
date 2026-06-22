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

        public GetNoteByIdHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Note?> Handle(
            GetNoteByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository
                .GetNoteById(request.NoteId, request.UserId);
        }
    }
}