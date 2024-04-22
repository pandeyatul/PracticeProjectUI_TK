using ConcertBooking_Repository.Concert_Interfaces;
using ConcertBooking_WebApp.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConcertBooking_WebApp.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicket _ticket;

        public TicketController(ITicket ticket)
        {
            _ticket = ticket;
        }
        //public IActionResult Details()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyBookedTickets()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity?.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim?.Value;
            var ticketinfo=await _ticket.GetBookedTickets(userId??String.Empty);
            List<BookedViewModel> bookedticket = new List<BookedViewModel>();
            foreach (var ticket in ticketinfo)
            {
                var vm = new BookedViewModel()
                {
                    BookingId = ticket.BookingId,
                    BookingDate = ticket.BookingDate,
                    ConcertName = ticket.Concert?.Name,
                    mytickets = ticket.Tickets.Select(t => new MyTicketViewModel()
                    {
                        BookedSeatNumber = t.SeatNumber
                    }).ToList(),
                };
                bookedticket.Add(vm);
            }
            return View(bookedticket);
        }
    }
}
