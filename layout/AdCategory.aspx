<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<asp:Content ContentPlaceHolderID="extraHead" Runat="Server">
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
<asp:Content ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:SpecialAdPostsPortlet runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:AdSearchBox runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="extraContent" runat="server">
    <nsn:AdPostsPortlet Title="Nhà đất" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet Title="Ô tô - Xe máy" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:AdPostsPortlet Title="Làm đẹp" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet Title="Máy tính" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:AdPostsPortlet Title="Điện tử - Điện lạnh" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet Title="Điện thoại" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:AdPostsPortlet Title="Dịch vụ tại nhà" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet Title="Tuyển dụng" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:AdPostsPortlet Title="Thiết bị văn phòng" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet Title="Nhắn tin" CssClass="right" ClearLayout="true" runat="server" />
</asp:Content>