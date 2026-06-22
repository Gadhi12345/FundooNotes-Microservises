using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.Commands
{
    public record RemoveCollaboratorCommand(
     long NoteId,
     string CollaboratorEmail)
     : IRequest<bool>;
}
