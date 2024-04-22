using ConcertBooking_Entities;
using ConcertBooking_Repository.Concert_Interfaces;
using ConcertBooking_WebApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace ConcertBooking_WebApp.Controllers
{
    public class ConcertController : Controller
    {
        private readonly IConcert _concert;
        private readonly IVenue _venue;
        private readonly IArtist _artist;
        private readonly IUtility _utility;
        private readonly IBookTicket _bookrepo;

        public ConcertController(IConcert concert, IVenue venue, IArtist artist, IUtility utility, IBookTicket bookrepo)
        {
            _concert = concert;
            _venue = venue;
            _artist = artist;
            _utility = utility;
            _bookrepo = bookrepo;
        }

        public async Task<IActionResult> Index()
        {
            var concertdata = await _concert.GetAll();
            var concertlist = new List<ConcertViewModel>();
            foreach (var concert in concertdata)
            {
                var concertitem = new ConcertViewModel
                {
                    Id = concert.Id,
                    Concert_Name = concert.Name,
                    DateTime = concert.DateTime,
                    ArtistName = concert.Artist?.Name,
                    VenueName = concert.Venue?.Name,
                    ImageUrl = concert.ImageUrl,
                };
                concertlist.Add(concertitem);
            }
            return View(concertlist);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var artistlist = await _artist.GetAll();
            var venulist = await _venue.GetAll();
            ViewBag.Artist = new SelectList(artistlist, "Id", "Name");
            ViewBag.Venulist = new SelectList(venulist, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateConcertModel concertmodel)
        {
            var concerts = new Concert
            {
                Name = concertmodel.ConcertName,
                DateTime = concertmodel.DateTime,
                Description = concertmodel.Description,
                ArtistId = concertmodel.ArtistId,
                VenueId = concertmodel.VenueId,
            };
            if (concertmodel.ImageFile != null)
            {
                concerts.ImageUrl = await _utility.SaveImage("ConcertImage", concertmodel.ImageFile);
            }
            //if (concerts.Id > 0)
            //{
            //    await _concert.Edit(concerts);
            //    return RedirectToAction("Index", "concert");
            //}
            await _concert.Save(concerts);
            return RedirectToAction("Index", "concert");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var artistlist = await _artist.GetAll();
            var venulist = await _venue.GetAll();
            ViewBag.Artist = new SelectList(artistlist, "Id", "Name");
            ViewBag.Venulist = new SelectList(venulist, "Id", "Name");
            var concertdata = await _concert.GetById(id);
            var editableconcert = new EditConcertModel()
            {
                ConcertName = concertdata.Name,
                Description = concertdata.Description,
                DateTime = concertdata.DateTime,
                ImageUrl = concertdata.ImageUrl,
                ArtistId = concertdata.ArtistId,
                VenueId = concertdata.VenueId
            };
            return View(editableconcert);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditConcertModel ecm)
        {
            var concertdata = await _concert.GetById(ecm.Id);
            concertdata.Name = ecm.ConcertName;
            concertdata.Description = ecm.Description;
            concertdata.DateTime = ecm.DateTime;
            concertdata.ArtistId = ecm.ArtistId;
            concertdata.VenueId = ecm.VenueId;
            //var concertdata = new Concert()
            //{
            //    Name = ecm.ConcertName,
            //    Description = ecm.Description,
            //    DateTime = ecm.DateTime,
            //    ArtistId = ecm.ArtistId,
            //    VenueId = ecm.VenueId,
            //};
            if (ecm.ImageFile != null)
            {
                concertdata.ImageUrl = await _utility.EditImage("ConcertImage", ecm.ImageFile, ecm.ImageUrl);
            }
            await _concert?.Edit(concertdata);
            return RedirectToAction("Index", "Concert");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _concert.RemoveData(id);
                return RedirectToAction("Index", "Concert");
            }
            return RedirectToAction("Index", "Concert");
        }
        [HttpGet]
        public async Task<IActionResult> GetTicketDetails(int id)
        {
            var ticketinfo =await _bookrepo.GetAllBookedTickets(id);
            var ticketdata =ticketinfo.Select( b=>new DashboardViewModel()
            {
                UserName=b.User?.UserName,
                ConcertName=b.Concert?.Name,
                SeatNumber=string.Join(",",b.Tickets.Select(s=>s.SeatNumber))
            });
            return View(ticketdata);
        }
    }
}
