function getValues() {
    $.get("/Name", function (data) {
        $(".Name").html(data + " - ");
    });
    $.get("/Source", function (data) {
        $(".Source").html(data);
    });
    $.get("/Licence", function (data) {
        $(".Licence").html(data);
    });
}