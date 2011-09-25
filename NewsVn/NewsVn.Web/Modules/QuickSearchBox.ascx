<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuickSearchBox.ascx.cs" Inherits="NewsVn.Web.Modules.QuickSearchBox" %>
 <link href="<%= Page.ResolveUrl("~/Styles/jquery.autocomplete.css") %>" rel="stylesheet" type="text/css" />
 <script src="<%= Page.ResolveUrl("~/Scripts/plugins/jquery.autocomplete.js") %>" type="text/javascript"></script>

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
        $("#<%= txtSearch.ClientID %>").autocomplete("<%=HostName %>Utils/AutoCompleteSV.ashx");
    });      
</script>

<div class="side-part portlet">
	<h2>Tìm kiếm</h2>
	<div class="textbox-icon" style="height:30px">
        <asp:TextBox ID="txtSearch" CssClass="search-input" runat="server" Width="268px" />
        &nbsp;<asp:LinkButton ID="lnkbtnSearch" CssClass="ui-icon ui-icon-search" 
            runat="server" onclick="lnkbtnSearch_Click" />
    </div>
</div>