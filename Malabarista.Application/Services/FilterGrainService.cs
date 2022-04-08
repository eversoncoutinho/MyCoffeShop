using AutoMapper;
using Malabarista.Application.DTOs;
using Malabarista.Application.Interfaces;
using Malabarista.Domain.Entities;
using Malabarista.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malabarista.Application.Services
{
    public class FilterGrainService : IFilterGrainService
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public FilterGrainService(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public List<GrainByTasteDTO> GetGrainByNotes(string pTasteDTO)
        {

            var grainsLista = _uof.GrainRepository.GetGrainsTaste().ToList();

            var grainsSugestDTO = _mapper.Map<List<GrainTasteDTO>>(grainsLista);


            var grainsG = grainsSugestDTO.Where(n =>
                 n.Taste.GrainNotes.PronouncedNote == pTasteDTO
                ||n.Taste.GrainNotes.PrimaryNote == pTasteDTO
                || n.Taste.GrainNotes.SecondaryNote == pTasteDTO
                || n.Taste.GrainNotes.TerciaryNote == pTasteDTO
                )
               .OrderByDescending(n => n.Taste.GrainNotes.PronouncedNote == pTasteDTO)
            .ThenByDescending(n => n.Taste.GrainNotes.PrimaryNote == pTasteDTO)
            .ThenByDescending(n => n.Taste.GrainNotes.SecondaryNote == pTasteDTO)
            .ThenByDescending(n => n.Taste.GrainNotes.TerciaryNote == pTasteDTO)
            .ToList()
                .GroupBy(g => g.Name)
                .Select(group => new GrainByTasteDTO
                {
                    Name = group.Key,
                    GrainTasteDTO = group.ToList()
            
                })
               
                .Distinct()
                .ToList();
            

            return grainsG;
        }

        public GrainDTO GetGrainsTasteById(int id)
        {
           var selecao = _uof.GrainRepository.GetGrainsTasteById(id);
           var resultadoDto = _mapper.Map<GrainDTO>(selecao);
            return  resultadoDto;
        }
    }
}
