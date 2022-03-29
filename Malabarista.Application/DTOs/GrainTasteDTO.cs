

using Malabarista.Domain.Entities;
using Malabarista.Domain.Enum;
using Malabarista.Domain.ValueObjects;

namespace Malabarista.Application.DTOs
{
    public class GrainTasteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GrainChar GrainChar { get; set; }
        public EProcess Process { get; set; }
        public ERoasterProfile RoasterProfile { get; set; }
        public string Roaster { get; set; }
        public string Producer { get; set; }
        public decimal Weight { get; set; }
        public Taste Taste { get; set; }
        //public DateTime DataCadastro { get; set; } = DateTime.Now;

    }
}
