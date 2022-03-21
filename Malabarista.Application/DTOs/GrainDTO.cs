using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Application.DTOs
{
    public class GrainDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } //O objeto somente é modificado via construtor
        public string Notes { get; set; } //Colocar como objeto de valor
        public string Variety { get; set; }
        public int Altitude { get; set; }
        public string Process { get; set; } //natural, wash, honey, fermentated
        public string Origin { get; set; }
        public string Description { get; set; }
        public string RoasterProfile { get; set; } //espresso, filter, Omni Roast
        public string Roaster { get; set; }
        public string Producer { get; set; }
        public decimal Weight { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;

    }
}
