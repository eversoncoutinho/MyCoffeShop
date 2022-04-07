using Malabarista.Application.DTOs;
using Malabarista.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Application.Interfaces
{
    public interface IGrainCountService
    {

        ///<summary>Conta a quantidade de Tipos de Grãos</summary>

        int GrainCount(); 
    }
}
