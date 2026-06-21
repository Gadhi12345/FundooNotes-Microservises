using MediatR;
using NotesService.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Queries
{
    public record GetNoteByIdQuery(long NoteId,long UserId) : IRequest<Note?>;
}
