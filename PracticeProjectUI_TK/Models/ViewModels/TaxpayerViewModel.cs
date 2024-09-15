using Entities_TK;

namespace PracticeProjectUI_TK.Models.ViewModels
{
    public class TaxpayerViewModel
    {
        public int Id { get; set; }
        public string IsReceiveForm1095 { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Policynumber { get; set; } = string.Empty;
        public decimal AnnualTaxCreditAmmount { get; set; }
        public List<Monthly_Premium_Information> MonthlyInfo { get; set; }
    }
}
