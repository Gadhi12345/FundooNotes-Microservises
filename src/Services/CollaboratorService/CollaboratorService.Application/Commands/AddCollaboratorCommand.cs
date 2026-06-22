using CollaboratorService.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.Commands
{
    public record AddCollaboratorCommand(
       long OwnerUserId,
       AddCollaboratorRequest Request
   ) : IRequest<bool>;
}
