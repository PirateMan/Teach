
    $(Document).ready(function () {

        $('#optionSelectList_1').attr('disabled', 'disabled');

        $('input:checkbox').click(function () {

            if ($('#optionSelectList_0').is(':checked')) {
                $('#optionSelectList_1').removeAttr('disabled');  
            }
            else {
                $('#optionSelectList_1').attr('disabled', 'disabled');
                $("#optionSelectList_1").prop('checked', false);
            }
               
        });

    });
