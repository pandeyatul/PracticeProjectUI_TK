using Entities_TK;
using Entities_TK.Interface;
using Microsoft.EntityFrameworkCore;
using PracticeProjectUI_TK.Data;

namespace TK_Repository
{
    public class CityRepository : ICity
    {
        private readonly ApplicationDbContext _dbContext;

        public CityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCity(City city)
        {
            _dbContext?.cityTbl?.Add(city);
            _dbContext?.SaveChanges();
        }
        public void DeleteCity(int id)
        {
            var cityitem = _dbContext?.cityTbl?.ToList().Find(x => x.Id == id);
            if (cityitem!=null)
            {
                _dbContext?.cityTbl?.Remove(cityitem);
                _dbContext?.SaveChanges();
            }
        }

        public List<City> GetAllCity()
        {
            var cities =  _dbContext.cityTbl?.Include(s => s.State).ThenInclude(c => c.Country).ToList(); 
            if (cities != null)
            {
                return cities;
            }
            return new List<City>();
        }

        public void UpdateCity(City city)
        {
            _dbContext?.cityTbl?.Update(city);
            _dbContext?.SaveChanges();
        }
    }
}
