$(function () {
    $('#taxpayertbl').DataTable();
});
 
$('#addRow').on('click', function () {
    //validate previous row
    let rowId = $("#premiumtbody").children().length;
    var newRow = $('#row-0').clone();
    newRow.attr('id', `row-${rowId}`);
    newRow.find('input').val('');
    newRow.find('#addRow').replaceWith('<button class="deleteRow">Delete</button>');
    $('table tbody').append(newRow);  
});

$('table tbody').on('click', '.deleteRow', function () {
    $(this).closest('tr').remove();
});
//multipe div 
function showView(viewId) {
    $('.view').removeClass('active');
    $(`#${viewId}`).addClass('active');
}

$('#continue-1').on('click', function (event) {
    //validate
    event.preventDefault();
    var isValid = false;

    // Check if any radio button is checked
    if ($('input[name="form1095"]:checked').length > 0) {
        isValid = true;
        $('#radioError').hide();
        showView('view2');// Hide error message
    } else {
        $('#radioError').show(); // Show error message
    }

});

$('#continue2').on('click', function (event) {
    //validate
    event.preventDefault();
    var isValid = validateReceipientAndCoverage();
    if (isValid) {
        showView('view3');
    }
    else {
        // show error messages
    }


});




$('#back-2').on('click', function () {
    showView('view1');
});

//$('#continueN').on('click', function () {
//    showView('view3');
//});

$('#back-3').on('click', function () {
    showView('view2');
});
  
function getMonthlyInfoToupdate() {
    var data = [];

    $('#premiumtbody tr').each(function () {
        var row = $(this);
        var month = row.find('#month').text();
        var monthid = row.find('#monthid').val();
        var premiumAmount = row.find('#MPAmount').val();
        var slcsp = row.find('#SLCSP').val();
        var taxCredit = row.find('#TaxCredit').val();
        if (premiumAmount || slcsp || taxCredit || monthid) {
            data.push({
                Id: monthid,
                Month: month,
                MPAmount: premiumAmount,
                SLCSP: slcsp,
                TaxCredit: taxCredit
            });
        }
    });

    return data;
}

function getMonthlyInfo() {
    var data = [];

    $('#premiumtbody tr').each(function () {
        var row = $(this);
        var month = row.find('#month').text();
        var premiumAmount = row.find('#MPAmount').val();
        var slcsp = row.find('#SLCSP').val();
        var taxCredit = row.find('#TaxCredit').val();
        if (premiumAmount || slcsp || taxCredit) {
            data.push({
                Month: month,
                MPAmount: premiumAmount,
                SLCSP: slcsp,
                TaxCredit: taxCredit
            });
        }
    });

    return data;
}
function SaveData() {
    var Isvalid = validateReceipientAndCoverage();
    if (Isvalid && ValidateMonthlyinfo()) {
        let Model = {
            Identifier: $("#identifier").val(),
            Policynumber: $("#policyno").val(),
            IsReceiveForm1095:$('input[name="form1095"]').val(),
        
            MonthlyInfo: getMonthlyInfo(),
        }
        $.ajax({
            url: "/TaxPayer/Save",
            type: "POST",
            data: { model: Model },
            success: function (response) {

                if (response.success == true) {
                    swal({
                        title: "Saved",
                        text: "Your form has been submitted successfully!",
                        icon: "success",
                        buttons: "Ok",
                    });
                    window.location.hef = "/TaxPayer/Index";
                }
                else {
                    swal({
                        title: "Something went wrong!",
                        text: "You clicked the button!",
                        icon: "error",
                        button: "OK",
                    });
                }
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
}
// validate recepeint info and coverage info
function validateReceipientAndCoverage() {
    var isValid = true;
    if ($("#identifier").val().trim() == '') {
        isValid = false;
        $('#spnidentifier').text('Identifier is required').show();
    }
    else {
        $('#spnidentifier').text('Identifier is required').hide();
    }
    if ($("#policyno").val().trim() == '') {
        isValid = false;
        $('#sppolicyno').text('Policy number is required').show();
    }
    else {
        $('#sppolicyno').text('Policy number is required').hide();
    }
    return isValid;
}
// validate  Part III: Monthly Premium Info
function UpdateData() {
    var Isvalid = validateReceipientAndCoverage();
    if (Isvalid && ValidateMonthlyinfo()) {
        let Model = {
            Id: $('#taxpayerid').val(),
            Identifier: $("#identifier").val(),
            Policynumber: $("#policyno").val(),
            IsReceiveForm1095: $('input[name="form1095"]').val(),

            MonthlyInfo: getMonthlyInfoToupdate(),
        }
        $.ajax({
            url: "/TaxPayer/Update",
            type: "POST",
            data: { model: Model },
            success: function (response) {

                if (response.success == true) {
                    swal({
                        title: "Saved",
                        text: "Your form has been submitted successfully!",
                        icon: "success",
                        buttons: "Ok",
                    })
                }
                else {
                    swal({
                        title: "Something went wrong!",
                        text: "You clicked the button!",
                        icon: "error",
                        button: "OK",
                    });
                }
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
}
function ValidateMonthlyinfo() {
    let monthydata = getMonthlyInfo();
    let updatedmonthlydata = getMonthlyInfoToupdate();
    if (monthydata.length == 0 || updatedmonthlydata.length == 0) {
        $("#message").text("Please,check and make sure al least one records is required for monthy information.").show();
        return false;
    }
    else {
        $("#message").text("Please,check and make sure al least one records is required for monthy information.").hide();
        return true;
    }
}
//To copy data from one row to others rows
$("#copy").on('click', function () {
    let currentRow = $(this).closest('tr');
    //let month = currentRow.find('td[id="month"]').text();
    let MpAmount = currentRow.find('input[id="MPAmount"]').val();
    let slcpAmmount = currentRow.find('input[id="SLCSP"]').val();
    let TaxAmount = currentRow.find('input[id="TaxCredit"]').val();
    currentRow.nextAll('tr').each(function () {
        $(this).find('input[id="MPAmount"]').val(MpAmount);
        $(this).find('input[id="SLCSP"]').val(slcpAmmount);
        $(this).find('input[id="TaxCredit"]').val(TaxAmount);
    });
});

function GetById(Id) {
    window.location.href = "/TaxPayer/Save?id=" + Id;
}

var Id = $('#id').val();
$.ajax({
    url: "/TaxPayer/GetFormDataToupdate",
    type: "GET",
    data: { id: Id },
    success: function (result) {
        $('#id').val(result.id);
        $('#identifier').val(result.identifier);
        $('#policyno').val(result.policynumber);
        result.coverageInfo.forEach(month => {
            $(`#premiumtbody tr:contains("${month.month}")`)
                .find('input[id=MPAmount]').val(parseFloat(month.mpAmount).toFixed(2))
                .end().find('input[id=SLCSP]').val(parseFloat(month.slcsp).toFixed(2))
                .end().find('input[id=TaxCredit]').val(parseFloat(month.taxCredit).toFixed(2))
                .end().find('input[id=monthid]').val(month.id);
        });
        $('#updatebtn').css('display', 'block');
        $('#savebtn').css('display', 'none');
        $('#back1').css('display', 'none');
        $('#view1').css('display', 'none');
        $(`#view2`).addClass('active');
    },
});