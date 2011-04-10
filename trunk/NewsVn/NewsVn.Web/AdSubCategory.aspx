<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="AdSubCategory.aspx.cs" Inherits="NewsVn.Web.AdSubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <nsn:CategorizedAdPostList runat="server" ID="pletCatAdsPost" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" runat="server">
    <nsn:AdSearchBox ID="AdSearchBox1" runat="server" />
    <nsn:AdBoxList ID="AdBoxList1" runat="server" />
</asp:Content>