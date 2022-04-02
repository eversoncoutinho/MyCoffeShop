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
            string pdescription,
            string pimgUrl
            )
        {
            Variety = pvariety;
            Altitude = paltitude;
            Origin = porigin;
            Description = pdescription;
            ImgUrl = pimgUrl;
        }

        public string Variety { get; set; }
        public int Altitude { get; set; }
        public string Origin { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        protected override bool EqualsCore(GrainChar other)
        {
            return Variety == other.Variety
                && Altitude == other.Altitude
                && Origin == other.Origin
                && Description == other.Description
                && ImgUrl == other.ImgUrl;
                
        }

        protected override decimal GetHashCodeCore()
        {
            decimal hashCode = Variety.GetHashCode();
            return hashCode;
        }
    }
}
