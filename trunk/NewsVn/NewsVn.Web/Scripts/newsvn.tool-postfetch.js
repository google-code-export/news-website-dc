/// <reference path="plugins/jquery-1.4.2-vsdoc.js" />

var fetchService = "/Utils/PostFetchWebService.asmx/";

$(function () {
    //getSetting();

    $("#btnShowList").click(function () {
        getRawItemList();
    });
});

function getSetting() {
    $.ajax({
        url: fetchService + "RequestSetting",
        data: "{ siteID: 1, categoryID: 1 }",
        success: function (rs) {

        }
    });
}

function getRawItemList() {
    $.ajax({
        url: fetchService + "RequestRawPostItemList",
        data: "{ categoryUrl: 'http://hcm.megafun.vn/cuoc-song/' }",
        dataType: "html",
        success: function (rs) {

        }
    });
}