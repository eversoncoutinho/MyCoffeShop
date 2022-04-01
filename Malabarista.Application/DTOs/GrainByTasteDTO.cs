using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Application.DTOs
{
    
        public class GrainByTasteDTO
        {
            public string Name { get; set; }
            public List<GrainTasteDTO> GrainTasteDTO { get; set; }
        }
    }

