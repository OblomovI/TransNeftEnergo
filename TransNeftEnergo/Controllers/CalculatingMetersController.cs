using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransNeftEnergo.DTO;
using TransNeftEnergo.Models;

namespace TransNeftEnergo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatingMetersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalculatingMetersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CalculatingMeters/5
        [HttpGet("{year}")]
        public async Task<ActionResult<IEnumerable<CalculatingMeterDTO>>> GetCalculatingMeter(int year)
        {
            var result = _context.PowerMeasuringPointToCalculatingMeter
               .Where(c => c.FromTime.Year == year || c.ToTime.Year == year)
               .Select(x=> new CalculatingMeterDTO 
               { 
                   PowerSupplyPointName = x.PowerMeasuringPoint.Name,
                   PowerMeasuringPointId = x.CalculatingMeter.Id,
                   FromTime = x.FromTime,
                   ToTime = x.ToTime
               });

            return await result.ToListAsync();           
        }
     
    }
}
