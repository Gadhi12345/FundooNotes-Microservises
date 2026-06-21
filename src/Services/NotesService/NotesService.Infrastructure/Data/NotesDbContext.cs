using Microsoft.EntityFrameworkCore;
using NotesService.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Infrastructure.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
