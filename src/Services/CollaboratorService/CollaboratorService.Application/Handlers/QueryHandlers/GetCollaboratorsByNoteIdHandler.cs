using CollaboratorService.Application.DTOs;
using CollaboratorService.Application.Interfaces;
using CollaboratorService.Application.Queries;
using MediatR;

namespace CollaboratorService.Application.Handlers.QueryHandlers
{
    public class GetCollaboratorsByNoteIdHandler :IRequestHandler<GetCollaboratorsByNoteIdQuery,List<CollaboratorResponseDto>>
    {
        private readonly ICollaboratorRepository _repository;

        public GetCollaboratorsByNoteIdHandler(
            ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CollaboratorResponseDto>> Handle(
            GetCollaboratorsByNoteIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository
                .GetCollaboratorsByNoteId(request.NoteId);
        }
    }
}