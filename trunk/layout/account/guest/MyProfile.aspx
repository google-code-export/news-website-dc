<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<asp:Content ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:MyProfileDetails runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:RecentReceivedCommentBox runat="server" />
</asp:Content>

