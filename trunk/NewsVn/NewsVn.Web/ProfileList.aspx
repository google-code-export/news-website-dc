<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="ProfileList.aspx.cs" Inherits="NewsVn.Web.ProfileList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:UserProfileList runat="server" id="pletUserProfileList" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:ProfileSearchBox runat="server" />
	<nsn:RandomProfileBox runat="server" id="pletRandomProfile" />
</asp:Content>