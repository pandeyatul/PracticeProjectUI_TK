using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK.Interface
{
    public interface ICity
    {
        public List<City> GetAllCity();
        public void CreateCity(City city);
        public void UpdateCity(City city);
        public void DeleteCity(int id);
    }


}
