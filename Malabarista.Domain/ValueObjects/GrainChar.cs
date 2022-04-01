using System.Collections.Generic;

namespace Malabarista.Domain.ValueObjects
{
    public class GrainChar : ValueObject<GrainChar>
    {
        //TO DO: to create 
        public GrainChar() { }
        public GrainChar( 
            string pvariety, 
            int paltitude, 
            string porigin, 
            string pdescription
            )
        {
            Variety = pvariety;
            Altitude = paltitude;
            Origin = porigin;
            Description = pdescription;
            
        }

        public string Variety { get; set; }
        public int Altitude { get; set; }
        public string Origin { get; set; }
        public string Description { get; set; }

        protected override bool EqualsCore(GrainChar other)
        {
            return Variety == other.Variety
                && Altitude == other.Altitude
                && Origin == other.Origin
                && Description == other.Description;
                
        }

        protected override decimal GetHashCodeCore()
        {
            decimal hashCode = Variety.GetHashCode();
            return hashCode;
        }
    }
}
