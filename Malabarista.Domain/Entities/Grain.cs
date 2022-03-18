using System;

namespace Malabarista.Domain.Entities
{
    public class Grain:Entity
    {
        
        public Grain() { } 
        public Grain(string pName,
                    string pNotes,
                    string pVariety,
                    int pAltitude,
                    string pProcess, //natural, wash, honey, fermentated
                    string pOrigin, 
                    string pDescription,
                    string pRoasterProfile, //espresso, filter, Omni Roast
                    string pProducer,
                    string pRoaster,
                    decimal pWeight
                )
        {
            if (pNotes == "" || pName == "")
            {
                throw new SystemException("Empty field");
            }            
            //Métodos
            Name = pName;
            Notes = pNotes; //Objeto
            Variety = pVariety;
            Altitude = pAltitude;
            Process = pProcess; //natural, wash, honey, fermentated
            Origin = pOrigin;
            Description = pDescription;
            Roaster = pRoaster;
            RoasterProfile = pRoasterProfile; //espresso, filter, Omni Roast
            Producer = pProducer;
            Weight = pWeight;
            DataCadastro = DateTime.Now;
        }
        
        public string Name { get; private set; } //O objeto somente é modificado via construtor
        public string Notes { get; private set; } //Colocar como objeto de valor
        public DateTime DataCadastro { get; private set; }

        public string Variety { get; private set; }

        public int Altitude { get; private set; }
        public string Process { get; private set; } //natural, wash, honey, fermentated
        public string Origin { get; private set; }
        public string Description { get; private set; }
        public string RoasterProfile { get; private set; } //espresso, filter, Omni Roast
        public string Roaster { get; private set; }
        public string Producer { get; private set; }
        public decimal Weight { get; private set; }
        //public  EFormaPagamento FormaPagamento { get; private set; }
        //public ICollection<Produto> Produtos { get; private set; } //varios representante pode ter varios produtos
    }
}
