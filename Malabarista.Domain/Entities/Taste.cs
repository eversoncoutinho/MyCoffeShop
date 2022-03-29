using Malabarista.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Domain.Entities

{
    public class Taste:Entity
    {
        //TO DO: Validate
        public Taste() { }
        public Taste(GrainNotes pGrainNotes, string pronouncedNote)
        {
            GrainNotes = pGrainNotes;
            PronouncedNote = pronouncedNote;
        }

        public GrainNotes GrainNotes { get; private set; }
        public string PronouncedNote { get; private set; }

        public ICollection<Grain> Grains { get; private set; }
    }
}
