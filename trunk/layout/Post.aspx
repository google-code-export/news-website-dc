<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<asp:Content ContentPlaceHolderID="extraHead" Runat="Server">    
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:DetailedPostItem AllowComments="true" runat="server" />
    <nsn:CommentBox runat="server" />
    <nsn:RelatedPostList runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:FocusPostsPortlet runat="server" />
</asp:Content>