using Malabarista.Domain.Entities;
using Malabarista.Domain.Interfaces;
using Malabarista.Infra.Data;

namespace Malabarista.Infra.Repositories
{
    public class TasteRepository:Repository<Taste>, ITasteRepository
    {
        public TasteRepository(MalabaristaDbContext contexto) : base(contexto)
        {
            
        }
    }
}
