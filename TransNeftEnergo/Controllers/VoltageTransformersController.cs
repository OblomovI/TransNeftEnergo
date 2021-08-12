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
    public class VoltageTransformersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VoltageTransformersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/VoltageTransformers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdNumber>>> GetAll()
        {
            return await _context.VoltageTransformers
                .Select(x => new IdNumber { Id = x.Id, Number = x.Number })
                .ToListAsync();
        }

        // GET: api/ExpiredVoltageTransformers/Id
        [HttpGet("{consumptionObjectId}")]
        public async Task<ActionResult<IEnumerable<IdNumber>>> GetAllExpired(int consumptionObjectId)
        {
            return await _context.VoltageTransformers
                .Where(x => x.InspectionDate.AddDays(x.InspectionPeriod) < DateTime.Now && x.PowerMeasuringPoint.ConsumptionObject.Id == consumptionObjectId)
                .Select(x => new IdNumber { Id = x.Id, Number = x.Number })
                .ToListAsync();
        }
    }
}
