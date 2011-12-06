<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AutoFetchPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.AutoFetchPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <asp:DropDownList ID="ddlFetchSite" runat="server" />
    <asp:DropDownList ID="ddlFetchCategory" runat="server" />
    <a id="btnShowList" class="button">Lấy tin</a>
    <a id="btnAddItems" class="button">Cập nhật</a>
</asp:Content>
