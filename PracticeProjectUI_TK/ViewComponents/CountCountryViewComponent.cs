using Entities_TK.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PracticeProjectUI_TK.ViewComponents
{
    public class CountCountryViewComponent:ViewComponent
    {
        private ICountry _country;

        public CountCountryViewComponent(ICountry country)
        {
            _country = country;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var countries = _country.GetAllCountry();
            int countrycount = countries.Count();
            return View(countrycount);
        }
    }
}
