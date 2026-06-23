using CollaboratorService.Application.Commands;
using CollaboratorService.Application.Interfaces;
using MediatR;

public class RemoveCollaboratorHandler
    : IRequestHandler<RemoveCollaboratorCommand, bool>
{
    private readonly ICollaboratorRepository _repository;

    public RemoveCollaboratorHandler(
        ICollaboratorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        RemoveCollaboratorCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.RemoveCollaborator(
            request.NoteId,
            request.CollaboratorEmail);
    }
}