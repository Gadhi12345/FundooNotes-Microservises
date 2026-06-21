using System;
using System.Collections.Generic;
using System.Text;
using NotesService.Domain.Entitites;

namespace NotesService.Application.Interfaces
{
    public interface INoteRepository
    {
        Task<bool> CreateNote(Note note);
    }
}
