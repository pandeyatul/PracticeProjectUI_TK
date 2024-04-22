using ConcertBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking_Repository.Concert_Interfaces
{
    public interface ITicket
    {
        Task<IEnumerable<int>> GetTickets(int concertId);
        Task<IEnumerable<Booking>> GetBookedTickets(string userid);
    }
}
