using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Malabarista.Domain.Entities;
using Malabarista.Domain.Interfaces;
using AutoMapper;
using Malabarista.Application.DTOs;
using Malabarista.Domain.ValueObjects;
using Malabarista.Application.Interfaces;
//using System.Web.Http;

namespace Malabarista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrainsController : ControllerBase
    {
        private readonly IFilterGrainService ifilterGrainService;
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public GrainsController(IFilterGrainService filterGrainService, 
                                IUnitOfWork context,
                                IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
            ifilterGrainService = filterGrainService;
        }
        // GET: api/Grains/taste
        
        [HttpGet("taste")]
        public ActionResult<List<GrainByTasteDTO>> GetGrainsByTaste([FromQuery] string pronoucedNote)
        {
            return ifilterGrainService.GetGrainByNotes(pronoucedNote);
        }
        


        // GET: api/Grains
        [HttpGet]
        public ActionResult<List<GrainDTO>> GetGrains()
        {
            //
            try {
            var getGrainTaste = _uof.GrainRepository.GetGrainsTaste();
            
            if (getGrainTaste.Count()==0)
            {
                return NotFound($"Nenhum Grão cadastrado no banco de dados");
            }
                var grainDTOList = _mapper.Map<List<GrainDTO>>(getGrainTaste);
                return grainDTOList;
                }
            catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Erro no servidor");
                };
            }


        [HttpGet("{id}")]
        public ActionResult<GrainDTO> GetGrain(int id)
        {
            try { 
               
            var grain = ifilterGrainService.GetGrainsTasteById(id);

            if (grain == null)
            {
                    return StatusCode(StatusCodes.Status404NotFound,
                        $"O Grão com id = {id} não foi encontrado");
            }
                var graiDTO = _mapper.Map<GrainDTO>(grain);
            return graiDTO;
        }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut("{id}", Name = "GetGrain")]
        public IActionResult UpdateGrain(int id, [FromBody] GrainDTO grainDto)
        {
            if (id != grainDto.Id)
                return BadRequest($"Não foi possível atualizar a categoria com id = {id}. id inválido");
            
            try
            {
                var grain = _mapper.Map<Grain>(grainDto);
                _uof.GrainRepository.Update(grain);
                _uof.Commit();
                return Ok($"O grão {grain.Name} foi atualizada com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Não modificado");
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] GrainDTO grainDto)
        {
            var grain = _mapper.Map<Grain>(grainDto);

            //var taste = new Taste(grain.Taste.Year,
            //                      grain.Taste.GrainNotes,
            //                      grain.Taste.PronouncedNote);
            _uof.GrainRepository.Add(grain);
            //_uof.TasteRepository.Add(taste);
            

            _uof.Commit();

            var grainDTO = _mapper.Map<GrainDTO>(grain);
            return CreatedAtAction("GetGrain", //precisa ter o mesmo nome da action 
                                    new { id = grain.Id }, grainDTO);

            //try
            //{
            //    var grain = _mapper.Map<Grain>(grainDto);
            //    if (grain.Name==null)
            //    {
            //        return NotFound("JsonNulo");
            //    }

            //    _uof.GrainRepository.Add(grain);
            //    _uof.Commit();

            //    //volta para o cliente via DTO
            //    var grainDTO = _mapper.Map<GrainDTO>(grain);
            //    return CreatedAtAction("GetGrain", //precisa ter o mesmo nome da action 
            //                            new { id = grain.Id }, grainDTO);
            //}
            //catch (Exception)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, $"Não foi possível criar a categoria {grainDto.Name}");
            //}
        }

        // DELETE: api/Grains/5
        [HttpDelete("{id}")]
        public ActionResult<GrainDTO> DeleteGrain(int id)
        {
            try
            {
                var grain = _uof.GrainRepository.GetById(n => n.Id== id);
                if (grain == null)
                {
                    return NotFound("O Grão não foi encontrada");
                }

                _uof.GrainRepository.Delete(grain);
                _uof.Commit();

                var grainDto = _mapper.Map<GrainDTO>(grain);
                return grainDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Categoria não encontrada");
            }
        }


    }
}
