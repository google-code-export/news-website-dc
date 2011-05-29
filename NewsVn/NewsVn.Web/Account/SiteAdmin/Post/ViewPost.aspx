<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.ViewPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SiteAdmin_FilterPost runat="server" />    
    <div id="postHelpBox" class="dialog" title="Trợ giúp">
        <p><b>Thêm tin mới</b>: Bấm vào nút 'Thêm'</p>
        <p><b>Sửa tin</b>: Bấm vào tiêu đề của một tin bất kỳ</p>
        <p><b>Xóa tin</b>: Chọn các dòng muốn xóa trong danh sách tin, sau đó bấm nút 'Xóa'</p>
        <p><b>Ẩn/Hiện tin</b>: Chọn các dòng trong danh sách tin, bấm nút 'Ẩn/Hiện'</p>
        <p><b>Duyệt tin</b>: Chọn các dòng trong danh sách tin, bấm 'Duyệt'</p>
    </div>
    <div class="ui-table-toolbar">
        <ul class="ui-form ui-widget">
            <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
        </ul>
        <asp:HyperLink ID="btnAdd" Text="Thêm" CssClass="button-add left" runat="server"
            NavigateUrl="~/Account/SiteAdmin/Post/AddPost.aspx" />
        <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete left" runat="server"
            OnClientClick="return confirmDelete()" OnClick="btnDelete_Click" />
        <asp:LinkButton ID="btnToggleActive" Text="Ẩn/Hiện" CssClass="button-toggle left" runat="server"
            OnClientClick="return checkSelectedRows()" OnClick="btnToggleActive_Click" />
        <asp:LinkButton ID="btnApprove" Text="Duyệt" CssClass="button-ok left" runat="server"
            OnClientClick="return checkSelectedRows()" OnClick="btnApprove_Click" />
        <asp:HyperLink Text="Trợ giúp" CssClass="button-help left dialog-trigger[postHelpBox]" runat="server" />
        <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh right" runat="server"
            OnClick="btnRefresh_Click" />
        <div class="clear"></div>
        <hr />
        <span class="left" style="margin-top:4px">Lọc theo:</span>
        <asp:DropDownList ID="ddlFilterColumn" CssClass="dropdown left" runat="server">
            <asp:ListItem Value="Title" Text="Tiêu đề" />
            <asp:ListItem Value="" Text="Danh mục" />
            <asp:ListItem Value="CreatedBy" Text="Người tạo" />
            <asp:ListItem Value="UpdatedBy" Text="Người sửa" />
            <asp:ListItem Value="ApprovedBy" Text="Người duyệt" />
        </asp:DropDownList>
        <asp:TextBox ID="txtFilterText" CssClass="left" Width="150" runat="server" />
        <asp:LinkButton ID="btnFilter" Text="Lọc danh sách" CssClass="button-filter left" runat="server"
            OnClick="btnFilter_Click" />
        <asp:HyperLink Text="Lọc nâng cao" CssClass="button-filter left dialog-trigger[advancedFilterBox]" runat="server" />
        <div class="right">
            Trang:
            <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged" />
            &nbsp;Số dòng/Trang:
            <asp:DropDownList ID="ddlPageSize" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged">
                <asp:ListItem Value="50" Text="50" />
                <asp:ListItem Value="100" Text="100" />
                <asp:ListItem Value="200" Text="200" />
                <asp:ListItem Value="500" Text="500" />
                <asp:ListItem Value="1000" Text="1000" />
            </asp:DropDownList>
        </div>
        <div class="clear"></div>
    </div>    
    <asp:Repeater ID="rptPostList" runat="server">
        <HeaderTemplate>
            <table id="post-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox EnableViewState="false" runat="server" /></th>
                    <th>Tiêu đề</th>
                    <th>Pageview</th>
                    <th>Danh mục</th>
                    <th>Tạo vào</th>
                    <th>Người tạo</th>
                    <th>Sửa vào</th>
                    <th>Người sửa</th>
                    <th>Đã duyệt</th>
                    <th>Duyệt vào</th>
                    <th>Duyệt bởi</th>
                    <th>Hiển thị</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="chkID" EnableViewState="false" runat="server"  />
                    <asp:HiddenField ID="hidID" Value='<%# Eval("ID") %>' runat="server" /> 
                </td>
                <td>
                    <a href='<%= HostName + "account/siteadmin/post/editpost.aspx?pid=" %><%# Eval("ID") %>'
                        title='<%# Eval("Title") %>'>
                        <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("Title").ToString(), 30) %>
                    </a>
                </td>
                <td style="text-align:left"><%#Eval("PageView", "{0:n0}") %></td>
                <td>
                    <a href='<%= HostName + "account/siteadmin/post/editcategory.aspx?cid=" %><%# Eval("CategoryID") %>'>
                        <%# Eval("CategoryName") %>
                    </a>
                </td>
                <td title='<%# Eval("CreatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("CreatedOn", "{0:dd/MM/yy}") %>
                </td>
                <td><%# Eval("CreatedBy") %></td>
                <td title='<%# Eval("UpdatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("UpdatedOn", "{0:dd/MM/yy}")%>
                </td>
                <td><%# Eval("UpdatedBy") %></td>
                <td align="center"><asp:CheckBox Checked='<%# Eval("Approved") %>' Enabled="false" runat="server" /></td>
                <td title='<%# Eval("ApprovedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("ApprovedOn", "{0:dd/MM/yy}")%>
                </td>
                <td><%# Eval("ApprovedBy") %></td>
                <td align="center"><asp:CheckBox Checked='<%# Eval("Actived") %>' Enabled="false" runat="server" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
