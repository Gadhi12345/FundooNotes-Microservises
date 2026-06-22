using CollaboratorService.Application.Interfaces;
using CollaboratorService.Domain.Entities;
using CollaboratorService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Infrastructure.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly CollaboratorDbContext _context;

        public CollaboratorRepository(CollaboratorDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCollaborator(Collaborator collaborator)
        {
            await _context.Collaborators.AddAsync(collaborator);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Collaborator>> GetCollaborators(long noteId)
        {
            return await _context.Collaborators
                .Where(x => x.NoteId == noteId)
                .ToListAsync();
        }

        public async Task<bool> RemoveCollaborator(long noteId, long collaboratorUserId)
        {
            var collaborator = await _context.Collaborators
                .FirstOrDefaultAsync(x =>
                    x.NoteId == noteId &&
                    x.CollaboratorUserId == collaboratorUserId);

            if (collaborator == null)
                return false;

            _context.Collaborators.Remove(collaborator);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Collaborator>> GetSharedNotes(long collaboratorUserId)
        {
            return await _context.Collaborators
                .Where(x => x.CollaboratorUserId == collaboratorUserId)
                .ToListAsync();
        }
    }
}
