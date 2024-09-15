using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProjectUI_TK.Models.ViewModels
{
    public class From1099MiscViewModel
    {
        public int Id { get; set; }
        public string PayerName { get; set; }
        public string PayerAddress { get; set; }
        public string PayerTin { get; set; }
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientSSN { get; set; }
        public decimal Rents { get; set; }
        public decimal Royalties { get; set; }
        public decimal OtherIncome { get; set; }
        public decimal FederalIncomeTaxWithheld { get; set; }
        public decimal FishingBoatProceeds { get; set; }
        public decimal MedicalHealthCarePayments { get; set; }
        public decimal NonemployeeCompensation { get; set; }
        public decimal LieofDividendsorInterest { get; set; }
        public decimal CropInsuranceProceeds { get; set; }
        public decimal PaidtoAttorney { get; set; }
        public decimal Section409AIncome { get; set; }
        public decimal ParachutePayments { get; set; }
        public decimal DeferredCompensation { get; set; }
        public decimal StateTaxWithheld { get; set; }
        public decimal PayerStateNumber { get; set; }


    }
}
