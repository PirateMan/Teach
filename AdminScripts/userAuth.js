
$(document).ready(function () {

    // --------------------------------------------------------------- //
    // ------------------------- CREATE TABLE ------------------------ //
    // --------------------------------------------------------------- //
    // create table with DataTables plugin

    $('#usersTable').DataTable();



    // --------------------------------------------------------------- //
    // ------------------------- TABLE EDIT -------------------------- //
    // --------------------------------------------------------------- //
    // Apply table edit to the table, every postback clear current
    // icons, function for first load and then function for every postback
    // remove css class that hides table after redendering in all plugins


    // first load function
    var tableditFirstLoad = (function () {

        var executed = false;
        return function () {
            if (!executed) {
                executed = true;

                $('#usersTable').Tabledit({

                    edit: {
                        class: 'btn btn-sm btn-default',
                        html: '<span class="glyphicon glyphicon-pencil"></span>',
                        action: 'edit'
                    },

                    columns: {
                        identifier: [0, 'id'],
                        editable: [[3, 'authorisation'], [4, 'adminRights']]
                    }
                });
            }
        };
    })();


    // load tabledit only once before calling draw.dt event
    tableditFirstLoad();


    // when datatables functions are used, ie pagination, sorting reloads the data
    $('#usersTable').on('draw.dt', function () {

        //remove tabledit toolbar for duplicates
        $('div.tabledit-toolbar').parent().remove();

        $(this).Tabledit({

            edit: {
                class: 'btn btn-sm btn-default',
                html: '<span class="glyphicon glyphicon-pencil"></span>',
                action: 'edit'
            },

            columns: {
                identifier: [0, 'id'],
                editable: [[3, 'authorisation'], [4, 'adminRights']]
            }

        });
    });



    // --------------------------------------------------------------- //
    // ------------------------- REMOVE CSS -------------------------- //
    // --------------------------------------------------------------- //
    // remove css class that hides table after redendering in all styles

    $('#dataTableWrapper').removeClass('dataTableParentHidden');



    // --------------------------------------------------------------- //
    // ---------------- TABLE EDIT CLICK FUNCTIONS ------------------- //
    // --------------------------------------------------------------- //

    // on save - update sql db
    $('#usersTable').on('click', '.tabledit-save-button', function () {

        try {
            var table = document.getElementById('usersTable');
            var rowIndex = $(this).closest('td').parent()[0].sectionRowIndex;
            rowIndex = rowIndex + 1;

            var username = table.rows[rowIndex].cells[2].innerText;
            var autho = table.rows[rowIndex].cells[3].children[1].value;
            var adminRights = table.rows[rowIndex].cells[4].children[1].value;

            PageMethods.sqlInsert(username, autho, adminRights);
        }
        catch (err) { }

    });




    // confirm click wait for c# return complete before refresh using ajax
    $('#usersTable').on('click', '.tabledit-confirm-button', function () {

        var table = document.getElementById('usersTable');
        var rowIndex = $(this).closest('td').parent()[0].sectionRowIndex;
        rowIndex = rowIndex + 1;
        var username = table.rows[rowIndex].cells[2].innerText;

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: "{'username' : '" + username + "'}",
            dataType: 'json',
            async: false,
            url: 'AuthoriseUser.aspx/deleteRecord',
            success: OnSuccess,
            error: OnError
        });

    });

    function OnSuccess(response) {
        window.location.reload();
    }

    //log errors if any - dbug purposes
    function OnError(xhr, textStatus, err) {
        console.log("readyState: " + xhr.readyState);
        console.log("responseText: " + xhr.responseText);
        console.log("status: " + xhr.status);
        console.log("text status: " + textStatus);
        console.log("error: " + err);
    }



    // on edit click - disable save button until edits made
    $('#usersTable').on('click', '.tabledit-edit-button', function () {

        var table = document.getElementById('usersTable');
        var rowIndex = $(this).closest('td').parent()[0].sectionRowIndex;
        rowIndex = rowIndex + 1;

        $('.tabledit-save-button').prop('disabled', true);

        $('.tabledit-save-button').attr(
           {
               "title": "No Changes made"
           });
    });


    //table functionality on user changes key up function
    $('#usersTable').on('keyup change input', '.tabledit-input', function () {

        var table = document.getElementById('usersTable');
        var rowIndex = $(this).closest('td').parent()[0].sectionRowIndex;
        rowIndex = rowIndex + 1;

        var input1 = table.rows[rowIndex].cells[3].children[1].value;
        var input2 = table.rows[rowIndex].cells[4].children[1].value;

        if ((input1 == "YES" || input1 == "NO") && (input2 == "YES" || input2 == "NO")) {
            $('.tabledit-save-button').prop('disabled', false);
            $('.tabledit-save-button').attr(
                   {
                       "title": "Save"
                   });
        }
        else {
            $('.tabledit-save-button').prop('disabled', true);
            $('.tabledit-save-button').attr(
                   {
                       "title": "Must Either Be 'YES' or 'NO'"
                   });
        }
    });


});