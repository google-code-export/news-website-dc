<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideAdminMenu.ascx.cs" Inherits="NewsVn.Web.Modules.SiteAdmin_Menu" %>

<ul>
    <li>
        <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ViewPost.aspx" Text="Quản lý tin tức" runat="server" />
        <ul style="margin-left:10px">
            <li>
                <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/AddPost.aspx" Text="Thêm tin mới" runat="server" />
            </li>
            <li>
                <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ViewCategory.aspx" Text="Quản lý chủ đề" runat="server" />
            </li>            
            <li>
                <asp:HyperLink NavigateUrl="#" Text="Quản lý bình luận" runat="server" />
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