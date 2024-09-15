using Entities_TK;
using Entities_TK.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticeProjectUI_TK.Models.ViewModels;

namespace PracticeProjectUI_TK.Controllers
{
    public class CityController : Controller
    {
        //private readonly ICity? _city;
        //private readonly ICountry? _country;
        //private readonly IState? _state;
        private readonly InterfaceCollection _parameters;

        public CityController(InterfaceCollection parameters)
        {
            _parameters = parameters;
        }

        public IActionResult Index()
        {
            var citydata = _parameters.City.GetAllCity();
            var countrydata = _parameters.Country?.GetAllCountry();
            var statedata = _parameters.State?.GetAllState();
            List<CityViewModel> citylist = new List<CityViewModel>();
            if (citydata != null)
            {
                foreach (var cityitem in citydata)
                {
                    var citys = new CityViewModel
                    {
                        City_id = cityitem.Id,
                        City_name = cityitem.city_Name,
                        StateName = statedata?.Where(s => s.Id == cityitem.StateID).Select(n => n.State_Name).FirstOrDefault(),
                        Country_Name = countrydata?.Where(y => y.Id == cityitem?.State?.CountryID).Select(x => x.Country_Name).FirstOrDefault()
                    };
                    citylist.Add(citys);
                }
                //foreach (var cityitem in citydata)
                //{
                //    var citys = new CityViewModel
                //    {
                //        City_id = cityitem.Id,
                //        City_name = cityitem.city_Name,
                //        StateName = cityitem?.State?.State_Name,
                //        Country_Name = cityitem?.State?.Countries?.Country_Name
                //    };
                //    citylist.Add(citys);
                //}
            }
            return View(citylist);
        }
        public IActionResult CreateCity(int id)
        {

            var countrydata = _parameters.Country?.GetAllCountry()?.ToList();
            var statedata = _parameters.State?.GetAllState()?.ToList();
            var cityview = new CityViewModel
            {
                States = statedata.Select(s => new SelectListItem()
                {
                    Text = s.State_Name,
                    Value = s.Id.ToString(),
                    Selected = true
                }),
                countries = countrydata.Select(c => new SelectListItem()
                {
                    Text = c.Country_Name,
                    Value = c.Id.ToString(),
                    Selected = true
                })
            };
            if (id > 0)
            {
                var citydata = _parameters.City.GetAllCity().Find(x => x.Id == id);
                cityview.City_name = citydata?.city_Name;
                cityview.City_id = citydata.Id;
            }
            return View(cityview);
        }
        [HttpPost]
        public IActionResult CreateCity(CityViewModel city)
        {
            var cityinfo = new City();
            if (city != null)
            {
                cityinfo.city_Name = city.City_name;
                cityinfo.Id = city.City_id;
                cityinfo.StateID = city.state_id;
            }
            else
            {
                return View();
            }

            var citydata = _parameters.City.GetAllCity();
            var countrydata = _parameters.Country.GetAllCountry();
            var statedata = _parameters.State.GetAllState();
            if (city?.City_id > 0)
            {
                _parameters.City.UpdateCity(cityinfo);
                return RedirectToAction("Index");
            }
            else
            {
                _parameters.City.CreateCity(cityinfo);
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _parameters.City.DeleteCity(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
