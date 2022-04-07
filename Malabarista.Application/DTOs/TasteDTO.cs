using Malabarista.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Application.DTOs
{
    public class TasteDTO
    {
        public TasteDTO(int id, GrainNotes grainNotes)
        {
            Id = id;
            GrainNotes = grainNotes;
        }

        public int Id { get; set; }
        public int Year { get; set; }
        public GrainNotes GrainNotes { get; set; }
      
    }
}
