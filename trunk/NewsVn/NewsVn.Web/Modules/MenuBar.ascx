<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBar.ascx.cs" Inherits="NewsVn.Web.Modules.MenuBar" %>
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
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx">Trang chủ</asp:HyperLink>        
    </li>
    <asp:Repeater runat="server" ID="rptMenu" 
        onitemdatabound="rptMenu_ItemDataBound">
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="hplnkMenu" runat="server" NavigateUrl='<%#Eval("SeoUrl") %>'><%#Eval("Name") %></asp:HyperLink>
                <div class="sub-menu">
                    <asp:Repeater runat="server" ID="rptSubMenu">
                        <ItemTemplate>
                            <asp:HyperLink ID="hplnkSubMenu" runat="server" NavigateUrl='<%#Eval("SeoUrl") %>'><%#Eval("Name") %></asp:HyperLink>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    <%--<li>
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/category.aspx">Kinh tế</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/category.aspx">Xã hội</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/category.aspx">Văn hóa</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/category.aspx">Thể thao</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="~/category.aspx">Góc Teen</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink25" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="~/category.aspx">Khoa học</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink ID="HyperLink28" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink29" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink30" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink31" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink32" runat="server" NavigateUrl="~/category.aspx">Du lịch - Ẩm thực</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink ID="HyperLink33" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink34" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink35" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink36" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>
    <li>
        <asp:HyperLink ID="HyperLink37" runat="server" NavigateUrl="~/category.aspx">Tình yêu - Gia đình</asp:HyperLink>
        <div class="sub-menu">
            <asp:HyperLink ID="HyperLink38" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink39" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink40" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
            <asp:HyperLink ID="HyperLink41" runat="server" NavigateUrl="#">Danh mục con</asp:HyperLink>
        </div>
    </li>    
    <li>
        <asp:HyperLink ID="HyperLink42" runat="server" NavigateUrl="~/category.aspx">Thư giãn</asp:HyperLink>
    </li>
--%>	<li>
        <asp:HyperLink ID="HyperLink43" runat="server" NavigateUrl="#">Rao nhanh</asp:HyperLink>
    </li>
</ul>