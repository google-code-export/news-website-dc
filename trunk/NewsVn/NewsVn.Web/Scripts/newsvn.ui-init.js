var serviceUrl = "Utils/NewsVnService.asmx/";

$.ajaxSetup({
    type: "POST",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    data: "{}"
});

$(function () {
    //text input
    $(":text,:password,textarea").addClass("textbox");

    //button
    $(":button, .button").button();
    $(".button-search").button({
        icons: {
            primary: "ui-icon-search"
        }
    });

    //table
    $(".ui-table tr:first-child:has(th)").addClass("ui-widget-header");
    $(".ui-table tr:even:not(:has(th))").addClass("even");

    //datepicker
    $(".datepicker").datepicker({
        showOn: "button",
        buttonImage: "../images/icons/calendar.png",
        buttonImageOnly: true
    }, $.datepicker.regional["vi"]);
});