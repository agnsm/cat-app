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
        private readonly ICatFactsAPI _catFactsAPI;

        public HomeController(ILogger<HomeController> logger, ICatAPI catAPI, ICatFactsAPI catFactsAPI)
        {
            _logger = logger;
            _catAPI = catAPI;
            _catFactsAPI = catFactsAPI;
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

        public IActionResult ImageViewComponent()
        {
            return ViewComponent("Image");
        }

        public async Task<IActionResult> CatGifAsync()
        {
            var randomCatGif = await _catAPI.GetRandomGifAsync();
            return View(randomCatGif);
        }

        public IActionResult GifViewComponent()
        {
            return ViewComponent("Gif");
        }

        public async Task<IActionResult> CatFactAsync()
        {
            var randomCatFact = await _catFactsAPI.GetRandomFactAsync();
            return View(randomCatFact);
        }

        public IActionResult FactViewComponent()
        {
            return ViewComponent("Fact");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
