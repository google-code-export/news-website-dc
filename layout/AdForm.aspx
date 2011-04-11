<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<script runat="server">

</script>

<asp:Content ContentPlaceHolderID="extraHead" Runat="Server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:AdFormBox runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:AdBoxList runat="server" />
</asp:Content>

