using Malabarista.Domain.Entities;
using Malabarista.Domain.Interfaces;
using Malabarista.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
        
        public IQueryable<Grain> GetGrainsTaste()
        {
            IQueryable<Grain> resultado = _context.Grains.Include(n => n.Taste);
            return resultado;
        }

        public Grain GetGrainsTasteById(int id)
        {
            var resultado = _context.Grains.Include(n => n.Taste).SingleOrDefault(n => n.Id == id);
            return resultado;
        }
    }
}
