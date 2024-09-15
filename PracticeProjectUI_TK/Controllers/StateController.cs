using Entities_TK;
using Entities_TK.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticeProjectUI_TK.Models.ViewModels;

namespace PracticeProjectUI_TK.Controllers
{
    public class StateController : Controller
    {
        private readonly IState _state;
        private readonly ICountry _country;
        public StateController(IState state, ICountry country)
        {
            _state = state;
            _country = country;
        }

        public IActionResult Index()
        {
            var statelist = _state.GetAllState();
            var counries = _country.GetAllCountry()?.ToList();
            List<StateViewModel> listofstate = new List<StateViewModel>();
            if (statelist != null)
            {
                foreach (var stateitem in statelist)
                {
                    var rajya = new StateViewModel
                    {
                        StateId = stateitem.Id,
                        State_Name = stateitem.State_Name,
                        Country_Name = counries?.Where(x => x.Id == stateitem.CountryID).Select(c => c.Country_Name).FirstOrDefault()
                    };
                    listofstate.Add(rajya);
                }
                return View(listofstate);
            }
            return View();
        }
        public IActionResult CreateState(int id)
        {
            try
            {
                var counries = _country.GetAllCountry()?.ToList();
                var statedata = _state?.GetAllState()?.FirstOrDefault(x => x.Id == id);
                StateViewModel stateView = new StateViewModel();
                if (id > 0)
                {
                    stateView.Countrys = counries.Select(c => new SelectListItem()
                    {
                        Text = c.Country_Name,
                        Value = c.Id.ToString()
                    });
                    stateView.State_Name = statedata?.State_Name;
                    stateView.Country_ID = statedata.CountryID;
                    stateView.StateId = statedata.Id;
                    // stateView.Country_Name = counries?.Where(x => x.Id == statedata?.Country_ID).Select(c => c.Country_Name).FirstOrDefault();
                }
                else
                {
                    stateView.Countrys = counries.Select(c => new SelectListItem()
                    {
                        Text = c.Country_Name,
                        Value = c.Id.ToString()
                    });
                }

                return View(stateView);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NullReferenceException caught!");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

            }

            return View();
        }
        [HttpPost]
        public IActionResult CreateState(StateViewModel statemodel)
        {
            var state = new State
            {
                Id = statemodel.StateId,
                State_Name = statemodel.State_Name,
                CountryID = statemodel.Country_ID
            };
            if (state != null)
            {
                if (state.Id > 0)
                {
                    _state.UpdateState(state);
                    return RedirectToAction("Index");
                }
                _state.CreateState(state);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _state.DeleteState(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
