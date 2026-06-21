using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;

namespace NotesService.Application.Handlers
{
    public class MoveToTrashHandler : IRequestHandler<MoveToTrashCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public MoveToTrashHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Handle(
            MoveToTrashCommand request,
            CancellationToken cancellationToken)
        {
            return await _noteRepository.MoveToTrash(
                request.NoteId,
                request.UserId);
        }
    }
}