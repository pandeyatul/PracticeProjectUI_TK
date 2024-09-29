using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_TK
{
    class Form1040scModel
    {
        public int Id { get; set; }
        #region Part I: General Information
        public string? NameofProprietor { get; set; }
        public string? NameofBusiness { get; set; }
        public string? PrincipalBusinessorProfession { get; set; }
        public string? BusinessCode { get; set; }
        public string? EmployerIDNumber { get; set; }
        public string? BusinessAddress { get; set; }
        public string? AccountingMethod { get; set; }
        public bool IsMateriallyParticipate { get; set; }
        public bool IsStartedorAcquired { get; set; }
        public bool DidYouMakeAnyPayments { get; set; }
        public bool WillYouFileRequiredForm1099 { get; set; }
        #endregion
        #region Part II: Income Information
        public bool Statutoryemployee { get; set; }
        public decimal GrossReceiptsorSales { get; set; }
        public decimal ReturnsAndAllowances { get; set; }
        public decimal OtherIncome { get; set; }
        public string? InvestmentActivity { get; set; }
        #endregion

        #region Part III: Cost of Goods Sold
        public string? MethodUsedToClosingInventory { get; set; }
        public bool WasanyChangeinDeterminingQuantities { get; set; }//Was there any change in determining quantities, costs, or valuations between opening and closing inventory?
        public decimal? InventoryatBeginningofYear { get; set; }
        public int Purchases { get; set; }
        public decimal CostofLabor { get; set; }
        public decimal MaterialsAndSuppliesCost { get; set; }
        public decimal OtherCosts { get; set; }
        public decimal InventoryatEndofYear { get; set; }
        #endregion

        #region Part IV: Information on Your Vehicle
        public DateTime DateVehicleWasPlacedInService { get; set; }
        public decimal MilesDrivenForBusiness { get; set; }
        public decimal CommutingMiles { get; set; }
        public decimal OtherMiles { get; set; }
        public bool IsVehicleAvailableForPersonalUse { get; set; }
        public bool IsAnotherVehicleForPersonalUse { get; set; }
        public bool IsEvidence { get; set; }
        public bool IsEvidenceWriten { get; set; }
        #endregion

        #region Part V: Expenses
        public decimal Advertising { get; set; }
        public decimal CarAndTruckExpenses { get; set; }
        public decimal DepreciationExpenseDeduction { get; set; }
        public decimal Insurance { get; set; }
        public decimal Interest { get; set; }
        public decimal LegalProfessionalServices { get; set; }
        public decimal PensionProfitSharingPlans { get; set; }
        public decimal ContractLabor { get; set; }
        public decimal EmployeeBenefitPrograms { get; set; }
        public decimal TaxesLicenses { get; set; }
        public decimal Travel { get; set; }
        public decimal RentorLease { get; set; }
        public decimal RepairsMaintenance { get; set; }
        public decimal DeductibleMeals { get; set; }
        public decimal OfficeExpenses { get; set; }
        public decimal Utilities { get; set; }
        public decimal CommissionsFees { get; set; }
        public decimal EnergyEfficient { get; set; }
        public decimal Wages { get; set; }
        public decimal Depletion { get; set; }
        public decimal OtherExpenses { get; set; }
        public decimal BusinessExpenses { get; set; }
        #endregion
    }
}
