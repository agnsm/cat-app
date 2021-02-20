
const menu = document.getElementsByClassName("nav-link");
const pages = ["CatImage", "CatGif", "CatFact"];
window.addEventListener("load", function (e) {
    let pathArray = this.location.pathname.split("/");
    let page = pathArray[2];
    for (let i = 0; i < pages.length; i++) {
        if (page == pages[i]) {
            menu[i].classList.add("active-page");
        }
    }
}, false);


$(document).ready(function () {
    $('.js-tilt').tilt({
        perspective: 2000,
        scale: 1.1
    });

    $(".btn-next").click(function (e) {
        e.preventDefault();
        $(".view-async > img").fadeOut().delay(3000).fadeIn();
        $(".view-async > p").fadeOut().delay(1000).fadeIn();
        $(".navbar-toggler").attr("aria-expanded", "false");
        $(".navbar-collapse").removeClass("show");
        $("body").css("overflow", "hidden");
        switch (window.location.pathname.split("/")[2]) {
            case pages[0]:
                $.get("ImageViewComponent", function (data) {
                    $(".view-async").html(data);
                    setTimeout(() => { e.target.blur(); }, 1000);
                });
                break;
            case pages[1]:
                $.get("GifViewComponent", function (data) {
                    $(".view-async").html(data);
                    setTimeout(() => { e.target.blur(); }, 1000);
                });
                break;
            case pages[2]:
                $.get("FactViewComponent", function (data) {
                    $(".view-async").html(data);
                    setTimeout(() => { e.target.blur(); }, 200);
                });
                break;
            default: break;
        }
    });

    $(".navbar-toggler-icon").click(function (e) {
        let state = $(".navbar-toggler").attr("aria-expanded");
        if (state == "false")
            $("body").css("overflow", "auto");
        else
            $("body").css("overflow", "hidden");

    });
});
