using MediatR;
using NotesService.Application.Commands;
using NotesService.Application.Interfaces;
using NotesService.Domain.Entitites;

namespace NotesService.Application.Handlers.CommandHandlers
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, bool>
    {
        private readonly INoteRepository _noteRepository;

        public CreateNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<bool> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = new Note
            {
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId
            };

            return await _noteRepository.CreateNote(note);
        }
    }
}