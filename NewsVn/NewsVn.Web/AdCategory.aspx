<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="AdCategory.aspx.cs" Inherits="NewsVn.Web.AdCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $(".portlet.left").each(function () {
                var rightPortlet = $(this).next(".portlet.right");
                if ($(this).height() < rightPortlet.height()) {
                    $(this).height(rightPortlet.height());
                }
                else if ($(this).height() > rightPortlet.height()) {
                    rightPortlet.height($(this).height());
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:SpecialAdPostsPortlet ID="pletSpecialAds" runat="server" />
    <nsn:AdGuideBox ID="AdGuideBox1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:AdSearchBox ID="AdSearchBox1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extraContent" runat="server">
    <div id="AdPostArea" runat="server"></div>
    <script type="text/javascript">

        $(function () {
            $("a[id=lnkCatTitle]").click(function () {
                var objContainer = $(this).parents("[id$=container]")
                var lnkOtherAds = $("#" + objContainer.attr("id") + " a[id$=lnkOthersAds]");
                lnkOtherAds.attr("href", "AdSubCategory.aspx?ct=" + $(this).children().val())
                getNewsAds($(this).children().val(), objContainer);
            });
        });

    function getNewsAds(ct, obj) {
        var dataObj = {AdsCatName: ct};
        $.ajax({
            url: serviceUrl + "getAdsByAdsCat",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
            success: function (result) {
                $("#" + obj.attr("id") + " table").html(result.d);
            }
        });
    }
    
    </script>
</asp:Content>
