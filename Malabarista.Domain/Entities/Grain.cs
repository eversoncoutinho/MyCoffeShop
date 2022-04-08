using Malabarista.Domain.Enum;
using Malabarista.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Malabarista.Domain.Entities
{
    //Existe uma relação entre Grain e Teste localizada em MalabaristaDbContext
    public class Grain:Entity
    {
        
        public Grain() {
            
            
        }
        public Grain(string pName,
                     GrainChar pGrainChar,
                     EProcess pProcess,
                     ERoasterProfile pRoasterProfile,
                     string pProducer,
                    string pRoaster,
                    decimal pweight,
                    Taste ptaste)
        {
            if (pGrainChar == null || pName == "")
            {
                throw new SystemException("Empty field");
            }

            Name = pName;
            GrainChar = pGrainChar;
            Process = pProcess; //natural, wash, honey, fermentated
            Roaster = pRoaster;
            RoasterProfile = pRoasterProfile; //espresso, filter, Omni Roast
            Producer = pProducer;
            DataCadastro = DateTime.Now;
            Weight = pweight;
            Taste = ptaste;
        }

        public string Name { get; private set; } 
        public GrainChar GrainChar { get; private set; } 
        public EProcess Process { get; private set; }
        public ERoasterProfile RoasterProfile { get; private set; }
        public string Roaster { get; private set; } //OBjs
        public string Producer { get; private set; } //OV
        public decimal Weight { get; set; }
        public DateTime DataCadastro { get; private set; } 

        public Taste Taste { get; private set; } //varios representante pode ter varios produtos
    }
}
