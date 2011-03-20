$(function () {
    //text input
    $(":text,:password,textarea").addClass("textbox");

    //button
    $(":button, .button").button();

    //table
    $(".ui-table tr:first-child:has(th)").addClass("ui-widget-header");
    $(".ui-table tr:even:not(:first-child)").addClass("even");

    //datepicker
    $(".datepicker").datepicker({
        showOn: "button",
        buttonImage: "../images/icons/calendar.png",
        buttonImageOnly: true
    }, $.datepicker.regional["vi"]);
});