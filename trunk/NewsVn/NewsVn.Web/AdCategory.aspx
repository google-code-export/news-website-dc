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
</asp:Content>
