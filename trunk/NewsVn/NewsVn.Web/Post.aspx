<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="NewsVn.Web.Post" %>

<asp:Content ContentPlaceHolderID="extraHead" Runat="Server">  
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:DetailedPostItem AllowComments="true" runat="server" ID="pletPostDetail" />
    <nsn:CommentBox runat="server" ID="pletCommentBox" ListPageSize="10" /> 
    <nsn:RelatedPostList runat="server" id="pletRelateionPostList" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:QuickSearchBox runat="server" />
    <nsn:FocusPostsPortlet ID="pletFocusPost" runat="server" />
     <div id="adboxArea" runat="server"></div>
    <nsn:HotVideoList runat="server" />
</asp:Content>