<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysAdmin_Menu.ascx.cs" Inherits="NewsVn.Web.Modules.SysAdmin_Menu" %>

<ul class="side_nav">
    <li class="side_main_menu">
        <asp:HyperLink CssClass="view-user" NavigateUrl="~/account/sysadmin/user/viewuser.aspx" Text="Quản lý tài khoản" runat="server" />
        <ul style="margin-left:10px;display:none">
            <li>
                <asp:HyperLink CssClass="add-user" NavigateUrl="~/account/sysadmin/user/adduser.aspx" Text="Thêm tài khoản mới" runat="server" />
            </li>
        </ul>
    </li>
    <li class="side_main_menu">
        <asp:HyperLink CssClass="view-setting" NavigateUrl="~/account/sysadmin/setting/viewsetting.aspx" Text="Quản lý cấu hình" runat="server" />
    </li>
    <li></li>
    <li></li>
</ul>
<div style="position:fixed;bottom:10px;left:40px">
    <a href="http://www.histats.com" alt="page hit counter" target="_blank" >
    <embed src="http://s10.histats.com/403.swf"  flashvars="jver=1&acsid=1496905&domi=4"  quality="high"  width="118" height="80" name="403.swf"  align="middle" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" wmode="transparent" /></a>
    <img  src="http://sstatic1.histats.com/0.gif?1496905&101" alt="web site hit counter" border="0">
</div>