$(function () {
    $('#form1095TblRecord').DataTable();
    responsive: true;
});
// Apply validation for specific input IDs
$('.input-amount').on('input', function () {
    var value = $(this).val();
    // Regular expression to allow only decimal numbers with up to 2 decimal places
    var regex = /^[0-9]*\.?[0-9]{0,2}$/;

    if (!regex.test(value)) {
        // Remove the last invalid character
        $(this).val(value.slice(0, -1));
    }
});
$('.input-amount').on('blur', function () {
    var inputValue = $(this).val();
    var parsedValue = parseFloat(inputValue);

    if (!isNaN(parsedValue)) {
        // Format the value with two decimal places
        var formattedValue = parsedValue.toFixed(2);
        $(this).val(formattedValue);
    };
});

input.value = num //Allow only numbers
}

function showView(viewId) {
    $('.view').removeClass('active');
    $(`#${viewId}`).addClass('active');
}

$('#continue1').on('click', function () {
    //validate
    //event.preventDefault();
    showView('view2');// Hide error message
});
$('#continue2').on('click', function (event) {
    event.preventDefault();
    var isValid = validateReceipientAndCoverage();
    if (isValid) {
        showView('view3');
    }
    else {
        // show error messages
    }
});
$('#back1').on('click', function () {
    showView('view1');
});

$('#back2').on('click', function () {
    showView('view2');
});
// To save form data
function SaveData() {
    var Isvalid = validateReceipientAndCoverage();
    if (Isvalid && ValidateMonthlyinfo()) {
        let data = {

            IsReceivedForm1095A: $('input[name=radioName]:checked').val(),
            Identifier: $("#identifier").val(),
            Policynumber: $("#policyno").val(),
            CoverageInfo: getMonthlyInfo(),
        }
        $.ajax({
            url: "/Form1095/Form1095A",
            type: "POST",
            data: { model: data },
            success: function (response) {

                /*window.location.href = '/Subscriptions/Index';*/
                if (response.success == true) {
                    swal({
                        title: "Saved",
                        text: "Your form has been submitted successfully!",
                        icon: "success",
                        buttons: "Ok",
                    });
                    setTimeout(function () {
                        window.location.href = "/Form1095/GetForm1095AData";
                    }, 2000)

                }
                else {
                    swal({
                        title: "Something went wrong!",
                        text: "Click ok button!",
                        icon: "error",
                        button: "OK",
                    })
                }
            },

        });
    }
}
function UpdateData() {
    var Isvalid = validateReceipientAndCoverage();
    if (Isvalid && ValidateMonthlyinfo()) {
        let data = {
            EncryptedId: $('#id').val(),
            IsReceivedForm1095A: $('input[name=radioName]:checked').val(),
            Identifier: $("#identifier").val(),
            Policynumber: $("#policyno").val(),
            CoverageInfo: getMonthlyInfoToUpdate(),
        }
        $.ajax({
            url: "/Form1095/UpdateForm1095A",
            type: "POST",
            data: { updatemodel: data },
            success: function (response) {
                if (response.success == true) {
                    swal("Updated", "Your record has been Updated successfully", "success")
                    setTimeout(function () {
                        window.location.href = "/Form1095/GetForm1095AData";
                    }, 2000)

                }
                else {
                    swal({
                        title: "Something went wrong!",
                        text: "Click ok button",
                        icon: "error",
                        button: "OK",
                    })
                }
            },
            error: function () {
                swal({
                    title: "Something went wrong!",
                    text: "Click ok button",
                    icon: "error",
                    button: "OK",
                })
            }

        });
    }
}
function getMonthlyInfoToUpdate() {
    var Editdata = [];

    $('#premiumtbody tr').each(function () {
        let row = $(this);
        let monthid = row.find('#monthid').val();
        let month = row.find('#month').text();
        let advancePayment = row.find('#MPAmount').val();
        let slcsp = row.find('#SLCSP').val();
        let taxCredit = row.find('#TaxCredit').val();
        if (advancePayment || slcsp || taxCredit) {
            Editdata.push({
                Id: monthid,
                Month: month,
                AdvancePayment: advancePayment,
                SLCSPPremium: slcsp,
                TaxCredit: taxCredit
            });
        }
    });

    return Editdata;
}
function getMonthlyInfo() {
    var data = [];

    $('#premiumtbody tr').each(function () {
        let row = $(this);
        let month = row.find('#month').text();
        let advancePayment = row.find('#MPAmount').val();
        let slcsp = row.find('#SLCSP').val();
        let taxCredit = row.find('#TaxCredit').val();
        if (advancePayment || slcsp || taxCredit) {
            data.push({

                Month: month,
                AdvancePayment: advancePayment,
                SLCSPPremium: slcsp,
                TaxCredit: taxCredit
            });
        }
    });

    return data;
}
// for copy data from closest row in all next row
$('.copy-btn').on('click', function () {
    var $currentRow = $(this).closest('tr');
    var mpAmount = $currentRow.find('input[id="MPAmount"]').val();
    var slcsp = $currentRow.find('input[id="SLCSP"]').val();
    var taxCredit = $currentRow.find('input[id="TaxCredit"]').val();

    $currentRow.nextAll('tr').each(function () {
        $(this).find('input[id="MPAmount"]').val(mpAmount);
        $(this).find('input[id="SLCSP"]').val(slcsp);
        $(this).find('input[id="TaxCredit"]').val(taxCredit);
    });
});

// validate recepeint info and coverage info
function validateReceipientAndCoverage() {
    var isValid = true;
    if ($("#identifier").val().trim() == '') {
        isValid = false;
        $('#spidentifier').text(ValidationMessage.IdentifierRequired).show();
    }
    else {
        $('#spidentifier').text(ValidationMessage.IdentifierRequired).hide();
    }
    if ($("#policyno").val().trim() == '') {
        isValid = false;
        $('#sppolicyno').text(ValidationMessage.PolicyRequired).show();
    }
    else {
        $('#sppolicyno').text(ValidationMessage.PolicyRequired).hide();
    }
    return isValid;
}
function ValidateMonthlyinfo() {
    let monthydata = getMonthlyInfo();
    let updatedmonthdata = getMonthlyInfoToUpdate();
    if (monthydata.length == 0 || updatedmonthdata.length == 0) {
        $("#message").text(ValidationMessage.MonthDataRequired).show();
        return false;
    }
    else {
        $("#message").text(ValidationMessage.MonthDataRequired).hide();
        return true;
    }
}
function DeleteData(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this record!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    url: "/Form1095/Delete",
                    type: "DELETE",
                    data: { id: Id },
                    success: function (status) {
                        if (status == true) {
                            swal(
                                'Deleted!',
                                'Your record has been deleted.',
                                'success',
                            );
                            setTimeout(function () {
                                location.reload()
                            }, 2000)
                        }
                        else {
                            swal("Oops", "Failed to delete!", "error");
                        }

                    },
                });
                // swal("Deleted!", "Your imaginary file has been deleted.", "success");
            } else {
                swal("Cancelled", "Your record is safe :)", "error");
            }
        });
}
function GetById(Id) {
    window.location.href = "/Form1095/Form1095A?id=" + Id;
}

var Id = $('#id').val();
$.ajax({
    url: "/Form1095/GetFormDataToupdate",
    type: "GET",
    data: { id: Id },
    success: function (result) {
        $('#taxpayerid').val(result.id);
        $('#identifier').val(result.identifier);
        $('#policyno').val(result.policyNumber);
        result.coverageInfo.forEach(month => {
            $(`#premiumtbody tr:contains("${month.month}")`)
                .find('input#MPAmount').val(parseFloat(month.advancePayment).toFixed(2))
                .end().find('input#SLCSP').val(parseFloat(month.slcspPremium).toFixed(2))
                .end().find('input#TaxCredit').val(parseFloat(month.taxCredit).toFixed(2))
                .end().find('input#monthid').val(month.id);
        });
        $('#updatebtn').css('display', 'block');
        $('#savebtn').css('display', 'none');
        $('#back1').css('display', 'none');
        $('#view1').css('display', 'none');
        $(`#view2`).addClass('active');
    },
});
$('#addnewformbtn').on('click', function () {
    $('#view1').css('display', 'none');
    $(`#view2`).addClass('active');
    window.location.href = "/Form1095/Form1095A";
});
