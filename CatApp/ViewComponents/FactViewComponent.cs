using CatApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CatApp.ViewComponents
{
    public class FactViewComponent : ViewComponent
    {
        private readonly ICatFactsAPI _catFactsAPI;

        public FactViewComponent(ICatFactsAPI catFactsAPI)
        {
            _catFactsAPI = catFactsAPI;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var randomCatFact = await _catFactsAPI.GetRandomFactAsync();
            return View(randomCatFact);
        }
    }
}
