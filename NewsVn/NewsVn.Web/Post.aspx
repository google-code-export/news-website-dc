﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="NewsVn.Web.Post" %>

<asp:Content ContentPlaceHolderID="extraHead" Runat="Server">  
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:DetailedPostItem AllowComments="true" runat="server" ID="pletPostDetail" />
    <nsn:CommentBox runat="server" ID="pletCommentBox" ListPageSize="1" /> 
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContentTop" Runat="Server">
    <nsn:FocusPostsPortlet ID="pletFocusPost" runat="server" />
</asp:Content>