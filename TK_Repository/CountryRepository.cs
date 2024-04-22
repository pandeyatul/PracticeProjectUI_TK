using Entities_TK;
using Entities_TK.Interface;
using PracticeProjectUI_TK.Data;

namespace TK_Repository
{
    public class CountryRepository : ICountry
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Country>? GetAllCountry()
        {
            var countrylist = _context?.countryTbl?.ToList();
            return countrylist;
        }
        public void CreateCountry(Country country)
        {
            _context?.countryTbl?.Add(country);
            _context?.SaveChanges();
        }
        public void UpdateCountry(Country country)
        {
           _context.countryTbl?.Update(country);
            _context.SaveChanges();
        }
        public void DeleteCountry(int id)
        {
                var country= _context?.countryTbl?.FirstOrDefault(c => c.Id==id);
            if (country!=null)
            {
                _context?.countryTbl?.Remove(country);
                _context?.SaveChanges();
            }
                
        }

        
    }
}