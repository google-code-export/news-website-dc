<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsVn.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SpecialPostsPortlet CssClass="left" runat="server" ID="pletHotNews" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
