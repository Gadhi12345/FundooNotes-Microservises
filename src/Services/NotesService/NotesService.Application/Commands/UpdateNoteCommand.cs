using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands
{
    public record UpdateNoteCommand(
       long NoteId,
       long UserId,
       string Title,
       string Description
   ) : IRequest<bool>;
}
