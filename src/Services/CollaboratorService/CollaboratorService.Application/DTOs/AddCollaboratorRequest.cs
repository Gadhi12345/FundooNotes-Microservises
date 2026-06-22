using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.DTOs
{
    public class AddCollaboratorRequest
    {
        public long NoteId { get; set; }

        public string CollaboratorEmail { get; set; } = string.Empty;

        public string Permission { get; set; } = "VIEW";
    }
}
