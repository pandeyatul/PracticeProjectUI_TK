using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK
{
    public class City
    {
        public int Id { get; set; }
        public string? city_Name { get; set; }
        public int StateID { get; set; }
        public State? State { get; set; }

    }
}
