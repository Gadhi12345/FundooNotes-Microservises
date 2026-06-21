using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.Application.DTOs
{
    public class UpdateNoteRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}