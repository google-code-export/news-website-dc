/// <reference path="plugins/jquery-1.4.2-vsdoc.js" />

$(function () {
    $(".button-add").button({
        icons: {
            primary: "ui-icon-plusthick"
        }
    });
    $(".button-edit").button({
        icons: {
            primary: "ui-icon-pencil"
        }
    });
    $(".button-delete").button({
        icons: {
            primary: "ui-icon-trash"
        }
    });
    $(".button-refresh").button({
        icons: {
            primary: "ui-icon-arrowrefresh-1-s"
        }
    });

    $(".dropdown").each(function () {
        $(this).selectmenu({ width: $(this).width() });
        $(this).next(".ui-selectmenu").addClass("select");
        $(this).next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $("#" + $(this).attr("id") + "-menu").width($(this).width() + 6);
    });

    fixLayoutContent();
    refineTableStyles();

    $(window).resize(function () {
        fixLayoutContent();
    });
});

function fixLayoutContent() {
    $("#main_content").css({ width: $(window).width() - $("#side_content").width() - 40 });
    $(".ui-table-toolbar").css({ width: $(".ui-table-toolbar + .ui-table").width() + 2 });
    $(".ui-table").css({ "margin-top": $(".ui-table-toolbar").height() + 10 });
}

function refineTableStyles() {    
    $(".ui-table td").each(function () {
        if ($.trim($(this).html()) == "") {
            $(this).text("-").css({ "text-align": "center" });
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