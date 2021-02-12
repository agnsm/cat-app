
const menu = document.getElementsByClassName("nav-link");
const pages = ["CatImage", "CatGif", "CatFact"];
window.addEventListener("load", function (e) {
    let pathArray = this.location.pathname.split("/");
    let page = pathArray[2];
    for (let i = 0; i < pages.length; i++) {
        if (page == pages[i]) {
            menu[i].classList.add("active-page");
            let catIcon = menu[i].nextElementSibling;
            //catIcon.classList.add("active-page");
            //console.log(menu[i].childNodes);
        }
    }
}, false);

/*menu.forEach(function (option) {
    option.addEventListener("click", function (e) {
        //e.target.classList.add("ul > li > a:hover::after");
        console.log(e.target.children[0]);
    }, false);
});*/

$(document).ready(function () {
    $('.js-tilt').tilt({
        perspective: 2000,
        scale: 1.1
    });
});

