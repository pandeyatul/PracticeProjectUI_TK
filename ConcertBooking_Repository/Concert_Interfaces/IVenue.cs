using ConcertBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking_Repository.Concert_Interfaces
{
    public interface IVenue
    {
        Task<IEnumerable<Venue>> GetAll();
        Task<Venue> GetById(int id);
        Task<string> Save(Venue venue);
        Task<string> Edit(Venue venue);
        Task RemoveData(int id);
    }
}
