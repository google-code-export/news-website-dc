<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideAdminMenu.ascx.cs" Inherits="NewsVn.Web.Modules.SiteAdmin_Menu" %>

<ul>
    <li>
        <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ViewPost.aspx" Text="Quản lý tin tức" runat="server" />
        <ul style="margin-left:10px">
            <li>
                <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/AddPost.aspx" Text="Thêm tin mới" runat="server" />
            </li>
             <li>
                <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ManageSpecialEventNews.aspx" Text="Quản lý sự kiện nổi bật" runat="server" />
            </li>
            <li>
                <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ViewCategory.aspx" Text="Quản lý chủ đề" runat="server" />
            </li>            
            <li>
                <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ViewPostComment.aspx" Text="Quản lý bình luận" runat="server" />
            </li>
        </ul>
    </li>
    <li>
        <asp:HyperLink NavigateUrl="#" Text="Quản lý rao nhanh" runat="server" />
        <ul style="margin-left:10px">
            <li>
            
            </li>
        </ul>
    </li>
    <li>
        <asp:HyperLink NavigateUrl="#" Text="Quản lý tìm bạn" runat="server" />
        <ul style="margin-left:10px">
            <li>
            
            </li>
        </ul>
    </li>
    <li>
        <asp:HyperLink NavigateUrl="#" Text="Quản lý khác" runat="server" />
        <ul style="margin-left:10px">
            <li>
            
            </li>
        </ul>
    </li>
</ul>
<div>
<!-- Histats.com  START (html only)-->
<hr />
<h3>Hiện trạng <a href="http://newsvn.vn">Newsvn.vn</a></h3>
<a href="http://www.histats.com" alt="page hit counter" target="_blank" >
<embed src="http://s10.histats.com/403.swf"  flashvars="jver=1&acsid=1496905&domi=4"  quality="high"  width="118" height="80" name="403.swf"  align="middle" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" wmode="transparent" /></a>
<img  src="http://sstatic1.histats.com/0.gif?1496905&101" alt="web site hit counter" border="0">
<!-- Histats.com  END  -->
</div>