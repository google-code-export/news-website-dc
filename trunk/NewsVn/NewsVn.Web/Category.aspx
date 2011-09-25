<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="NewsVn.Web.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" runat="server">
    <script type="text/javascript">
        $(function () {
            $(".portlet.left").each(function () {
                var rightPortlet = $(this).siblings(".portlet.right").eq(0);
                if ($(this).height() < rightPortlet.height()) {
                    $(this).css({ height: rightPortlet.height() });
                }
                else {
                    rightPortlet.css({ height: $(this).height() });
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
    <nsn:QuickSearchBox ID="QuickSearchBox1" runat="server" />
    <nsn:FocusPostsPortlet runat="server" ID="pletFocusPost" />
    <nsn:AdBoxList ID="AdBoxList1" runat="server" />
	<nsn:HotVideoList ID="HotVideoList1" runat="server" />
</asp:Content>

