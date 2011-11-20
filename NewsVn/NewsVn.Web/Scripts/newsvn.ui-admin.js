/// <reference path="plugins/jquery-1.4.2-vsdoc.js" />

var serviceUrl = "/Utils/NewsVnService.asmx/";

$.ajaxSetup({
    type: "POST",
    contentType: "application/json; charset=utf-8",
    //dataType: "json",//duynp fix bug autocomplete
    data: "{}"
});

$(function () {
    //input
    $(":text,:password,textarea").addClass("textbox");
    $(":checkbox").addClass("checkbox");
    $(":checkbox").next("label").addClass("checkbox-label");

    //button
    $(":button, .button").button();
    $(".button-add").button({
        icons: {
            primary: "ui-icon-plusthick"
        }
    });
    $(".button-edit").button({
        icons: {
            primary: "ui-icon-pencil"
        }
    }).click(function (e) {
        if ($(".ui-table tr td:first-child :checked").size() != 1) e.preventDefault();
    });
    $(".button-delete").button({
        icons: {
            primary: "ui-icon-trash"
        }
    });
    $(".button-toggle").button({
        icons: {
            primary: "ui-icon-transferthick-e-w"
        }
    });
    $(".button-refresh").button({
        icons: {
            primary: "ui-icon-arrowrefresh-1-s"
        }
    });
    $(".button-filter").button({
        icons: {
            primary: "ui-icon-lightbulb"
        }
    });
    $(".button-help").button({
        icons: {
            primary: "ui-icon-help"
        }
    });
    $(".button-ok").button({
        icons: {
            primary: "ui-icon-check"
        }
    });
    $(".button-cancel").button({
        icons: {
            primary: "ui-icon-closethick"
        }
    });
    $(".button-back").button({
        icons: {
            primary: "ui-icon-arrowthick-1-w"
        }
    });
    $(".button-key, .button-reset").button({
        icons: {
            primary: "ui-icon-key"
        }
    });
    $(".button-clear").button({
        icons: {
            primary: "ui-icon-circle-close"
        }
    });

    //datepicker
    $(".datepicker").datepicker({
        showOn: "button",
        //buttonImage: "../images/icons/calendar.png",
        buttonImage: $("[id$=datePickerIcon]").attr("src"),
        buttonImageOnly: true
    }, $.datepicker.regional["vi"]);

    $(".dropdown").each(function () {
        $(this).selectmenu({ width: $(this).width() });
        $(this).next(".ui-selectmenu").addClass("select");
        $(this).next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $("#" + $(this).attr("id") + "-menu").width($(this).width() + 6);
    });

    $(".dialog").dialog({
        autoOpen: false,
        resizable: false,
        modal: true,
        width: "auto",
        open: function (e) {
            $(this).find(".button-cancel").bind("click", { dialog: e.target }, function (event) {
                $(event.data.dialog).dialog("close");
            });
        }
    });

    $("[class*=dialog-trigger]").click(function () {
        var classString = $(this).attr("class");
        var splittees = classString.split(/\s|\[|\]/);
        var dialogId = "";
        for (var i = 0; i < splittees.length; i++) {
            if (splittees[i - 1] == "dialog-trigger") {
                dialogId = splittees[i];
                break;
            }
        }
        var targetDialog = $(".dialog#" + dialogId);
        var targetDialogTitle = $(this).attr("dialog-title");
        targetDialog.bind("dialogopen", { action: $(this).attr("dialog-action") }, function (e) {
            $(this).find("#action").val(e.data.action);
        });
        if (targetDialogTitle != null) {
            targetDialog.dialog({ title: targetDialogTitle });
        }
        targetDialog.dialog("open");
    });

    fixLayoutContent();
    refineTableStyles();
    refineSideMenu();

    $(window).resize(function () {
        fixLayoutContent();
    });
});

function fixLayoutContent() {
    $("#main_content").css({ width: $(window).width() - $("#side_content").width() - 30 });
    $("#side_content").css({ height: $(window).height() });
    $(".ui-table-toolbar").css({ width: $("#main_content").width() + "px" });
    $(".ui-table:last").css({ "margin-top": $(".ui-table-toolbar").height() + 10 });
    $(".portlet").css({ width: $(".ui-form.main").width() });
}

function refineTableStyles() {
    $(".ui-table tr:first-child:has(th)").addClass("ui-widget-header");
    $(".ui-table tr:even:not(:has(th))").addClass("even");
    $(".ui-table td").each(function () {
        if ($.trim($(this).html()) == "") {
            $(this).text("-");
        }
    });
    $(".ui-table tr:not(:has(th))").hover(function () {
        $(this).toggleClass("hover");
    });
    $(".ui-table tr:last-child").addClass("tail");
    $(".ui-table tr th:first-child :checkbox").change(function () {
        $(".ui-table tr td:first-child :checkbox").attr("checked", $(this).attr("checked"));
        if ($(this).is(":checked")) {
            $(".ui-table tr").addClass("focus");
        }
        else $(".ui-table tr").removeClass("focus");
    });
    $(".ui-table tr td:first-child :checkbox").change(function () {
        $(this).parents(".ui-table tr").toggleClass("focus");
        var checkedBoxes = $(".ui-table tr td:first-child :checkbox:checked");
        var headCheckBox = $(".ui-table tr th:first-child :checkbox");
        headCheckBox.attr("checked", checkedBoxes.size() == ($(".ui-table tr").size() - 1));
    });
}

function refineSideMenu() {
    var addIcons = function () {
        $(".side_main_menu").each(function () {
            if ($(this).find("ul").size() > 0) {
                if ($(this).find(":hidden").size() > 0) {
                    $(this).css({ "background": "url('data:application/octet-stream;base64,iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAYAAAA71pVKAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAIGNIUk0AAHolAACAgwAA+f8AAIDpAAB1MAAA6mAAADqYAAAXb5JfxUYAAABMSURBVHjaYvz//z8DuYCJgQIwcJpZsAnu5eeFBQQjAwMDg/PHz2TZ/J9SZ/+nyM9I3iBds/PHz4zkamYk19mMeCVHYPIEAAAA//8DAH4HEBl2QzzOAAAAAElFTkSuQmCC') no-repeat 160px 6px" });
                } else {
                    $(this).css({ "background": "url('data:application/octet-stream;base64,iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAYAAAA71pVKAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAIGNIUk0AAHolAACAgwAA+f8AAIDpAAB1MAAA6mAAADqYAAAXb5JfxUYAAABHSURBVHjaYvz//z8DuYCJgQIwRDWzoAvs5efFGYLOHz8z0tTZjDjUMhLrZ0aiDPz//z9OvIeP5z8+ecbRFEYaAAAAAP//AwDHvzXGNyZXOAAAAABJRU5ErkJggg%3D%3D') no-repeat 160px 6px" });
                }
            }
        });
    };    
    $(".side_main_menu").click(function () {
        $(this).find("ul").slideToggle(500, function () {
            addIcons();
        });
    });
    $(".side_main_menu a").click(function (e) {
        e.stopPropagation();
    });
    $(".side_main_menu").each(function () {
        if ($(this).children("a").hasClass("selected") || $(this).find("li a").hasClass("selected")) {
            $(this).find("ul").show();
        }
    });
    addIcons();
}

function confirmAction(msg) {
    var selectedRows = $(".ui-table tr td:first-child :checked").size();
    if (selectedRows > 0) { return confirm(msg); }
    return false;
}