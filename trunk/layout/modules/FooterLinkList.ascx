<%@ Control Language="C#" ClassName="FooterLinkList" %>

<script type="text/javascript">
    $(function () {
        var selectorID = "#<%= linkSelector.ClientID %>";
		var linkSelector = $(selectorID);
        linkSelector.selectmenu({ width: "274px" });
        linkSelector.next(".ui-selectmenu").addClass("select");
        linkSelector.next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
		$(selectorID + "-menu").width(280);
    });
</script>

<div class="section link-network" style="padding-bottom:0">
	<h2>Liên kết</h2>
    <asp:DropDownList ID="linkSelector" runat="server">
        <asp:ListItem Text="- Chọn liên kết -" />
        <asp:ListItem Value="http://vnexpress.net" Text="VnExpress.net" />
        <asp:ListItem Value="http://ngoisao.net" Text="Ngoisao.net" />
        <asp:ListItem Value="http://thanhnien.vn" Text="Thanhnien.vn" />
    </asp:DropDownList>
</div>