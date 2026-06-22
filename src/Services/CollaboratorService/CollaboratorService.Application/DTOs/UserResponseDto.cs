using System;
using System.Collections.Generic;
using System.Text;

namespace CollaboratorService.Application.DTOs
{
    public class UserResponseDto
    {
        public long UserId { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}
