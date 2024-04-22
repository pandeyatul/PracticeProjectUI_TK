using Entities_TK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK
{
    public class InterfaceCollection
    {

        
            public ICity City { get; }
            public ICountry Country { get; }
            public IState State { get; }
        public InterfaceCollection(ICity city, ICountry country, IState state)
        {
            City = city;
            Country = country;
            State = state;
        }

    }
}
