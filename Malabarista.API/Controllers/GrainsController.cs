using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Malabarista.Domain.Entities;
using Malabarista.Infra.Repositories;
using Malabarista.Domain.Interfaces;
using AutoMapper;
using Malabarista.Application.DTOs;
//using System.Web.Http;

namespace Malabarista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrainsController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public GrainsController(IUnitOfWork context,
            IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        // GET: api/Grains
        [HttpGet]
        public ActionResult<IEnumerable<GrainDTO>> GetGrains()
        {
            try { 
            
            var grainList = _uof.GrainRepository.Get().ToList();
            
            if (grainList.Count == 0)
            {
                return NotFound($"Nenhum item cadastrado");
            }

            var grainDTOList = _mapper.Map<List<GrainDTO>>(grainList);
            
                return grainDTOList;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Algum erro interno no Get");
            };
        }

        
        [HttpGet("{id}")]
        public ActionResult<GrainDTO> GetGrain(int id)
        {
            try { 
            var grain = _uof.GrainRepository.GetById(n=>n.Id==id);

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
            try
            {
                var grain = _mapper.Map<Grain>(grainDto);
                if (grain.Name==null)
                {
                    return NotFound("JsonNulo");
                }

                _uof.GrainRepository.Add(grain);
                _uof.Commit();

                //volta para o cliente via DTO
                var grainDTO = _mapper.Map<GrainDTO>(grain);
                return CreatedAtAction("GetGrain", //precisa ter o mesmo nome da action 
                                        new { id = grain.Id }, grainDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Não foi possível criar a categoria {grainDto.Name}");
            }
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
