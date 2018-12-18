$(document).ready(function () {

    // ------------------------------------------------------------ //
    // ---------------------- DatePicker Plugin ------------------- //
    // ------------------------------------------------------------ //

    $('.myDate').unbind();
    $('.myDate').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true
    });

});
