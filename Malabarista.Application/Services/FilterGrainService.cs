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



        public List<GrainByTasteDTO> GetGrainByNotes(TasteChooseDTO pTasteDTO)
        {

            var grainsLista = _uof.GrainRepository.GetGrainsAndTaste().ToList();

            var grainsSugestDTO = _mapper.Map<List<GrainTasteDTO>>(grainsLista);

            var grainsG = grainsSugestDTO.Where(n =>
                 n.Taste.PronouncedNote == pTasteDTO.PronouncedNote ||
                 n.Taste.GrainNotes.PrimaryNote == pTasteDTO.PronouncedNote ||
                 n.Taste.GrainNotes.SecondaryNote == pTasteDTO.PronouncedNote ||
                 n.Taste.GrainNotes.TerciaryNote == pTasteDTO.PronouncedNote
                )
                .GroupBy(n => n.Name)
                .Select(group => new GrainByTasteDTO
                {
                    Name = group.Key,
                    GrainTasteDTO = group.ToList()
                }).Distinct().
                ToList();


            return grainsG;
        }


    }
}
