using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Malabarista.Domain.Entities
{
    public class Buy:Entity
    {
        public Buy()
        {
            
        }
        public Buy(Grain pGrain,
                   int pQuantity,
                   decimal pShippiment,
                   int pLoteNumber,
                   DateTime pRoasteDate,
                   DateTime pBuyDate
            )
        {
            Grain = pGrain;
            Quantity = pQuantity;
            Shippiment = pShippiment;
            LoteNumber = pLoteNumber;
            RoasteDate = pRoasteDate;
            BuyDate = pBuyDate;
        }
        public Grain Grain { get; private set; }
        public int Quantity { get; private set; }
        public decimal Shippiment { get; private set; }
        public int LoteNumber { get; private set; }
        public DateTime RoasteDate { get; private set; }
        public DateTime BuyDate { get; private set; }

    }
}
