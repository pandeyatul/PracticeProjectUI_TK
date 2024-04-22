using ConcertBooking_Entities;
using ConcertBooking_Repository.Concert_Interfaces;
using ConcertBooking_Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace ConcertBooking_Repository.Repo_implementation
{
    public class ConcertRepository : IConcert
    {
        private readonly ApplicationDbContext _dbcontext;

        public ConcertRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<string> Edit(Concert concert)
        {
            try
            {
                _dbcontext.Update(concert);
                await _dbcontext.SaveChangesAsync();
                return "Updated";
            }
            catch (Exception)
            {
                return "Updation failed...";
            }
        }
        public async Task<IEnumerable<Concert>> GetAll()
        {
            var concertlist = await _dbcontext.concertTbl?.Include(v => v.Venue).Include(a => a.Artist).ToListAsync();
            if (concertlist.Count > 0)
            {
                return concertlist;
            }
            return new List<Concert>();
        }

        public async Task<Concert> GetById(int id)
        {
            var concert = await _dbcontext?.concertTbl?.Include(v => v.Venue).Include(a => a.Artist).FirstOrDefaultAsync(x => x.Id == id);
            return concert;
        }

        public async Task RemoveData(int id)
        {
            var concert =await GetById(id);
            _dbcontext.Remove(concert);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<string> Save(Concert concert)
        {
            await _dbcontext.AddAsync(concert);
            await _dbcontext.SaveChangesAsync();
            return "Saved";
        }
    }
}
