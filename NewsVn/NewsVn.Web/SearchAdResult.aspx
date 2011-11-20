<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="SearchAdResult.aspx.cs" Inherits="NewsVn.Web.SearchAdResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <nsn:AdSearchResult ID="AdSearchResult1" runat="server" />
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" runat="server">
    <nsn:AdSearchBox ID="AdSearchBox1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extraContent" runat="server">
<div id="AdPostArea" runat="server"></div>
<div id="adboxArea" runat="server"></div>
    <script type="text/javascript">
        //set up other ads
        $(function () {
            $("a[id=lnkCatTitle]").click(function () {
                var objContainer = $(this).parents("[id$=container]")
                var lnkOtherAds = $("#" + objContainer.attr("id") + " a[id$=lnkOthersAds]");
                lnkOtherAds.attr("href", $("#<%=hidHostName.ClientID %>").val() + "rao-nhanh/" + $(this).children().val() + ".aspx");
                getNewsAds($(this).children().val(), objContainer);
            });
        });

        function getNewsAds(ct, obj) {
            var dataObj = { AdsCatName: ct };
            $.ajax({
                url: serviceUrl + "getAdsByAdsCat",
                data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
                success: function (result) {
                    $("#" + obj.attr("id") + " table").html(result.d);
                }
            });
        }
    
    </script>
    <asp:HiddenField runat="server" ID="hidHostName" Value="" />
</asp:Content>
