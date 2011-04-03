<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="NewsVn.Web.Category" %>

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
    <nsn:SpecialPostsPortlet ID="pletHotNews" CssClass="left" runat="server" />
    <nsn:LatestPostsPortlet ID="pletLatestNews" CssClass="right" ClearLayout="true" NoCategoryName="true" runat="server" />
    <nsn:CategorizedPostList runat="server" ID="pletCatePostList" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" runat="server">
    <nsn:FocusPostsPortlet runat="server" ID="pletFocusPost" />
    <nsn:AdBoxList ID="AdBoxList1" runat="server" />
	<nsn:HotVideoList ID="HotVideoList1" runat="server" />
</asp:Content>

