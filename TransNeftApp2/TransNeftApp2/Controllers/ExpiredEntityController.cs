using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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
            ViewBag.data = await GetListFromApi<ExpiredEntityDTO>($"{rootApiUrl}{entityType}/{consObjId}");
            return View();
        }
    }
}
