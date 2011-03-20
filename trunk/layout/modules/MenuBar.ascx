<%@ Control Language="C#" ClassName="MenuBar" %>

<script type="text/javascript">
    $(function () {
        $("#menu_bar li:first-child").addClass("head");
        $("#menu_bar li:last-child").addClass("tail");
        $("#menu_bar li > a").addClass("menu-item");
        $("#menu_bar .sub-menu").each(function () {
            $(this).css({ "min-width": $(this).parent().width() - 10 });
        });
        $("#menu_bar .sub-menu a:first-child").css({ border: 0 });
        $("#menu_bar li").hover(function () {
            $(this).children(".sub-menu").css({ "display": "block" });
        }, function () {
            $(this).children(".sub-menu").css({ "display": "none" });
        });

    });
</script>

<ul id="menu_bar">
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/default.aspx">Trang chủ</asp:HyperLink>        
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/category.aspx">Kinh tế</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/category.aspx">Xã hội</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/category.aspx">Văn hóa</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/category.aspx">Thể thao</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/category.aspx">Góc Teen</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/category.aspx">Khoa học</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/category.aspx">Du lịch - Ẩm thực</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/category.aspx">Tình yêu - Gia đình</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>    
    <li>
        <asp:HyperLink runat="server" NavigateUrl="~/category.aspx">Thư giãn</asp:HyperLink>
    </li>
	<li>
        <asp:HyperLink runat="server" NavigateUrl="#">Rao nhanh</asp:HyperLink>
    </li>
</ul>