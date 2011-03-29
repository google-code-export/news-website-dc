<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecialTargetManagement.aspx.cs" Inherits="NewsVn.Web.Modules.SpecialTargetManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/plugins/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../Scripts/plugins/jquery.autocomplete.js" type="text/javascript"></script>
    
    <script>
        $(document).ready(function () {
            $("#<%=txtSearch.ClientID%>").autocomplete('Handler1.ashx');
        });     
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
    </form>
</body>
</html>
