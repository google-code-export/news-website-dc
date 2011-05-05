<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.EditPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">

</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SiteAdmin_UpdatePost AllowEdit="true" runat="server" />
</asp:Content>
