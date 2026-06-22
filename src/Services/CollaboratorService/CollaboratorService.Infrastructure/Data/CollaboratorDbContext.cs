using Microsoft.EntityFrameworkCore;
using CollaboratorService.Domain.Entities;

namespace CollaboratorService.Infrastructure.Data
{
    public class CollaboratorDbContext : DbContext
    {
        public CollaboratorDbContext(
            DbContextOptions<CollaboratorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Collaborator> Collaborators { get; set; }
    }
}