using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransNeftEnergo;
using TransNeftEnergo.DTO;
using TransNeftEnergo.Models;

namespace TransNeftEnergo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentMetersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurrentMetersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CurrentMeters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdNumber>>> GetAll()
        {
            return await _context.CurrentMeters.Select(x => new IdNumber { Id = x.Id, Number = x.Number }).ToListAsync();
        }

        // GET: api/ExpiredCurrentMeters/Id
        [HttpGet("{consumptionObjectId}")]
        public async Task<ActionResult<IEnumerable<IdNumber>>> GetAllExpired()
        {
            return await _context.CurrentMeters.Where(x => x.InspectionDate < DateTime.Now).Select(x => new IdNumber { Id = x.Id, Number = x.Number }).ToListAsync();
        }

    }
}
