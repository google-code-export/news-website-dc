<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="NewsVn.Web.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:UserProfileDetails runat="server" ID="pletUserProfileDetails" />
    <nsn:ProfileCommentBox runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:ProfileSearchBox runat="server" />
    <nsn:UserConversationBox runat="server" />
</asp:Content>
