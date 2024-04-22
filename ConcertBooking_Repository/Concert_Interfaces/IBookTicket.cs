using ConcertBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking_Repository.Concert_Interfaces
{
    public interface IBookTicket
    {
        Task BookTickets(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookedTickets(int concertid);
    }
}
