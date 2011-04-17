<%@ Control Language="C#" ClassName="QuickSearchBox" %>

<script type="text/javascript">
	$(function(){
		var initText = "Tìm nhanh...";
		var searchInput = $("#<%= txtSearch.ClientID %>");
		initSearchInput(initText, searchInput);
		searchInput.focus(function(){
			if(searchInput.val() == initText) {
				searchInput.val("");
				searchInput.css({ "font-style": "normal" });
			}
		});
		searchInput.blur(function(){
			if($.trim(searchInput.val()) == "") {
				initSearchInput(initText, searchInput);
			}
		});
	});
	
	function initSearchInput(initText, searchInput){
		searchInput.val(initText);
		searchInput.css({ "font-style": "italic" });
	}
</script>

<div class="side-part portlet">
	<h2>Tìm kiếm</h2>
	<div class="textbox-icon">
        <asp:TextBox ID="txtSearch" CssClass="search-input" runat="server" />
        <asp:LinkButton CssClass="ui-icon ui-icon-search" PostBackUrl="~/postsearchresult.aspx" runat="server" />
    </div>
</div>