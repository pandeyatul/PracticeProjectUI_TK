using ConcertBooking_Entities;
using ConcertBooking_Repository.Concert_Interfaces;
using ConcertBooking_WebApp.Models;
using ConcertBooking_WebApp.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ConcertBooking_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConcert _concert;
        private readonly ITicket _ticket;
        private readonly IBookTicket _bookticket;
        public HomeController(ILogger<HomeController> logger, IConcert concert, ITicket ticket, IBookTicket bookticket)
        {
            _logger = logger;
            _concert = concert;
            _ticket = ticket;
            _bookticket = bookticket;
        }

        public async Task<IActionResult> Index()
        {
            DateTime today = DateTime.Today;
            var concert = await _concert.GetAll();
            var concertinfo = concert.Where(y => y.DateTime >= today).Select(x => new ConcertViewModel
            {
                Id = x.Id,
                Concert_Name = x.Name,
                ArtistName = x.Artist?.Name,
                ImageUrl = x.ImageUrl,
                Description=x.Description
            }).ToList();

            return View(concertinfo);
        }

        public async Task<IActionResult> Details(int id)
        {
            var concert =await _concert.GetById(id);
            var concertinfo = new ConcertViewModel()
            {
                Id=concert.Id,
               Concert_Name=concert.Name,
               Description=concert.Description,
               ArtistName=concert.Artist?.Name,
               DateTime=concert.DateTime,
               ImageUrl=concert.ImageUrl,
               ArtistImageUrl=concert.Artist?.ImageUrl,
               VenueName=concert.Venue?.Name,
               VenueAddress=concert.Venue?.Address
            };
            return View(concertinfo);
        }
        [Authorize]
        public async Task<IActionResult> GetAvailableTickets(int id)
        {
            var concert = await _concert.GetById(id);
            if (concert==null)
            {
                return NotFound();
            }
            var allseats = Enumerable.Range(1,concert.Venue.SeatCapacity).ToList();
            var bookedTicket = await _ticket.GetTickets(concert.Id);
            var availableSeats=allseats.Except(bookedTicket).ToList();
            var Availableticket = new TicketViewModel()
            {
                ConcertId=concert.Id,
                ConcertName=concert.Name,
                AvailableSeats=availableSeats,
            };
            return View(Availableticket);
        }
        [HttpPost]
        public async Task<IActionResult> BookTicket(int concertid,List<int> selectedSeats)
        {
            if (selectedSeats.Count==0||selectedSeats==null)
            {
                ModelState.AddModelError("","No selected the seats");
                return RedirectToAction("GetAvailableTickets", new {id=concertid});
            }
            var claimIdentity =(ClaimsIdentity) User.Identity;
            var claim = claimIdentity?.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim?.Value;
            var newBooking = new Booking
            {
                ConcertId=concertid,
                UserId=userId,
                BookingDate = DateTime.Now,
            };
            foreach (var seatnumber in selectedSeats)
            {
                newBooking.Tickets?.Add(new Ticket
                {
                    SeatNumber=seatnumber,
                    IsBooked=true
                });
            }
           await _bookticket.BookTickets(newBooking);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}