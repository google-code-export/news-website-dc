<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<asp:Content ContentPlaceHolderID="extraHead" runat="server">
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
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SpecialPostsPortlet CssClass="left" runat="server" />
    <nsn:LatestPostsPortlet CssClass="right" ClearLayout="true" runat="server" />
    <nsn:SpecialEventsPortlet runat="server" />
    <nsn:PostsPortlet Title="Kinh tế" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Xã hội" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:PostsPortlet Title="Văn hóa" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Thể thao" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:PostsPortlet Title="Góc Teen" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Khoa học" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:PostsPortlet Title="Du lịch - Ẩm thực" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Tình yêu - Gia đình" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:PostsPortlet Title="Thư giãn" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Rao nhanh" NoComments="true" CssClass="right" ClearLayout="true" runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
    <nsn:QuickSearchBox runat="server" />
    <nsn:AdBoxList runat="server" />
	<nsn:HotVideoList runat="server" />
    <nsn:SideTabsBox runat="server" />
</asp:Content>