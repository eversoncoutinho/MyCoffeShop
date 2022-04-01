using Malabarista.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Application.DTOs
{
    public class TasteChooseDTO
    {
        public TasteChooseDTO() { }
        public TasteChooseDTO(GrainNotes grainNotes, string pronouncedNote)
        {
            
            GrainNotes = grainNotes;
            PronouncedNote = pronouncedNote;
        }
        public GrainNotes GrainNotes { get; set; }
        public string PronouncedNote { get; set; }
    }
}
