using CollaboratorService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.Queries
{
    public record GetSharedNotesQuery(string CollaboratorEmail)
       : IRequest<List<Collaborator>>;
}
