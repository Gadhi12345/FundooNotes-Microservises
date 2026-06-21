using System;
using System.Collections.Generic;
using System.Text;
using NotesService.Domain.Entitites;

namespace NotesService.Application.Interfaces
{
    public interface INoteRepository
    {
        Task<bool> CreateNote(Note note);
        Task<List<Note>> GetNotesByUserId(long userId);
        Task<Note?> GetNoteById(long noteId, long userId);
        Task<bool> UpdateNote(long noteId,long userId,string title,string description);
        Task<bool> MoveToTrash(long noteId, long userId);
        Task<List<Note>> GetTrashedNotes(long userId);
    }
}
