using Malabarista.Domain.Entities;
using Malabarista.Domain.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Malabarista.Application.DTOs
{
    public class GrainDTO
    {

        public GrainDTO( ) { }
        public GrainDTO(int id,
                                string name, 
                                GrainChar grainChar, 
                                string process, 
                                string roasterProfile, 
                                string roaster, 
                                string producer, 
                                decimal weight, 
                                Taste ptaste
                                )
        {
            Id = id;
            Name = name;
            GrainChar = grainChar;
            Process = process;
            RoasterProfile = roasterProfile;
            Roaster = roaster;
            Producer = producer;
            Weight = weight;
            Taste = ptaste;
            
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public Taste Taste { get; set; }
        public GrainChar GrainChar { get; set; } //Colocar como objeto de valor
        public string Process { get; set; } //natural, wash, honey, fermentated
        public string RoasterProfile { get; set; } //espresso, filter, Omni Roast
        public string Roaster { get; set; }
        public string Producer { get; set; }
        public decimal Weight { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;

    }
}
