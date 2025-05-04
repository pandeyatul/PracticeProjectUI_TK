$(function () {


    $('#form1040scId').validate({
        rules: {
            NameofProprietor: {
                required: true
            },
            NameofBusiness: {
                required: true
            },
            PrincipalBusinessorProfession: {
                required: true
            },
            BusinessCode: {
                required: true
            },
            EmployerIDNumber: {
                required: true
            },
            BusinessAddress: {
                required: true
            },
            AccountingMethod: {
                required: true
            },
            GrossReceiptsorSales: {
                required: true
            },
            ReturnsAndAllowances: {
                required: true
            },
            OtherIncome: {
                required: true
            },
            InvestmentActivity: {
                required: true
            },
            MethodUsedToClosingInventory: {
                required: true
            },
            InventoryatBeginningofYear: {
                required: true
            },
            Purchases: {
                required: true
            },
            CostofLabor: {
                required: true
            },
            MaterialsAndSuppliesCost: {
                required: true
            },
            OtherCosts: {
                required: true
            },
            InventoryatEndofYear: {
                required: true
            },
            DateVehicleWasPlacedInService: {
                required: true
            },
            MilesDrivenForBusiness: {
                required: true
            },
            CommutingMiles: {
                required: true
            },
            OtherMiles: {
                required: true
            },
            Advertising: {
                required: true
            },
            CarAndTruckExpenses: {
                required: true
            },
            DepreciationExpenseDeduction: {
                required: true
            },
            Insurance: {
                required: true
            },
            Interest: {
                required: true
            },
            LegalProfessionalServices: {
                required: true
            },
            PensionProfitSharingPlans: {
                required: true
            },
            ContractLabor: {
                required: true
            },
            EmployeeBenefitPrograms: {
                required: true
            },
            TaxesLicenses: {
                required: true
            },
            Travel: {
                required: true
            },
            RentorLease: {
                required: true
            },
            RepairsMaintenance: {
                required: true
            },
            DeductibleMeals: {
                required: true
            },
            OfficeExpenses: {
                required: true
            },
            Utilities: {
                required: true
            },
            CommissionsFees: {
                required: true
            },
            EnergyEfficient: {
                required: true
            },
            Wages: {
                required: true
            },
            Depletion: {
                required: true
            },
            OtherExpenses: {
                required: true
            },
            BusinessExpenses: {
                required: true
            }

        },
        messages: {
            NameofProprietor: {
                required: "Enter your Proprietor name"
            },
            NameofBusiness: {
                required: "Enter the Name of Business"
            },
            PrincipalBusinessorProfession: {
                required: "Enter the Principal of Businessor Profession"
            },
            BusinessCode: {
                required: "Enter the Business Code"
            },
            EmployerIDNumber: {
                required: "Enter the Employer ID Number"
            },
            BusinessAddress: {
                required: "Enter the Business Address"
            },
            AccountingMethod: {
                required: "Select a Accounting method"
            },
            GrossReceiptsorSales: {
                required: "Enter Gross Receipts or Sales"
            },
            ReturnsAndAllowances: {
                required: "Enter Returns And Allowances"
            },
            OtherIncome: {
                required: "Enter other income"
            },
            InvestmentActivity: {
                required: "Enter a investment activity"
            },
            MethodUsedToClosingInventory: {
                required: "Select a method used to closing inventory"
            },
            InventoryatBeginningofYear: {
                required: "Enter the inventory amount"
            },
            Purchases: {
                required: "Enter the purchases"
            },
            CostofLabor: {
                required: "Enter cost of labor"
            },
            MaterialsAndSuppliesCost: {
                required: "Enter materials and supplies cost"
            },
            OtherCosts: {
                required: "Enter other cost"
            },
            InventoryatEndofYear: {
                required: "Enter inventory at end of year"
            },
            DateVehicleWasPlacedInService: {
                required: "Enter Date Vehicle Was Placed In Service"
            },
            MilesDrivenForBusiness: {
                required: "Enter miles driven for business"
            },
            CommutingMiles: {
                required: "Enter Commuting Miles"
            },
            OtherMiles: {
                required: "Enter other miles"
            },
            Advertising: {
                required: "Enter advertising expanses"
            },
            CarAndTruckExpenses: {
                required: "Enter car and truck expenses"
            },
            DepreciationExpenseDeduction: {
                required: "Enter Depreciation Expense Deduction"
            },
            Insurance: {
                required: "Enter insurance amount"
            },
            Interest: {
                required: "Enter interest amount"
            },
            LegalProfessionalServices: {
                required: "Enter legal professional services expenses"
            },
            PensionProfitSharingPlans: {
                required:  "Enter Pension Profit Sharing Plans"
            },
            ContractLabor: {
                required: "Enter contract labor expenses"
            },
            EmployeeBenefitPrograms: {
                required: "Enter employee benefit programs expenses"
            },
            TaxesLicenses: {
                required: "Enter taxes and licenses expenses"
            },
            Travel: {
                required: "Enter your travel expenses"
            },
            RentorLease: {
                required: "Enter rent or lease expenses"
            },
            RepairsMaintenance: {
                required: "Enter repairs and maintenance expenses"
            },
            DeductibleMeals: {
                required: "Enter deductible meales"
            },
            OfficeExpenses: {
                required: "Enter office expenses"
            },
            Utilities: {
                required: "Enter utilities expenses"
            },
            CommissionsFees: {
                required: "Enter commission fees"
            },
            EnergyEfficient: {
                required: "Enter energy efficient"
            },
            Wages: {
                required: "Enter wages expenses"
            },
            Depletion: {
                required: "Enter depletion expenses"
            },
            OtherExpenses: {
                required: "Enter other expenses"
            },
            BusinessExpenses: {
                required: "Enter business expenses"
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('text-danger');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).closest('.form-group').removeClass('has-error');
        }
    });

});

function SubmitData() {
    var form1040data = new FormData($('#form1040scId')[0]);
    var IsValid = $('#form1040scId').valid();
    if (IsValid) {
        $.ajax({
            url: "/Form1099Misc/Form1040sc",
            type: "POST",
            data: form1040data,
            contentType: false,
            processData: false,
            success: function (status) {
                alert("saved");
            },
        });
    }
}