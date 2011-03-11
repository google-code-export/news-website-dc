<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<asp:Content ContentPlaceHolderID="extraHead" runat="server">
    <link href="<%= Page.ResolveUrl("~/styles/nivo.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.nivo.slider.pack.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#nivo").nivoSlider({ directionNav: false, width: 340 });
        });
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SpecialPostsPortlet CssClass="left" runat="server" />
    <nsn:LatestPostsPortlet CssClass="right" ClearLayout="true" runat="server" />
    <nsn:SpecialEventsPortlet runat="server" />
    <nsn:PostsPortlet Title="Kinh tế" Figure="121" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Xã hội" Figure="215" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:PostsPortlet Title="Văn hóa" Figure="446" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Thể thao" Figure="1156" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:PostsPortlet Title="Góc Teen" Figure="145" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Khoa học" Figure="567" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:PostsPortlet Title="Du lịch - Ẩm thực" Figure="2125" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Tình yêu - Gia đình" Figure="1124" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:PostsPortlet Title="Rao nhanh" Figure="314" CssClass="left" runat="server" />
    <nsn:PostsPortlet Title="Thư giãn" Figure="6554" CssClass="right" ClearLayout="true" runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>