$(document).ready(function () {



    $("body").on("click", "a", function () {
        $("a").toggleClass("active")
        $(this).addClass("active")
    })

})