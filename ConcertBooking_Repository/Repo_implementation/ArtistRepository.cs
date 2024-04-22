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
    public class ArtistRepository : IArtist
    {
        private readonly ApplicationDbContext _dbcontext;

        public ArtistRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<string> Edit(Artist artist)
        {
            _dbcontext?.Update(artist);
            await _dbcontext.SaveChangesAsync();
            return "Updated";
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            var artistslist =_dbcontext.artistTbl?.ToListAsync();
            return await artistslist;
        }

        public async Task<Artist> GetById(int id)
        {
            var artistinfo = _dbcontext.artistTbl?.FirstOrDefaultAsync(x=>x.Id==id);
            return await artistinfo;
        }

        public async Task RemoveData(int id)
        {
            var artistinfo = GetById(id);
            _dbcontext?.Remove(artistinfo);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<string> Save(Artist artist)
        {
            _dbcontext?.AddAsync(artist);
            await _dbcontext.SaveChangesAsync();
            return "Saved";
        }
    }
}
