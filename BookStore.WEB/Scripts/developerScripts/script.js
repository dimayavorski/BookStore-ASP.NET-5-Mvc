
$(document).ready(function () {
    var navPos, winPos, navHeight;
    //getting position of nav
    function getPosition() {
        navPos = $("#nav").offset().top;
        navHeight = $("#nav").outerHeight(true);
    };
    getPosition();
    $(window).resize(getPosition);
    $("<div class='clone-nav'></div>").insertBefore("nav").css("height", navHeight).hide();
    //getting position of scrollbar
    $(window).scroll(function () {
        winPos = $(window).scrollTop();
        if (winPos >= navPos) {
            $("#nav").addClass("fixed");
            $(".clone-nav").show();
        }
        else {
            $("#nav").removeClass("fixed");
            $(".clone-nav").hide();
        }
    });
    //left nav 
    $("#navbarHidden").hide();
});


$(document).ready(function () {
    $("#success").removeClass("hidden");
    $("#success").hide();
})
//Show success dialog and then hide
function OnSuccess() {
    $('#success').show(1000, function () {
        setTimeout(function () {
            $('#success').hide(500);
        }, 1000);
    });

}
//autocomplete for searching input
$(function () {
    $("[data-autocomplete-source]").each(function () {
        var target = $(this);
        target.autocomplete({ source: target.attr("data-autocomplete-source") });

    });
});