<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="AdPost.aspx.cs" Inherits="NewsVn.Web.AdPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:DetailedAdPostItem id="pletAdsDetail" runat="server" />
    <nsn:RelatedAdPostList ID="pletAdsRelated" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:AdSearchBox ID="AdSearchBox1" runat="server" />
    <div id="adboxArea" runat="server"></div>
</asp:Content>


