<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AddPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.AddPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="<%= Page.ResolveUrl("~/styles/validation.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine-vi.js") %>" type="text/javascript"></script>    
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SiteAdmin_UpdatePost runat="server" />
</asp:Content>
