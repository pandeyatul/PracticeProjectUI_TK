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
    public class VenueRepository : IVenue
    {
    private readonly ApplicationDbContext _dbcontext;

        public VenueRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<string> Edit(Venue venue)
        {
            _dbcontext.Update(venue);
           await _dbcontext.SaveChangesAsync();
            return "Updated";
        }

        public async Task<IEnumerable<Venue>> GetAll()
        {
            var venuelist = await _dbcontext?.VenueTbl?.ToListAsync();
            return venuelist;
        }

        public async Task<Venue> GetById(int id)
        {
            var venueinfo = await _dbcontext.VenueTbl.FirstOrDefaultAsync(x=>x.Id==id);
            return venueinfo;
        }

        public Task RemoveData(int id)
        {
            var venue = GetById(id);
            _dbcontext.Remove(venue);
            _dbcontext.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task<string> Save(Venue venue)
        {
            try
            {
                //if (venue.Id>0)
                //{
                //    _dbcontext.Update(venue);
                //    await _dbcontext.SaveChangesAsync();
                //    return "Updated";
                //}
                await _dbcontext.AddAsync(venue);
                await _dbcontext.SaveChangesAsync();
                return "Saved";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
