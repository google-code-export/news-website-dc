<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="AdFormBox.aspx.cs" Inherits="NewsVn.Web.AdFormBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:AdFormBox runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" Runat="Server">
         <div id="adboxArea" runat="server"></div>
</asp:Content>