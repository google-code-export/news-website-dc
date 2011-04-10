<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<asp:Content ContentPlaceHolderID="extraHead" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <nsn:CategorizedAdPostList runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
    <nsn:AdSearchBox runat="server" />
    <nsn:AdBoxList runat="server" />
</asp:Content>

