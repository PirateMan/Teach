$(document).ready(function () {
    $('.navbar a.dropdown-toggle').on('click', function (e) {

        var $el = $(this);
        var $parent = $(this).offsetParent(".dropdown-menu");
        $(this).parent("li").toggleClass('open');

        if (!$parent.parent().hasClass('nav')) {
            $el.next().css({ "top": $el[0].offsetTop - 8, "left": $parent.outerWidth() });
        }

        $('.nav li.open').not($(this).parents("li")).removeClass("open");

        return false;
    });
});