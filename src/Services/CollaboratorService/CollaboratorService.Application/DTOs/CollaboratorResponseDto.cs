using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.DTOs
{
    public class CollaboratorResponseDto
    {
        public long CollaboratorId { get; set; }

        public long UserId { get; set; }

        public string Email { get; set; }

        public string Permission { get; set; }
    }
}
