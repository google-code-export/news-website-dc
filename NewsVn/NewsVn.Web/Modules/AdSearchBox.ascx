<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdSearchBox.ascx.cs" Inherits="NewsVn.Web.Modules.AdSearchBox" %>

<script type="text/javascript">
    $(function () {
        var initText = "Tìm rao vặt...";
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

        var selectorID = "#<%= ddlLocation.ClientID %>";
        var linkSelector = $(selectorID);
        linkSelector.selectmenu({ width: "274px" });
        linkSelector.next(".ui-selectmenu").addClass("select");
        linkSelector.next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $(selectorID + "-menu").width(280);
        $(".side-part .datepicker").datepicker("option", "dateFormat", "dd/mm/yy");
    });

    function initSearchInput(initText, searchInput) {
        searchInput.val(initText);
        searchInput.css({ "font-style": "italic" });
    }
</script>

<div class="side-part adpost-search portlet">
	<h2>Tìm kiếm</h2>
	<ul class="ui-form ui-widget">
        <li class="head">
            <asp:TextBox ID="txtSearch" CssClass="search-input" runat="server" />
        </li>
        <li>
            <asp:DropDownList ID="ddlLocation" runat="server">
                <asp:ListItem Text="Toàn quốc" />
                <asp:ListItem Text="Hà Nội" />
                <asp:ListItem Text="Hồ Chí Minh" />
                <asp:ListItem Text="Các tỉnh miền Bắc" />
                <asp:ListItem Text="Các tỉnh miền Nam" />
            </asp:DropDownList>
        </li>
        <li>
            <p style="margin-top:0">Tìm từ ngày - đến ngày:</p>
            <div class="textbox-icon left">
                <asp:TextBox ID="txtAdFromDate" CssClass="datepicker" style="width:125px" runat="server" />
            </div>
            <div class="textbox-icon right">
                <asp:TextBox ID="txtAdToDate" CssClass="datepicker" style="width:125px" runat="server" />
            </div>
            <div class="clear"></div>
        </li>
        <li class="command">
            <asp:HyperLink ID="HyperLink1" Text="Đăng mới" NavigateUrl="../AdFormBox.aspx" CssClass="button left" runat="server" />
            <asp:LinkButton ID="LinkButton1" Text="Tìm" CssClass="button-search right" 
                style="margin-right:0;" runat="server" onclick="LinkButton1_Click" />
            <div class="clear"></div>
        </li>
    </ul>
</div>