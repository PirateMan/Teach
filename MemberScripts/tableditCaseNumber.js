$(document).ready(function () {


    // ------------------------------------------------------------ //
    // ------------------- jQuery-Tabledit Plugin ----------------- //
    // ------------------------------------------------------------ //

    $('#training').Tabledit({
        deleteButton: false,
        edit: {
            class: 'btn btn-sm btn-default',
            html: '<span class="glyphicon glyphicon-pencil"></span>',
            action: 'edit'
        },

        columns: {
            identifier: [0, 'id'],
            editable: [[1, 'demoBy'], [2, 'dateCompleted']],
        }
    });



    // ------------------------------------------------------------ //
    // ---------------------- DatePicker Plugin ------------------- //
    // ------------------------------------------------------------ //

    $('.myDate').unbind();
    $('.myDate').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true
    });



    // ------------------------------------------------------------ //
    // ------------------ Hide Approved Edit Buttons -------------- //
    // ------------------------------------------------------------ //

    // get table dom object
    var table = document.getElementById('training');
    var tableRowLength = table.rows.length; //row 0 is header
    var count = 0;

    for (var x = 1; x < tableRowLength; x++) {
        var test = table.rows[x].cells[5].children[0].id = x;
    }

    for (var x = 1; x < tableRowLength; x++) {
        if (table.rows[x].cells[4].innerText.indexOf("Approved By") !== -1) {
            var rowId = table.rows[x].cells[5].children[0].id;
            var div = document.getElementById(rowId);
            div.classList.remove("tabledit-toolbar");
            div.classList.remove("btn-toolbar");
            div.classList.add("hideDiv");
        }
    }

    //wait for js before loading table
    $('#repeaterTableWrapper').removeClass('hideDiv');



    // ------------------------------------------------------------ //
    // ---------------- Tabledit Edit Click Event ----------------- //
    // ------------------------------------------------------------ //

    $('.tabledit-edit-button').click(function () {

        var table = document.getElementById('training');
        var rowIndex = $(this).closest('td').parent()[0].sectionRowIndex;
        var input1 = table.rows[rowIndex].cells[1].children[1].value;
        var input2 = table.rows[rowIndex].cells[2].children[1].value;

        $('.tabledit-save-button').prop('disabled', true);

        if (input1 != "" && input2 != "") {
            $('.tabledit-save-button').attr(
               {
                   "title": "Already Saved"
               });
        }
        else {
            $('.tabledit-save-button').attr(
               {
                   "title": "Fill in Fields"
               });
        }

        //table functionality on user changes
        $(".tabledit-input").on("keyup change input", function () {

            var table = document.getElementById('training');
            var rowIndex = $(this).closest('td').parent()[0].sectionRowIndex;
            var input1 = table.rows[rowIndex].cells[1].children[1].value;
            var input2 = table.rows[rowIndex].cells[2].children[1].value;

            if (input1 != "" && input2 != "") {

                if (input1.length > 9 && input1.match(/^\d+$/))
                {
                    $('.tabledit-save-button').prop('disabled', false);
                    $('.tabledit-save-button').attr(
                           {
                               "title": "Save"
                           });
                }
                else
                {
                    $('.tabledit-save-button').prop('disabled', true);
                    $('.tabledit-save-button').attr(
                           {
                               "title": "Case Number Incorrect"
                           });
                }

            }
            else {
                $('.tabledit-save-button').prop('disabled', true);
                $('.tabledit-save-button').attr(
                       {
                           "title": "Fill in Fields"
                       });
            }
        });
    });


    // ------------------------------------------------------------ //
    // ------------------ Tabledit Save Click Event --------------- //
    // ------------------------------------------------------------ //

    $('.tabledit-save-button').click(function () {

        //get table row details
        var table = document.getElementById('training');
        var rowIndex = $(this).closest('td').parent()[0].sectionRowIndex;
        var input0 = table.rows[rowIndex].cells[0].innerText;
        var input1 = table.rows[rowIndex].cells[1].children[1].value;
        var input2 = table.rows[rowIndex].cells[2].children[1].value;
        var input3 = table.rows[rowIndex].cells[3].innerText;
        var input4 = table.rows[rowIndex].cells[4].innerText;

        if (input1 != "" && input2 != "") {
            table.rows[rowIndex].cells[3].innerText = "Completed";
            table.rows[rowIndex].cells[4].innerText = "Awaiting Approval";
            input3 = table.rows[rowIndex].cells[3].innerText;
            input4 = table.rows[rowIndex].cells[4].innerText;
        }

        PageMethods.sqlInsertCaseNumber(input0, input1, input2, input3, input4);

    });
});