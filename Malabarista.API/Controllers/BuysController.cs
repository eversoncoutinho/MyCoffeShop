using Malabarista.Domain.Entities;
using Malabarista.Infra.Data;
using Malabarista.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Malabarista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuysController : ControllerBase
    {
        private readonly UnitOfWork _uof;

        public BuysController(UnitOfWork context)
        {
            _uof = context;
        }
     
        
    }
}
