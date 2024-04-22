using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK
{
    public class Address
    {
        public int Id { get; set; }
        public string Address_streetline1 { get; set; } = string.Empty;
        public string Address_streetline2 { get; set; } = string.Empty;
        public string Pincode { get; set;} = string.Empty;
    }

}
