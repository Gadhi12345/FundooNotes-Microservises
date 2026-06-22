using CollaboratorService.Application.Commands;
using CollaboratorService.Application.Interfaces;
using CollaboratorService.Domain.Entities;
using MediatR;

namespace CollaboratorService.Application.Handlers
{
    public class AddCollaboratorHandler
        : IRequestHandler<AddCollaboratorCommand, bool>
    {
        private readonly ICollaboratorRepository _repository;

        public AddCollaboratorHandler(ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            AddCollaboratorCommand request,
            CancellationToken cancellationToken)
        {
            var collaborator = new Collaborator
            {
                NoteId = request.Request.NoteId,
                OwnerUserId = request.OwnerUserId,
                CollaboratorUserId = request.Request.CollaboratorUserId,
                Permission = request.Request.Permission
            };

            return await _repository.AddCollaborator(collaborator);
        }
    }
}