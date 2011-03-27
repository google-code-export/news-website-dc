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
    <nsn:LatestPostsPortlet CssClass="right" ClearLayout="true" NoCategoryName="true" runat="server" />
    <nsn:CategorizedPostList runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
    <nsn:FocusPostsPortlet runat="server" />
</asp:Content>

