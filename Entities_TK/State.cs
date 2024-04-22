using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK
{
    public class State
    {
        public int Id { get; set; }
        public string? State_Name { get; set; }
        public int Country_ID { get; set; }
        public Country? Countries { get; set; }
        public ICollection<City> City { get; set; } = new HashSet<City>();
    }
}
