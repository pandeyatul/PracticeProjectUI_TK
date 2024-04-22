using ConcertBooking_Entities;
using ConcertBooking_Repository.Concert_Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking_WebApp.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenue _Venue;

        public VenueController(IVenue venue)
        {
            _Venue = venue;
        }

        public async Task<IActionResult> Index()
        {
            var Venuedata = await _Venue.GetAll();
            return View(Venuedata);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            if (id > 0)
            {
                var Venueinfo =await _Venue.GetById(id);
                var venuedata = new Venue()
                {
                    Id = Venueinfo.Id,
                    Name = Venueinfo.Name,
                    Address = Venueinfo.Address,
                    SeatCapacity = Venueinfo.SeatCapacity
                };
                return View(venuedata);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Venue Venue)
        {
            try
            {
                var venuedata = new Venue()
                {
                    Id=Venue.Id,
                    Name=Venue.Name,
                    Address=Venue.Address,
                    SeatCapacity=Venue.SeatCapacity
                };
                if (Venue.Id > 0)
                {
                  await  _Venue.Edit(venuedata);
                    return RedirectToAction("Index", "Venue");
                }
              await  _Venue.Save(venuedata);
                return RedirectToAction("Index", "Venue");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _Venue.RemoveData(id);
                return RedirectToAction("Index", "Venue");
            }
            return RedirectToAction("Index", "Venue");
        }
    }
}
