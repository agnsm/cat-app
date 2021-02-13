using CatApp.Models;
using CatApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatAPI _catAPI;

        public HomeController(ILogger<HomeController> logger, ICatAPI catAPI)
        {
            _logger = logger;
            _catAPI = catAPI;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CatImageAsync()
        {
            var randomCatImage = await _catAPI.GetRandomImageAsync();
            return View(randomCatImage);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
