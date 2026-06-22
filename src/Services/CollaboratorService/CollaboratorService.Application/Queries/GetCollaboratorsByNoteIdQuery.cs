using CollaboratorService.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.Queries
{
    public record GetCollaboratorsByNoteIdQuery(long NoteId)
     : IRequest<List<CollaboratorResponseDto>>;
}
