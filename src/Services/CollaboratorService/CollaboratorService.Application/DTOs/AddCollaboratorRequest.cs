using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.DTOs
{
    public class AddCollaboratorRequest
    {
        public long NoteId { get; set; }

        public long CollaboratorUserId { get; set; }

        public string Permission { get; set; } = "VIEW";
    }
}
