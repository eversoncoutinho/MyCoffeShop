using Malabarista.Domain.Entities;
using Malabarista.Infra.Data;

namespace Malabarista.Infra.Repositories
{
    public class GrainRepository:Repository<Grain>,IGrainRepository
    {
        public GrainRepository(MalabaristaDbContext contexto) : base(contexto)
        {

        }

    }
}
