
function checkPasswordMatch() {
    var password = $("#passwordChoice").val();
    var confirmPassword = $("#passwordConfirm").val();
    document.getElementById('passwordCharacters').classList.remove("showDiv");
    document.getElementById('passwordCharacters').classList.add("hideDiv");

    if (password != confirmPassword)
        document.getElementById('passwordsMatch').classList.remove("showDiv"),
        document.getElementById('passwordsMatch').classList.add("hideDiv"),
        document.getElementById('passwordsDontMatch').classList.add("showDiv");
    else
        document.getElementById('passwordsDontMatch').classList.remove("showDiv"),
        document.getElementById('passwordsDontMatch').classList.add("hideDiv"),
        document.getElementById('passwordsMatch').classList.add("showDiv");
}

$(document).ready(function () {
    $("#passwordChoice, #passwordConfirm").keyup(checkPasswordMatch);
});