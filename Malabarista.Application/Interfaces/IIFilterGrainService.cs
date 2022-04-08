using Malabarista.Application.DTOs;
using Malabarista.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Application.Interfaces
{
    public interface IFilterGrainService
    {

        ///<summary>Recebe a entidade Taste e retorna uma lista de Graos</summary>
        List<GrainByTasteDTO> GetGrainByNotes(string pTasteDTO);

        GrainDTO GetGrainsTasteById(int id);
    }
}
