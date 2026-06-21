using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands { 
 public record MoveToTrashCommand(
        long NoteId,
        long UserId
    ) : IRequest<bool>;
}
