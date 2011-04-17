<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<script runat="server">

</script>

<asp:Content ContentPlaceHolderID="extraHead" Runat="Server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:QuickSearchResult runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:QuickSearchBox runat="server" />
    <nsn:AdBoxList runat="server" />
</asp:Content>