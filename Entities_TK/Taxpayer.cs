using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK
{
    public class Taxpayer
    {
        public int Id { get; set; }
        public string IsReceiveForm1095 { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Policynumber { get; set; } = string.Empty;
        //public string SSN { get; set; } 
        ////Coverage info
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public string IndividualName { get; set; } = string.Empty;
        //public string IndividualSSN { get; set; } = string.Empty;
        //public DateTime DOB { get; set; }
        public virtual List<Monthly_Premium_Information> MonthlyInfo { get; set; }
    }
    public class Monthly_Premium_Information
    { 
        public int Id { get; set; }
        public string? Month { get; set; }
        public decimal? MPAmount { get; set; }
        public decimal? SLCSP { get; set; }
        public decimal? TaxCredit { get; set; }
    }

}
  