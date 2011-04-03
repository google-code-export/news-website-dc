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