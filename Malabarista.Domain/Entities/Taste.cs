using Malabarista.Domain.ValueObjects;
using System.Collections.Generic;

namespace Malabarista.Domain.Entities

{
    public class Taste:Entity
    {
        //TO DO: Validate
        public Taste() { }
        public Taste(int pYear,GrainNotes pGrainNotes)
        {
            Year = pYear;
            GrainNotes = pGrainNotes;
        }
        public int Year { get; private set; }

        public GrainNotes GrainNotes { get; private set; }

        public ICollection<Grain> Grains { get; private set; }
    }
}
