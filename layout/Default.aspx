﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<asp:Content ContentPlaceHolderID="extraHead" runat="server">    
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
</asp:Content>