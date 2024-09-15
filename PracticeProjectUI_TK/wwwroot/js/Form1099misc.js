$(document).ready(function () {
    // AJAX request to get recipient data from the server
});
 
$.ajax({
    //url: '@Url.Action("GetRecipientdata", "Form1099Misc")', // Controller action URL
    url: '/Form1099Misc/GetRecipientdata', // Controller action URL
    method: 'GET',
    dataType: 'json',
    success: function (response) {
        let name = [];
        let address = [];
        let ssn = [];
        $.each(response, function (i, item) {
            name.push(item.name);
            address.push(item.address);
            ssn.push(item.ssn);
        });
         //Populate select elements with the response data
        populateSelect('#recipient-name',name);
        populateSelect('#recipient-address',address);
        populateSelect('#recipient-tin',ssn);
    },
    error: function (xhr, status, error) {
        console.error("Error fetching recipient data:", error);
    }
});
    // Function to populate the select tags
    function populateSelect(selector, data) {
        var selectElement = $(selector);
        selectElement.empty().append('<option value="" disabled selected>Select an option</option>'); // Reset options
        $.each(data, function (index, value) {
            selectElement.append('<option value="' + value + '">' + value + '</option>');
        });
}
// To save data
function Save() {
    form1099miscdata = {
        payerName: $('#payer-name').val(),
        payerAddress: $('#payer-address').val(),
        payerTIN: $('#payer-tin').val(),
        RecipientName: $('#recipient-name').val(),
        RecipientAddress: $('#recipient-address').val(),
        RecipientSSN: $('#recipient-tin').val(),
        Rent: $('#rent').val(),
        Royalties: $('#royalties').val(),
        OtherIncome: $('#otherincome').val(),
        FederalIncomeTaxWithheld: $('#Federalwithheld').val(),
        FishingBoatProceeds: $('#fishingboat').val(),
        MedicalHealthCarePayments: $('#healthcare').val(),
        NonemployeeCompensation: $('#nonempcompensation').val(),
        LieofDividendsorInterest: $('#lieuofdividend').val(),
        CropInsuranceProceeds: $('#cropinsurance').val(),
        PaidtoAttorney: $('#attorney').val(),
        Section409AIncome: $('#sec409aincome').val(),
        ParachutePayments: $('#parachutepayment').val(),
        DeferredCompensation: $('#nonqdeferredcomp').val(),
        StateTaxWithheld: $('#statewithheld').val(),
        PayerStateNumber: $('#payerstateno').val(),
        State: $('#state').val(),
        StateIdno: $('#stateidno').val(),
        StateAmount: $('#stateamount').val(),
    }
    $.ajax({
        url: "/Form1099Misc/Form1099Misc",
        type: "POST",
        data: { model: form1099miscdata },
        success: function () {
            swal({
                title: "Saved",
                text: "Your form has been submitted successfully!",
                icon: "success",
                buttons: "Ok",
            });
        },
        error: function () {
            swal({
                title: "Something went wrong!",
                text: "You clicked the button!",
                icon: "error",
                button: "OK",
            });
        }
    });
}