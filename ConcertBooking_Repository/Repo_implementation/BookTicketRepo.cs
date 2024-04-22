using ConcertBooking_Entities;
using ConcertBooking_Repository.Concert_Interfaces;
using ConcertBooking_Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
 

namespace ConcertBooking_Repository.Repo_implementation
{
    public class BookTicketRepo : IBookTicket
    {
        private readonly ApplicationDbContext _DbContext;

        public BookTicketRepo(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task BookTickets(Booking booking)
        {
            try
            {
                await _DbContext.bookingTbl.AddAsync(booking);
                await _DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            { 

            }

        }

        public async Task<IEnumerable<Booking>> GetAllBookedTickets(int concertid)
        {
            var booked_tickets =await _DbContext.bookingTbl.Include(t => t.Tickets).Include(u => u.User).Include(c => c.Concert).Where(x => x.ConcertId == concertid).ToListAsync();
            return booked_tickets;
        }
    }
}
