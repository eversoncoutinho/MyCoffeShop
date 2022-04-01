using Malabarista.Domain.ValueObjects;
using System.Collections.Generic;

namespace Malabarista.Domain.Entities

{
    public class Taste:Entity
    {
        //TO DO: Validate
        public Taste() { }
        public Taste(int pYear,GrainNotes pGrainNotes, string pronouncedNote)
        {
            Year = pYear;
            GrainNotes = pGrainNotes;
            PronouncedNote = pronouncedNote;
        }
        public int Year { get; private set; }
        public GrainNotes GrainNotes { get; private set; }
        public string PronouncedNote { get; private set; }

        public ICollection<Grain> Grains { get; private set; }
    }
}
