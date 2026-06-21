using Microsoft.EntityFrameworkCore;
using NotesService.Application.Interfaces;
using NotesService.Domain.Entitites;
using NotesService.Infrastructure.Data;

namespace NotesService.Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext _context;

        public NoteRepository(NotesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateNote(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Note?> GetNoteById(long noteId, long userId)
        {
            return await _context.Notes
      .FirstOrDefaultAsync(
          x => x.NoteId == noteId &&
               x.UserId == userId);
        }

        public async Task<List<Note>> GetNotesByUserId(long userId)
        {
            return await _context.Notes
         .Where(x => x.UserId == userId)
         .ToListAsync();
        }

        public async Task<bool> MoveToTrash(long noteId, long userId)
        {

            var note = await _context.Notes
                .FirstOrDefaultAsync(x => x.NoteId == noteId && x.UserId == userId);

            if (note == null)
                return false;

            note.IsTrash = true;
            note.ModifiedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateNote(long noteId, long userId, string title, string description)
        {
            var note = await _context.Notes
        .FirstOrDefaultAsync(x =>
            x.NoteId == noteId &&
            x.UserId == userId);

            if (note == null)
                return false;

            note.Title = title;
            note.Description = description;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}