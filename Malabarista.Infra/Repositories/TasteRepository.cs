using Malabarista.Domain.Entities;
using Malabarista.Domain.Interfaces;
using Malabarista.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Infra.Repositories
{
    public class TasteRepository:Repository<Taste>, ITasteRepository
    {
        public TasteRepository(MalabaristaDbContext contexto) : base(contexto)
        {
            
        }
    }
}
