using Entities_TK.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PracticeProjectUI_TK.ViewComponents
{
    public class CountCityViewComponent : ViewComponent
    {
        private ICity _city;
        public CountCityViewComponent(ICity city)
        {
            _city = city;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities = _city.GetAllCity();
            int citycount = cities.Count();
            return View(citycount);
        }
    }
}
