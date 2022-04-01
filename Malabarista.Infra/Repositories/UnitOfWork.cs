using Malabarista.Domain.Interfaces;
using Malabarista.Infra.Data;

namespace Malabarista.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        UnitOfWork() { }

        //Coloque aqui os repositórios
        private GrainRepository _grainRepo;
        private TasteRepository _tasteRepo;

        public MalabaristaDbContext _context;

        public UnitOfWork(MalabaristaDbContext contexto)
        {
            _context = contexto;
        }
        
        public IGrainRepository GrainRepository 
        {
            get
            {
              return _grainRepo = _grainRepo ?? new GrainRepository(_context);
            }
        }

        public ITasteRepository TasteRepository
        {
            get
            {
                return _tasteRepo = _tasteRepo ?? new TasteRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
