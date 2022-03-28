using Malabarista.Domain.Entities;
using Malabarista.Domain.Interfaces;
using Malabarista.Infra.Data;
using System.Linq;

namespace Malabarista.Infra.Repositories
{
    public class GrainRepository:Repository<Grain>,IGrainRepository
    {
        public GrainRepository(MalabaristaDbContext contexto) : base(contexto)
        {
            
        }

       
    }
}
