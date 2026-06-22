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
        private readonly IUserServiceClient _userServiceClient;

        public AddCollaboratorHandler(
            ICollaboratorRepository repository,
            IUserServiceClient userServiceClient)
        {
            _repository = repository;
            _userServiceClient = userServiceClient;
        }

        public async Task<bool> Handle(
            AddCollaboratorCommand request,
            CancellationToken cancellationToken)
        {
            var user =
                await _userServiceClient.GetUserIdByEmail(
                    request.Request.CollaboratorEmail);

            if (user == null)
            {
                return false;
            }

            var collaborator = new Collaborator
            {
                NoteId = request.Request.NoteId,
                OwnerUserId = request.OwnerUserId,
                CollaboratorEmail = request.Request.CollaboratorEmail,
                Permission = request.Request.Permission
            };

            return await _repository.AddCollaborator(collaborator);
        }
    }
}