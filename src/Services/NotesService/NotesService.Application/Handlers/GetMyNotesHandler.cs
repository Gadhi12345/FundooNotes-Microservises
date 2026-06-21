using MediatR;
using NotesService.Application.Interfaces;
using NotesService.Application.Queries;
using NotesService.Domain.Entitites;
namespace NotesService.Application.Handlers
{
    public class GetMyNotesHandler :IRequestHandler<GetMyNotesQuery, List<Note>>
    {
        private readonly INoteRepository _noteRepository;

        public GetMyNotesHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<List<Note>> Handle(
            GetMyNotesQuery request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository
                .GetNotesByUserId(request.UserId);
        }
    }
}