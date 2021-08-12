using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TransNeftApp2.Data;
using TransNeftEnergo.DTO;

namespace TransNeftApp2.Controllers
{
    public class ExpiredEntityController : BaseController
    {
        public ExpiredEntityController(ILogger<ExpiredEntityController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> ExpiredEntities(string entityType)
        {
            ViewBag.consObjects = await GetListFromApi<IdName>($"{rootApiUrl}ConsumptionObjects");
            ViewBag.entityType = entityType;
            return View();
        }

        public async Task<IActionResult> ExpiredEntities(string entityType, int consObjId)
        {
            ViewBag.consObjects = await GetListFromApi<IdName>($"{rootApiUrl}ConsumptionObjects");
            ViewBag.entityType = entityType;
            ViewBag.data = await GetListFromApi<IdNumber>($"{rootApiUrl}{entityType}/{consObjId}");
            return View();
        }
    }
}
