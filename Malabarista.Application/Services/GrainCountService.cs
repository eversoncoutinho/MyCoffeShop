using AutoMapper;
using Malabarista.Application.Interfaces;
using Malabarista.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Application.Services
{
    /// <summary>
    /// Retorna a quantidade de Tipos de Graos.
    /// </summary>
    public class GrainCountService : IGrainCountService
    {
        private readonly IUnitOfWork _uof;
        
        public GrainCountService(IUnitOfWork uof)
        {
            _uof = uof;
                }
        public int GrainCount( )
        {
            var list = _uof.GrainRepository.ToString();
            return list.Count();
                
                }
    }
}
