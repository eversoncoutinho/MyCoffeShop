using Malabarista.Application.Interfaces;
using Malabarista.Domain.Interfaces;
using System.Collections.Generic;

namespace Malabarista.Application.Services
{
    public class TasteService : ITasteService
    {
        private readonly IUnitOfWork _uof;

        public TasteService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public List<string> GetTastes( )
        {
            return _uof.TasteRepository.GetTastes();
        }
    }
}
