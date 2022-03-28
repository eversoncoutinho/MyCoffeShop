using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Domain.ValueObjects
{
    //This class represents the tastes presents in the grain by the roaster
    public class GrainNotes : ValueObject<GrainNotes>
    {
        GrainNotes() { }
        public GrainNotes(string primaryNote, string secondaryNote, string terciaryNote)
        {
            PrimaryNote = primaryNote;
            SecondaryNote = secondaryNote;
            TerciaryNote = terciaryNote;
        }

        public string PrimaryNote { get; set; }
        public string SecondaryNote { get; set; }
        public string TerciaryNote { get; set; }

        protected override bool EqualsCore(GrainNotes other)
        {
            return PrimaryNote == other.PrimaryNote
                         && SecondaryNote == other.SecondaryNote
                         && TerciaryNote == other.TerciaryNote;
                  
        }

        protected override decimal GetHashCodeCore()
        {
            decimal hashCode = SecondaryNote.GetHashCode();
            return hashCode;

        }
    }
}
