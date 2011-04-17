<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" %>

<script runat="server">

</script>

<asp:Content ContentPlaceHolderID="extraHead" Runat="Server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:UserProfileDetails runat="server" />
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:ProfileSearchBox runat="server" />
	<nsn:RandomProfileBox runat="server" />
</asp:Content>