using Microsoft.AspNetCore.Mvc;
using Entities_TK;
using Entities_TK.Interface;
using PracticeProjectUI_TK.Models.ViewModels;

namespace PracticeProjectUI_TK.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountry _country;
        public CountryController(ICountry country)
        {
            _country = country;
        }

        public IActionResult Index()
        {
            List<CountryViewModel> countrylist = new List<CountryViewModel>();
            var allcountries = _country.GetAllCountry();
            if (allcountries != null)
            {
                foreach (var country in allcountries)
                {
                    var con = new CountryViewModel
                    {
                        CountryId = country.Id,
                        CountryName = country.Country_Name
                    };
                    countrylist.Add(con);
                }
                return View(countrylist);
            }
            return View();
        }
        public IActionResult Create(int id)
        {
            if (id>0)
            {
                var country = _country?.GetAllCountry()?.FirstOrDefault(x=>x.Id==id);
                return View(country);
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreateCountry(Country country)
        {
            if (country != null)
            {
                if (country.Id>0)
                {
                    _country.UpdateCountry(country);
                    return RedirectToAction("Index");
                }
                _country.CreateCountry(country);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id>0)
            {
                _country.DeleteCountry(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
