var serviceUrl = "/Utils/NewsVnService.asmx/";

$.ajaxSetup({
    type: "POST",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    data: "{}"
});

$(function () {
    //input
    $(":text,:password,textarea").addClass("textbox");
    $(":checkbox").addClass("checkbox");
    $(":checkbox").next("label").addClass("checkbox-label");

    //button
    $(":button, .button").button();
    $(".button-login").button({
        icons: {
            primary: "ui-icon-key"
        }
    });
    $(".button-register").button({
        icons: {
            primary: "ui-icon-pencil"
        }
    });
    $(".button-search").button({
        icons: {
            primary: "ui-icon-search"
        }
    });
    $(".button-send").button({
        icons: {
            primary: "ui-icon-mail-closed"
        }
    });
    $(".button-ok").button({
        icons: {
            primary: "ui-icon-check"
        }
    });
    $(".button-cancel").button({
        icons: {
            primary: "ui-icon-cancel"
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

    //list
    $(".imagehead-list li:first-child").addClass("head");
    $(".imagehead-list li:last-child").addClass("tail");
});