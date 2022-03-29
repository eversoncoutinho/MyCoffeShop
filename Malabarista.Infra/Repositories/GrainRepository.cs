using Malabarista.Domain.Entities;
using Malabarista.Domain.Interfaces;
using Malabarista.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Malabarista.Infra.Repositories
{
    public class GrainRepository:Repository<Grain>, IGrainRepository
    {
        private MalabaristaDbContext _context;

        public GrainRepository(MalabaristaDbContext contexto) : base(contexto)
        {
            _context = contexto;
        }

        public IQueryable<Grain> GetGrains()
        {
            IQueryable<Grain> resultado = _context.Grains.Include(n => n.Taste).AsQueryable();
            return resultado;
        }
    }
}
