using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Malabarista.Domain.Entities;
using Malabarista.Infra.Repositories;
//using System.Web.Http;

namespace Malabarista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrainsController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public GrainsController(IUnitOfWork context)
        {
            _uof = context;
        }

        // GET: api/Grains
        [HttpGet]
        public ActionResult<IEnumerable<Grain>> GetGrains()
        
        {
            try { 
            var grainList = _uof.GrainRepository.Get().ToList();
            if (grainList.Count == 0)
            {
                return NotFound($"Nenhum item cadastrado");
            }
            return grainList;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Algum erro interno no Get");
            };
        }

        
        [HttpGet("{id}")]
        public ActionResult<Grain> GetGrain(int id)
        {
            try { 
            var grain = _uof.GrainRepository.GetById(n=>n.Id==id);

            if (grain == null)
            {
                    NotFound($"O Grão com id = {id} não foi encontrada");
            }

            return grain;
        }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPut("{id}", Name = "GetGrain")]
        public IActionResult UpdateGrain(int id, Grain grain)
        {
            if (id != grain.Id)
                return BadRequest($"Não foi possível atualizar a categoria com id = {id}. id inválido");

            try
            {
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
        //public async Task<ActionResult<Categoria>> PostCategoria([FromBody]Categoria categoria)
        public IActionResult Post([FromBody] Grain grain)
        {
            try
            {
                if(grain.Name==null)
                {
                    return NotFound("JsonNulo");
                }
                _uof.GrainRepository.Add(grain);
                _uof.Commit();

                return CreatedAtAction("GetGrain", //precisa ter o mesmo nome da action 
                                        new { id = grain.Id }, grain);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Não foi possível criar a categoria {grain.Name}");
            }
        }

        // DELETE: api/Grains/5
        [HttpDelete("{id}")]
        public ActionResult<Grain> DeleteGrain(int id)
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

                return grain;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Categoria não encontrada");
            }
        }


    }
}
