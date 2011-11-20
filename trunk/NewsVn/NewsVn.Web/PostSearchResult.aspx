<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="PostSearchResult.aspx.cs" Inherits="NewsVn.Web.PostSearchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:QuickSearchResult runat="server" ID="pletSearchResult" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:QuickSearchBox ID="QuickSearchBox1" runat="server" />
   <div id="adboxArea" runat="server"></div>
</asp:Content>