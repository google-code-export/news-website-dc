<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="ProfileSearchResult.aspx.cs" Inherits="NewsVn.Web.ProfileSearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:ProfileSearchResults ID="profileSearchResult" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:ProfileSearchBox runat="server" />
    <%--<nsn:RandomProfileBox runat="server" />--%>
</asp:Content>