using Malabarista.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace Malabarista.Domain.Interfaces
{
    public interface IGrainRepository:IRepository<Grain>
    {
        /// <summary>
        /// Inclui o Taste e está marcado como AsQueryable
        /// </summary>
        IQueryable<Grain> GetGrainsTaste();


        Grain GetGrainsTasteById(int id);

    }
}
