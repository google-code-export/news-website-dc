<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<asp:Content ContentPlaceHolderID="extraHead" Runat="Server">    
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:DetailedPostItem AllowComments="true" runat="server" />
    <nsn:CommentBox runat="server" />
    <nsn:RelatedPostList runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:QuickSearchBox runat="server" />        
    <nsn:FocusPostsPortlet runat="server" />
    <nsn:AdBoxList runat="server" />
    <nsn:HotVideoList runat="server" />
</asp:Content>