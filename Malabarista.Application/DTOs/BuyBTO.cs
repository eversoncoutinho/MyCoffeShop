using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Application.DTOs
{
    public class BuyBTO
    {
        public GrainDTO Grain { get; set; }
        public int Quantity { get; private set; }
        public decimal Shippiment { get; private set; }
        public int LoteNumber { get; private set; }
        public DateTime RoasteDate { get; private set; }
        public DateTime BuyDate { get; private set; }
    }
}
