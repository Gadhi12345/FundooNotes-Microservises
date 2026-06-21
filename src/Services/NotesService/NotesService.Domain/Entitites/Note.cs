using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Domain.Entitites
{
    public class Note
    {
        public long NoteId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Color { get; set; } = "White";

        public bool IsPinned { get; set; }

        public bool IsArchived { get; set; }

        public bool IsTrash { get; set; }

        public long UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    }
}
