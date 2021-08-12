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

namespace TransNeftApp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> AddMeasuringPoint()
        {
            ViewBag.currentMeters = await GetListFromApi<IdNumber>(@"http://10.191.99.145/api/CurrentMeters");
            ViewBag.currentTransformers = await GetListFromApi<IdNumber>(@"http://10.191.99.145/api/CurrentTransformers");
            ViewBag.voltageTransformers = await GetListFromApi<IdNumber>(@"http://10.191.99.145/api/VoltageTransformers");
            ViewBag.consObjects = await GetListFromApi<IdName>(@"http://10.191.99.145/api/ConsumptionObjects");
            return View();
        }

        [HttpPost]
        public IActionResult AddMeasuringPoint(PostPowerMeasuringPointParam p)
        {
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
            var result = new List<TEntity>();
            var request = WebRequest.Create(path);
            var response = await request.GetResponseAsync();
            using (var stream = response.GetResponseStream())
            {
                using var reader = new StreamReader(stream);
                string json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }
            response.Close();
            return result;
        }
    }
}
