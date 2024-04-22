using ConcertBooking_Entities;
using ConcertBooking_Repository.Concert_Interfaces;
using ConcertBooking_Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking_Repository.Repo_implementation
{
    public class TicketRepository : ITicket
    {
        private readonly ApplicationDbContext _dbcontext;

        public TicketRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<int>> GetTickets(int concertId)
        {
             var bookedTickets =await _dbcontext.ticketTbl.Include(y=>y.Booking).Where(x=>x.Booking.ConcertId==concertId && x.IsBooked).Select(s=>s.SeatNumber).ToListAsync();
            return bookedTickets;
                
        }

        public async Task<IEnumerable<Booking>> GetBookedTickets(string userid)
        {
            var mybookedTickets =await _dbcontext.bookingTbl.Where(x => x.UserId == userid).Include(y => y.Tickets).Include(c=>c.Concert).ToListAsync();
            return mybookedTickets;
        }
    }
}
