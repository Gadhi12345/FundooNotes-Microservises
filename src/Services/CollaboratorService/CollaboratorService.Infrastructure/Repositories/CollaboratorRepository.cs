using CollaboratorService.Application.DTOs;
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


      

        public async Task<List<Collaborator>> GetSharedNotes(string collaboratorEmail)
        {
            return await _context.Collaborators.Where(x => x.CollaboratorEmail == collaboratorEmail)
                .ToListAsync();

        }

        public async Task<bool> RemoveCollaborator(long noteId, string collaboratorEmail)
        {
            var collaborator = await _context.Collaborators.FirstOrDefaultAsync(c =>
           c.NoteId == noteId &&
           c.CollaboratorEmail == collaboratorEmail);

            if (collaborator == null)
                return false;

            _context.Collaborators.Remove(collaborator);

            await _context.SaveChangesAsync();

            return true;
        }

    

        public async Task<List<CollaboratorResponseDto>> GetCollaboratorsByNoteId(long noteId)
        {
            return await _context.Collaborators
         .Where(c => c.NoteId == noteId)
         .Select(c => new CollaboratorResponseDto
         {
             CollaboratorId = c.Id,
             UserId = c.OwnerUserId,
             Email = c.CollaboratorEmail,
             Permission = c.Permission
         })
         .ToListAsync();
        }
    }
}
