<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Editor_Menu.ascx.cs" Inherits="NewsVn.Web.Modules.Editor_Menu" %>

<ul class="side_nav">
    <li class="side_main_menu">
        <asp:HyperLink CssClass="view-post" NavigateUrl="~/Account/Editor/Post/ViewPost.aspx" Text="Quản lý tin tức" runat="server" />
        <ul style="margin-left:10px;display:none">
            <li>
                <asp:HyperLink CssClass="add-post" NavigateUrl="~/Account/Editor/Post/AddPost.aspx" Text="Thêm tin mới" runat="server" />
            </li>
        </ul>
    </li>
    <li class="side_main_menu">
        <asp:HyperLink NavigateUrl="#" Text="Quản lý rao nhanh" runat="server" />
        <ul style="margin-left:10px;display:none">
            <li>
                <asp:HyperLink NavigateUrl="#" Text="Thêm rao nhanh mới" runat="server" />
            </li>
        </ul>
    </li>
    <li class="side_main_menu">
        <asp:HyperLink NavigateUrl="#" Text="Quản lý Video clip" runat="server" />
        <ul style="margin-left:10px;display:none">
            <li>
                <asp:HyperLink NavigateUrl="#" Text="Thêm Video clip mới" runat="server" />
            </li>
        </ul>
    </li>
</ul>
<div style="position:fixed;bottom:10px;left:40px">
    <a href="http://www.histats.com" alt="page hit counter" target="_blank" >
    <embed src="http://s10.histats.com/403.swf"  flashvars="jver=1&acsid=1496905&domi=4"  quality="high"  width="118" height="80" name="403.swf"  align="middle" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" wmode="transparent" /></a>
    <img  src="http://sstatic1.histats.com/0.gif?1496905&101" alt="web site hit counter" border="0">
</div>