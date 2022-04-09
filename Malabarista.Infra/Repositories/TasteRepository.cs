using Malabarista.Domain.Entities;
using Malabarista.Domain.Interfaces;
using Malabarista.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Malabarista.Infra.Repositories
{
    public class TasteRepository:Repository<Taste>, ITasteRepository
    {
        
        private MalabaristaDbContext _context;

        public TasteRepository(MalabaristaDbContext contexto) : base(contexto)
        {
            _context = contexto;
        }
        public List<string> GetTastes( )
        {
            var pron = _context.Tastes.Select(n => n.GrainNotes.PronouncedNote);
            var prim = _context.Tastes.Select(n => n.GrainNotes.PrimaryNote);
            var seco = _context.Tastes.Select(n => n.GrainNotes.SecondaryNote);
            var terc = _context.Tastes.Select(n => n.GrainNotes.TerciaryNote);

            var result = pron.Union(prim).Union(seco).Union(terc).ToList();
            return result;
                }
    }
}
