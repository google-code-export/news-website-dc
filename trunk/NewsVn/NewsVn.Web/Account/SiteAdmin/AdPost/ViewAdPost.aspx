<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewAdPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.AdPost.ViewAdPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div id="adpostHelpBox" class="dialog" title="Trợ giúp">
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
        <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete left" runat="server"
            OnClientClick="return confirmAction('Xóa tin được chọn?')" OnClick="btnDelete_Click" />
        <asp:LinkButton ID="btnToggleActive" Text="Ẩn/Hiện" CssClass="button-toggle left" runat="server"
            OnClientClick="return confirmAction('Ẩn/Hiện tin được chọn?')" OnClick="btnToggleActive_Click" />
        <asp:HyperLink Text="Trợ giúp" CssClass="button-help left dialog-trigger[adpostHelpBox]" runat="server" />
        <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh right" runat="server"
            OnClick="btnRefresh_Click" />
        <div class="clear"></div>
        <hr />
        <span class="left" style="margin-top:4px">Lọc theo:</span>
        <asp:DropDownList ID="ddlFilterColumn" CssClass="dropdown left" runat="server">
            <asp:ListItem Value="Title" Text="Tiêu đề" />
            <asp:ListItem Value="" Text="Danh mục" />
            <asp:ListItem Value="UpdatedBy" Text="Người tạo" />
            <asp:ListItem Value="UpdatedBy" Text="Người sửa" />
        </asp:DropDownList>
        <asp:TextBox ID="txtFilterText" CssClass="left" Width="150" runat="server" />
        <asp:LinkButton ID="btnFilter" Text="Lọc danh sách" CssClass="button-filter left" runat="server"
            OnClick="btnFilter_Click" />
        <div class="right">
            Trang:
            <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" runat="server" Width="50"
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
    <asp:Repeater ID="rptAdPostList" runat="server">
        <HeaderTemplate>
            <table id="post-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox EnableViewState="false" runat="server" /></th>
                    <th>Tiêu đề</th>
                    <th>Danh mục</th>
                    <th>Tạo vào</th>
                    <th>Tạo bởi</th>
                    <th>Sửa vào</th>
                    <th>Sửa bởi</th>
                    <th>Hết hạn</th>
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
                    <a href='<%= HostName + "account/siteadmin/adpost/editadpost.aspx?pid=" %><%# Eval("ID") %>'
                        title='<%# Eval("Title") %>'>
                        <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("Title").ToString(), 30) %>
                    </a>
                </td>
                <td><%# Eval("CategoryName") %></td>
                <td title='<%# Eval("CreatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("CreatedOn", "{0:dd/MM/yy}")%>
                </td>
                <td><%# Eval("CreatedBy")%></td>
                <td title='<%# Eval("UpdatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("UpdatedOn", "{0:dd/MM/yy}")%>
                </td>
                <td><%# Eval("UpdatedBy") %></td>
                <td title='<%# Eval("ExpiredOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("ExpiredOn", "{0:dd/MM/yy}")%>
                </td>
                <td align="center"><asp:CheckBox Checked='<%# Eval("Actived") %>' Enabled="false" runat="server" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
