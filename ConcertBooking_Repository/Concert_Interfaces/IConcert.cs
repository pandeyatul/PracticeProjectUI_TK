using ConcertBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertBooking_Repository.Concert_Interfaces
{
    public interface IConcert
    {
        Task<IEnumerable<Concert>> GetAll();
        Task<Concert> GetById(int id);
        Task<string> Save(Concert concert);
        Task<string> Edit(Concert concert);
        Task RemoveData(int id);
    }
}
