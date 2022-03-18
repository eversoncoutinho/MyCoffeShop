using Malabarista.Domain.Entities;
using Malabarista.Infra.Data;
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
    public class BuysController : ControllerBase
    {
        private readonly MalabaristaDbContext _context;

        public BuysController(MalabaristaDbContext context)
        {
            _context = context;
        }

    }
}
