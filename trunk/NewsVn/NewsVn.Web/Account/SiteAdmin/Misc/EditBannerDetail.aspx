<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="EditBannerDetail.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.AdPost.EditBannerDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideContent" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SiteAdmin_UpdateBannerDetail runat="server" />
</asp:Content>
