<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SysAdmin/SysAdmin.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="NewsVn.Web.Account.SysAdmin.User.AddUser" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="<%= Page.ResolveUrl("~/styles/validation.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine-vi.js") %>" type="text/javascript"></script>    
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div class="portlet">
        <h2>Thêm tài khoản mới</h2>
        <nsn:SysAdmin_UpdateUser runat="server" />
    </div>
</asp:Content>
