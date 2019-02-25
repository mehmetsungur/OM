!function (e) {
    "use strict"; var a = function () { }; a.prototype.createBarChart = function (e, a, t, r, o, i) { Morris.Bar({ element: e, data: a, xkey: t, ykeys: r, labels: o, hideHover: "auto", resize: !0, gridLineColor: "#eeeeee", barSizeRatio: .2, barColors: i }) }, a.prototype.createAreaChartDotted = function (e, a, t, r, o, i, n, s, l, y) { Morris.Area({ element: e, pointSize: 3, lineWidth: 1, data: r, xkey: o, ykeys: i, labels: n, hideHover: "auto", pointFillColors: s, pointStrokeColors: l, resize: !0, smooth: !1, gridLineColor: "#eef0f2", lineColors: y }) }, a.prototype.createDonutChart = function (e, a, t) { Morris.Donut({ element: e, data: a, barSize: .2, resize: !0, colors: t }) }, a.prototype.init = function () {
        this.createBarChart("morris-bar-example", [
            { y: "Ocak", a: $("#TotalPriceMonthCavcuJan").val(), b: $("#TotalPriceMonthOorkunJan").val() },
            { y: "Subat", a: $("#TotalPriceMonthCavcuFeb").val(), b: $("#TotalPriceMonthOorkunFeb").val() },
            { y: "Mart", a: $("#TotalPriceMonthCavcuMar").val(), b: $("#TotalPriceMonthOorkunMar").val() },
            { y: "Nisan", a: $("#TotalPriceMonthCavcuApr").val(), b: $("#TotalPriceMonthOorkunApr").val() },
            { y: "Mayis", a: $("#TotalPriceMonthCavcuMay").val(), b: $("#TotalPriceMonthOorkunMay").val() },
            { y: "Haziran", a: $("#TotalPriceMonthCavcuJune").val(), b: $("#TotalPriceMonthOorkunJune").val() },
            { y: "Temmuz", a: $("#TotalPriceMonthCavcuJuly").val(), b: $("#TotalPriceMonthOorkunJuly").val() },
            { y: "Agustos", a: $("#TotalPriceMonthCavcuAgus").val(), b: $("#TotalPriceMonthOorkunAgus").val() },
            { y: "Eylul", a: $("#TotalPriceMonthCavcuSep").val(), b: $("#TotalPriceMonthOorkunSep").val() },
            { y: "Ekim", a: $("#TotalPriceMonthCavcuOct").val(), b: $("#TotalPriceMonthOorkunOct").val() },
            { y: "Kasim", a: $("#TotalPriceMonthCavcuNov").val(), b: $("#TotalPriceMonthOorkunNov").val() },
            { y: "Aralik", a: $("#TotalPriceMonthCavcuDec").val(), b: $("#TotalPriceMonthOorkunDec").val() }],
            "y",
            ["a", "b"],
            ["Caglar","Okan"],
            ["#02c0ce"]);
        this.createAreaChartDotted("morris-area-with-dotted", 0, 0, [
            { y: "2017", a: $("#TotalPriceYearCavcu2017").val(), b: $("#TotalPriceYearOorkun2017").val() },
            { y: "2018", a: $("#TotalPriceYearCavcu2018").val(), b: $("#TotalPriceYearOorkun2018").val() },
            { y: "2019", a: $("#TotalPriceYearCavcu2019").val(), b: $("#TotalPriceYearOorkun2019").val() },
            { y: "2020", a: $("#TotalPriceYearCavcu2020").val(), b: $("#TotalPriceYearOorkun2020").val() }],
            "y",
            ["a", "b"],
            ["Caglar", "Okan"],
            ["#ffffff"],
            ["#999999"],
            ["#4a81d4", "#e3eaef"]);
        this.createDonutChart("morris-donut-example", [
            { label: " Toplam ₺ ", value: $("#TotalPriceDaily").val() },
            { label: " Okan ", value: $("#TotalPriceDailyOorkun").val() },
            { label: " Caglar ", value: $("#TotalPriceDailyCavcu").val() }],
            ["#4fc6e1", "#6658dd", "#ebeff2"])
    }, e.Dashboard4 = new a, e.Dashboard4.Constructor = a
}(window.jQuery),
    function (e) {
        "use strict";
        e.Dashboard4.init()
    }(window.jQuery);