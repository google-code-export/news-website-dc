<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuickSearchBox.ascx.cs" Inherits="NewsVn.Web.Modules.QuickSearchBox" %>
<script src="../Scripts/plugins/jquery.autocomplete.js" type="text/javascript"></script>
<link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        var initText = "Tìm nhanh...";
        var searchInput = $("#<%= txtSearch.ClientID %>");
        initSearchInput(initText, searchInput);
        searchInput.focus(function () {
            if (searchInput.val() == initText) {
                searchInput.val("");
                searchInput.css({ "font-style": "normal" });
            }
        });
        searchInput.blur(function () {
            if ($.trim(searchInput.val()) == "") {
                initSearchInput(initText, searchInput);
            }
        });
    });

    function initSearchInput(initText, searchInput) {
        searchInput.val(initText);
        searchInput.css({ "font-style": "italic" });
    }

    $(document).ready(function () {
        $("#<%=txtSearch.ClientID%>").autocomplete('AutoCompleteService.ashx');
    });      
</script>

<div class="side-part search portlet">
	<h2>Tìm kiếm</h2>
	<asp:TextBox ID="txtSearch" CssClass="search-input" runat="server" />
    <asp:LinkButton ID="LinkButton1" CssClass="ui-icon ui-icon-search" runat="server" />
</div>