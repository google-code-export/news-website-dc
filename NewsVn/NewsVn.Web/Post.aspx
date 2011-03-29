<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="NewsVn.Web.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" Runat="Server">  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:DetailedPostItem AllowComments="true" runat="server" id="pletPostDetail" />
    <nsn:CommentBox runat="server" id="pletCommentBox" /> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContentTop" Runat="Server">
    <nsn:FocusPostsPortlet ID="pletFocusPost" runat="server" />
</asp:Content>