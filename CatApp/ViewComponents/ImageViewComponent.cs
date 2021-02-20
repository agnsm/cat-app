using CatApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CatApp.ViewComponents
{
    public class ImageViewComponent : ViewComponent
    {
        private readonly ICatAPI _catAPI;

        public ImageViewComponent(ICatAPI catAPI)
        {
            _catAPI = catAPI;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var randomCatImage = await _catAPI.GetRandomImageAsync();
            return View(randomCatImage);
        }
    }
}
