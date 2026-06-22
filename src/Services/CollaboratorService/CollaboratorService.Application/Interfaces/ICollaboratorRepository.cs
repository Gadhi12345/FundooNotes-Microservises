using CollaboratorService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<bool> AddCollaborator(Collaborator collaborator);

        Task<List<Collaborator>> GetCollaborators(long noteId);

        Task<bool> RemoveCollaborator(long noteId, long collaboratorUserId);

        Task<List<Collaborator>> GetSharedNotes(long collaboratorUserId);
    }
}
