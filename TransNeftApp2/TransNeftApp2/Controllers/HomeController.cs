using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using TransNeftApp2.Models;
using TransNeftEnergo.Models;
using TransNeftEnergo.DTO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;

namespace TransNeftApp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> AddMeasuringPoint()
        {
            ViewBag.currentMeters = await GetListFromApi<IdNumber>(@"http://127.0.0.1:8050/api/CurrentMeters");
            ViewBag.currentTransformers = await GetListFromApi<IdNumber>(@"http://127.0.0.1:8050/api/CurrentTransformers");
            ViewBag.voltageTransformers = await GetListFromApi<IdNumber>(@"http://127.0.0.1:8050/api/VoltageTransformers");
            ViewBag.consObjects = await GetListFromApi<IdName>(@"http://127.0.0.1:8050/api/ConsumptionObjects");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasuringPoint(PostPowerMeasuringPointParam p)
        {
            var json = Json(p);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            await client.PostAsync("http://127.0.0.1:8050/api/PowerMeasuringPoints", content);
            ViewBag.Message = "Точка добавлена";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<List<TEntity>> GetListFromApi<TEntity>(string path)
        {
            var response = await client.GetStringAsync(path);
            var result = JsonConvert.DeserializeObject<List<TEntity>>(response);

            return result;
        }
    }
}
