using ConcertBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking_Repository.Concert_Interfaces
{
    public interface IArtist
    {
        Task<IEnumerable<Artist>> GetAll();
        Task<Artist> GetById(int id);
        Task<string> Save(Artist artist);
        Task<string> Edit(Artist artist);
        Task RemoveData(int id);
    }
}
