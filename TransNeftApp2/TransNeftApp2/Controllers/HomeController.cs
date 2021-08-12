using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TransNeftEnergo.DTO;

namespace TransNeftApp2.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> AddMeasuringPoint()
        {
            ViewBag.currentMeters = await GetListFromApi<IdNumber>($"{rootApiUrl}CurrentMeters");
            ViewBag.currentTransformers = await GetListFromApi<IdNumber>($"{rootApiUrl}CurrentTransformers");
            ViewBag.voltageTransformers = await GetListFromApi<IdNumber>($"{rootApiUrl}VoltageTransformers");
            ViewBag.consObjects = await GetListFromApi<IdName>($"{rootApiUrl}ConsumptionObjects");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasuringPoint(PostPowerMeasuringPointParam p)
        {
            var content = JsonContent.Create(p);
            await client.PostAsync($"{rootApiUrl}PowerMeasuringPoints", content);
            ViewBag.Message = "Точка добавлена";
            return View();
        }
    }
}
