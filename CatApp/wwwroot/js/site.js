
const menu = document.getElementsByClassName("nav-link");
const pages = ["CatImage", "CatGif", "CatFact"];
window.addEventListener("load", function (e) {
    let pathArray = this.location.pathname.split("/");
    let page = pathArray[2];
    for (let i = 0; i < pages.length; i++) {
        if (page == pages[i]) {
            menu[i].classList.add("active-page");
            let catIcon = menu[i].nextElementSibling;
        }
    }
}, false);


$(document).ready(function () {
    $('.js-tilt').tilt({
        perspective: 2000,
        scale: 1.1
    });
});

