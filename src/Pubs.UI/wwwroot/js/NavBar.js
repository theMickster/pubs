function setNavbarPadding() {
    var windowWidth = $(window).width();

    if (windowWidth <= 992) {
        $("#pubs-nav-main-menu li").removeClass("pe-2");
        $("#pubs-nav-main-menu li").removeClass("pe-3");
        $("#pubs-nav-main-menu li").removeClass("pe-4");

        $("#pubs-nav-bar-brand").removeClass("pe-3");
        $("#pubs-nav-bar-brand").removeClass("pe-4");
        $("#pubs-nav-bar-brand").removeClass("pe-5");
    }

    if (windowWidth >= 992 && windowWidth < 1100) {
        $("#pubs-nav-main-menu li").addClass("pe-2");
        $("#pubs-nav-main-menu li").removeClass("pe-3");
        $("#pubs-nav-main-menu li").removeClass("pe-4");

        $("#pubs-nav-bar-brand").addClass("pe-3");
        $("#pubs-nav-bar-brand").removeClass("pe-4");
        $("#pubs-nav-bar-brand").removeClass("pe-5");
    }

    if (windowWidth >= 1100 && windowWidth < 1400) {
        $("#pubs-nav-main-menu li").removeClass("pe-2");
        $("#pubs-nav-main-menu li").addClass("pe-3");
        $("#pubs-nav-main-menu li").removeClass("pe-4");

        $("#pubs-nav-bar-brand").removeClass("pe-3");
        $("#pubs-nav-bar-brand").addClass("pe-4");
        $("#pubs-nav-bar-brand").removeClass("pe-5");
    }
    if (windowWidth > 1400) {
        $("#pubs-nav-main-menu li").removeClass("pe-2");
        $("#pubs-nav-main-menu li").removeClass("pe-3");
        $("#pubs-nav-main-menu li").addClass("pe-4");

        $("#pubs-nav-bar-brand").removeClass("pe-3");
        $("#pubs-nav-bar-brand").removeClass("pe-4");
        $("#pubs-nav-bar-brand").addClass("pe-5");
    }
}

$(document).ready(function () {
    setNavbarPadding();

    $(window).on('resize', function () {
        setNavbarPadding();
    });
});