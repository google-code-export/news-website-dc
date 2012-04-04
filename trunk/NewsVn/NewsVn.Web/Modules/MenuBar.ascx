<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBar.ascx.cs" Inherits="NewsVn.Web.Modules.MenuBar" %>

<script type="text/javascript">
    $(function () {
        $("#menu_bar .sub-menu").each(function () {
            $(this).css({ "min-width": $(this).parent().width() + $(this).parent().next().width() });
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
    <li class="head">
        <a class="menu-item" href='<%= HostName + "trang-chu.aspx" %>' title="Trang chủ">
            <img src='<%= HostName + "images/icons/home_white.png" %>' alt="Trang chủ"
                style="vertical-align:middle;margin-top:-5px" />
        </a>
    </li>
    <asp:Repeater runat="server" ID="rptMenu" 
        OnItemDataBound="rptMenu_ItemDataBound">
        <ItemTemplate>
            <li>
                <a class="menu-item" href='<%# HostName + Eval("SeoUrl") %>'><%# Eval("Name") %></a>
                <div class="sub-menu">
                    <asp:Repeater runat="server" ID="rptSubMenu">
                        <ItemTemplate>
                            <a href='<%# HostName + Eval("SeoUrl") %>'><%# Eval("Name") %></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    <li class="tail">
        <a class="menu-item" href='<%=HostName + "rao-nhanh.aspx" %>'>Rao nhanh</a>
    </li>
</ul>