$(document).ready(function () {

    /* ----------------------------------------------- */
    /* ------------- Table Ammendment ---------------- */
    /* ----------------------------------------------- */

    $("#training").ready(function () {
        $(this).addClass('table table-bordered');
    });



    /* ----------------------------------------------- */
    /* --------------- Delete Button ----------------- */
    /* ----------------------------------------------- */
    
    $('#training').on('click', 'button.btn-danger', function () {

        //toggle class
        $(this).toggleClass('clicked');

        //remove confirms
        $('#confirmDeleteButton').remove();

        // get id of clicked button
        var id = $(event.target)[0].id;
        var buttonclicked = document.getElementById(id);

        
        if(buttonclicked.className == "btn btn-sm btn-danger clicked")
        {
            // add confirm button
            var Button = document.createElement("BUTTON");
            Button.className = "btn btn-sm btn-success confirm";
            Button.id = "confirmDeleteButton";
            Button.innerHTML = "Confirm <i class='glyphicon glyphicon-ok'>"
            Button.onclick = function () {

                //get task name
                var table = document.getElementById('training');
                var rowIndex = $(this).closest('td').parent()[0].sectionRowIndex;
                var task = table.rows[rowIndex].cells[0].children[0].innerText;
                var dbTable = $("#signOffEditList option:selected").text();

                //call aspx function with task name
                PageMethods.deleteTask(dbTable, task);

                table.deleteRow(rowIndex);
            }
            document.getElementById(id).parentElement.appendChild(Button);

            //remove other clicked buttons if clicked on a second button, and reset them to unclicked
            var elementArray = document.getElementsByClassName("btn btn-sm btn-danger clicked");

            for (var i = (elementArray.length - 1) ; i >= 0; i--) {
                elementArray[i].className = "btn btn-sm btn-danger";
            }

            //add current button class as clicked
            buttonclicked.className = "btn btn-sm btn-danger clicked";
        }

    });


    /* ----------------------------------------------- */
    /* ---------------- Add new Item ----------------- */
    /* ----------------------------------------------- */

    $('button.addItem').click(function () {

        //toggle class
        $(this).toggleClass('clicked');

        // get id of clicked button
        var id = $(event.target)[0].id;
        var buttonclicked = document.getElementById(id);

        
        if (buttonclicked.className == "btn btn-sm btn-success addItem clicked")
        {
            var div = document.createElement('div');
            div.className = 'inputRow';
            div.id = 'inputRowID';

            div.innerHTML =
                '<div class="col-md-10 noPaddingLeft"> <input id="taskInput" type="text" value="" class="form-control" maxlength="200"/> </div>\
                 <div class="col-md-2 noPaddingLeft"><button id="submitButton" class="btn btn-sm btn-success submit" type="button" disabled><i class="glyphicon glyphicon-ok"></i> Submit</button></div>';

            document.getElementById('additemContainer').appendChild(div);
        }

        if (buttonclicked.className == "btn btn-sm btn-success addItem")
        {
            $(inputRowID).remove();
        }

        var buttonclicked = document.getElementById(id);


    });



    /* ----------------------------------------------- */
    /* ---------------- Add new Item ----------------- */
    /* ----------------------------------------------- */

    // on click for dynamically created
    $('#additemContainer').on("click", "#submitButton", function () {

        var innerText = $('#taskInput').val();
        var dbTable = $("#signOffEditList option:selected").text();
        
       if (innerText != "") {
           PageMethods.insert(dbTable, innerText);
       }

       AddRowToTable(innerText, dbTable);

    });


    function AddRowToTable(innerText, dbTable) {

        var table = document.getElementById("training");
        var rowCount = table.rows.length;
        var row = table.insertRow(rowCount);
        row.id = "Repeater1_tableRow_" + rowCount;
        var cell = row.insertCell(0);
        cell.innerHTML = "<span id='Repeater1_Label1_" + rowCount + "'>" + innerText + "</span>";
        var cell2 = row.insertCell(1);
        cell2.innerHTML = "<td id='deleteButton'><button id='idVariableButton' class='btn btn-sm btn-danger' runat='server' type='button'>Delete <i class='glyphicon glyphicon-trash'></i></button></td>".replace("idVariable", "Repeater1_deleteB_" + rowCount);
        
        $('#taskInput').val('');
    }


    $(document).on('keyup change input', "input#taskInput", function () {

        var value = $('#taskInput').val();

        if (value != "")
        {
            $('button#submitButton').prop('disabled', false);
            $('button#submitButton').attr(
                           {
                               "data-toggle": "tooltip",
                               "data-placement": "top",
                               "title": "Submit"
                           });
        }
        else {
            $('button#submitButton').prop('disabled', true);
            $('button#submitButton').attr(
                           {
                               "data-toggle": "tooltip",
                               "data-placement": "top",
                               "title": "Field cant be blank"
                           });
            }
    });

});