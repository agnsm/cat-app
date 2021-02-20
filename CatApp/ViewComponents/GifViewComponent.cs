using CatApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CatApp.ViewComponents
{
    public class GifViewComponent : ViewComponent
    {
        private readonly ICatAPI _catAPI;

        public GifViewComponent(ICatAPI catAPI)
        {
            _catAPI = catAPI;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var randomCatGif = await _catAPI.GetRandomGifAsync();
            return View(randomCatGif);
        }
    }
}
