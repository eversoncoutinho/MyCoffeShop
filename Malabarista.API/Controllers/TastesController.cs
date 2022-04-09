using AutoMapper;
using Malabarista.Application.DTOs;
using Malabarista.Application.Interfaces;
using Malabarista.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malabarista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TastesController : ControllerBase
    {
       
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        private readonly ITasteService itasteService;

        public TastesController(IUnitOfWork uof, IMapper mapper, ITasteService itasteService)
        {

            _uof = uof;
            _mapper = mapper;
            this.itasteService = itasteService;
        }
        
        [HttpGet]
        public ActionResult<List<string>> GetTaste( )
        {
            List<string> getTaste = itasteService.GetTastes();
            try
            {
                
                if (getTaste.Count() == 0)
                {
                    return NotFound($"Nenhum Taste cadastrado no banco de dados");
                }

                return getTaste;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro no servidor");
            };
        }
    }
}
