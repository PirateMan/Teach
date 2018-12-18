$(document).ready(function () {


    $("#approvalButton").click(function () {

        //table
        var tableControl = document.getElementById('training');

        //currently checked rows
        var selectedRows = $('#training').find('tbody').find('tr').has('input[type=checkbox]:checked')

        //iterate over selected rows
        for (var i = 0; i < selectedRows.Length; i++) {
            var rowIndex = selectedRows[i].rowIndex;
            var rowID = "#Repeater1_tableRow_" + rowIndex;

            $(rowID).Style.Add("background-color", "#aee666");
            $(rowID).Style.Add("color", "#000");
        }

    });

});