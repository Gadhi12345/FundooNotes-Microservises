using CollaboratorService.Application.Interfaces;
using CollaboratorService.Application.Queries;
using CollaboratorService.Domain.Entities;
using MediatR;

public class GetSharedNotesHandler
    : IRequestHandler<GetSharedNotesQuery, List<Collaborator>>
{
    private readonly ICollaboratorRepository _repository;

    public GetSharedNotesHandler(ICollaboratorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Collaborator>> Handle(
        GetSharedNotesQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetSharedNotes(
            request.CollaboratorEmail);
    }
}