
const logo = document.getElementsByClassName("navbar-brand")[0];
logo.addEventListener("mouseenter", function (e) {
    e.target.style.letterSpacing = "2px";
    }, false);
logo.addEventListener("mouseleave", function (e) {
    e.target.style.letterSpacing = "";
}, false);

const catImage = document.getElementsByClassName(".js-tilt")[0];
logo.addEventListener("mouseenter", function (e) {
    e.target.style.letterSpacing = "2px";
}, false);
logo.addEventListener("mouseleave", function (e) {
    e.target.style.letterSpacing = "";
}, false);

$(document).ready(function () {
    $('.js-tilt').tilt({
        perspective: 2000,
        scale: 1.1
    });
});

