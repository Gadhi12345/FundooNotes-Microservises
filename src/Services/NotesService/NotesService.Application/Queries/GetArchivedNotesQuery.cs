using MediatR;
using NotesService.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.Queries
{
    public record GetArchivedNotesQuery(
        long UserId
    ) : IRequest<List<Note>>;
}
