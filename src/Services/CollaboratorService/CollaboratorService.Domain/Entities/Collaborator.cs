using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Domain.Entities
{
    public class Collaborator
    {

        public long Id { get; set; }

        public long NoteId { get; set; }

        public long OwnerUserId { get; set; }

        public string CollaboratorEmail { get; set; } = string.Empty;

        public string Permission { get; set; } = "VIEW";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
      
    }
}
