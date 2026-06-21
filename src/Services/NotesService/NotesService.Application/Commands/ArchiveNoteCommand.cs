using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Commands
{
    public record ArchiveNoteCommand(
        long NoteId,
        long UserId
    ) : IRequest<bool>;
}
