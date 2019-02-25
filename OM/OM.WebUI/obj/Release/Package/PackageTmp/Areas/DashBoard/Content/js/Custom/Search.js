jQuery.expr[':'].contains = function (a, i, m) {
    return jQuery(a).text().toUpperCase()
        .indexOf(m[3].toUpperCase()) >= 0;
};

$(document).ready(function () {
    $("#searchTags").keyup(function () {
        var value = $("#searchTags").val();
        if (value.length == 0) {
            $("#menuFull div").show();
        } else {
            $("#menuFull div").hide();
            $("#menuFull div:contains(" + value + ")").show();
        }
    });
});