using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK.Interface
{
    public interface ICountry
    {
        public IEnumerable<Country>? GetAllCountry();
        public void CreateCountry(Country country);
        public void UpdateCountry(Country country);
        public void DeleteCountry(int id);

    }
}
