<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBar.ascx.cs" Inherits="NewsVn.Web.Modules.MenuBar" %>
<script type="text/javascript">
    $(function () {
        $("#menu_bar li:first-child").addClass("head");
        $("#menu_bar li:last-child").addClass("tail");
        $("#menu_bar li > a").addClass("menu-item");
        $("#menu_bar .sub-menu").each(function () {
            $(this).css({ "min-width": $(this).parent().width()+$(this).parent().next().width() });
        });
        $("#menu_bar .sub-menu a:first-child").css({ border: 0 });
        $("#menu_bar li").hover(function () {
            $(this).children(".sub-menu").css({ "display": "block" });
        }, function () {
            $(this).children(".sub-menu").css({ "display": "none" });
        });
        //$(this).next(".portlet.right")
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
                            <a href='<%#Eval("SeoUrl") %>'><%#Eval("Name") %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    	<li>
        <asp:HyperLink ID="HyperLink43" runat="server" NavigateUrl="#">Rao nhanh</asp:HyperLink>
    </li>
</ul>