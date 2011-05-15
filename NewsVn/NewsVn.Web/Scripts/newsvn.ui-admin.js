/// <reference path="plugins/jquery-1.4.2-vsdoc.js" />

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

    $(window).resize(function () {
        fixLayoutContent();
    });
});

function fixLayoutContent() {
    $("#main_content").css({ width: $(window).width() - $("#side_content").width() - 40 });
    $(".ui-table-toolbar").css({ width: $(".ui-table-toolbar + .ui-table, .ui-table-toolbar + div .ui-table").width() + 2 });
    $(".ui-table").css({ "margin-top": $(".ui-table-toolbar").height() + 10 });
    $(".portlet").css({ width: $(".ui-form.main").width() });
}

function refineTableStyles() {
    $(".ui-table tr:first-child:has(th)").addClass("ui-widget-header");
    $(".ui-table tr:even:not(:has(th))").addClass("even");
    $(".ui-table td").each(function () {
        if ($.trim($(this).html()) == "") {
            //$(this).text("-").css({ "text-align": "center" });
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

function confirmDelete() {
    if (checkSelectedRows()) {
        return confirm("Xóa những dòng được chọn?");
    }
    return false;
}

function checkSelectedRows() {
    return $(".ui-table tr td:first-child :checked").size() > 0;
}