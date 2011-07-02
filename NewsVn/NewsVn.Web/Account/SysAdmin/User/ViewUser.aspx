<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SysAdmin/SysAdmin.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="NewsVn.Web.Account.SysAdmin.User.ViewUser" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SiteAdmin_FilterPost runat="server" />    
    <div id="userHelpBox" class="dialog" title="Trợ giúp">
        <%--<p><b>Thêm tin mới</b>: Bấm vào nút 'Thêm'</p>
        <p><b>Sửa tin</b>: Bấm vào tiêu đề của một tin bất kỳ</p>
        <p><b>Xóa tin</b>: Chọn các dòng muốn xóa trong danh sách tin, sau đó bấm nút 'Xóa'</p>
        <p><b>Ẩn/Hiện tin</b>: Chọn các dòng trong danh sách tin, bấm nút 'Ẩn/Hiện'</p>
        <p><b>Duyệt tin</b>: Chọn các dòng trong danh sách tin, bấm 'Duyệt'</p>--%>
    </div>
    <div class="ui-table-toolbar">
        <ul class="ui-form ui-widget">
            <asp:Literal ID="ltrInfo" EnableViewState="false" runat="server" />
            <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
        </ul>
        <asp:HyperLink ID="btnAdd" Text="Thêm" CssClass="button-add left" runat="server"
            NavigateUrl="~/Account/SysAdmin/User/AddUser.aspx" />
        <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete left" runat="server"
            OnClientClick="return confirmAction('Xóa tài khoản được chọn?')" 
            onclick="btnDelete_Click" />
        <asp:LinkButton ID="btnApprove" Text="Kích hoạt/Vô hiệu" CssClass="button-ok left" runat="server"            
            OnClientClick="return confirmAction('Kích hoạt/Vô hiệu tài khoản được chọn?')" 
            OnClick="btnApprove_Click" />
        <asp:LinkButton ID="btnResetPassword" Text="Đặt lại mật khẩu" CssClass="button-reset left" runat="server"            
            OnClientClick="return confirmAction('Đặt lại mật khẩu cho tài khoản được chọn?')" 
            OnClick="btnResetPassword_Click" />
        <asp:HyperLink Text="Trợ giúp" CssClass="button-help left dialog-trigger[userHelpBox]" runat="server" />
        <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh right" 
            runat="server" OnClick="btnRefresh_Click" />
        <div class="clear"></div>
        <hr />
        <span class="left" style="margin-top:4px">Lọc theo:</span>
        <asp:DropDownList ID="ddlFilterColumn" Width="120" CssClass="dropdown left" runat="server">
            <asp:ListItem Value="" Text="Tài khoản" />
            <asp:ListItem Value="" Text="Họ tên" />
            <asp:ListItem Value="" Text="CMND" />
            <asp:ListItem Value="" Text="Email" />
            <asp:ListItem Value="" Text="Ngày tạo" />
            <asp:ListItem Value="" Text="Người tạo" />
            <asp:ListItem Value="" Text="Quyền" />
            <asp:ListItem Value="" Text="Kích hoạt" />
            <asp:ListItem Value="" Text="Trạng thái" />
        </asp:DropDownList>
        <asp:TextBox ID="txtFilterText" CssClass="left" Width="150" runat="server" />
        <asp:LinkButton ID="btnFilter" Text="Lọc danh sách" CssClass="button-filter left" runat="server" />
        <div class="right">
            Trang:
            <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" runat="server" Width="50"
                AutoPostBack="true" />
            &nbsp;Số dòng/Trang:
            <asp:DropDownList ID="ddlPageSize" CssClass="dropdown" runat="server"
                AutoPostBack="true">
                <asp:ListItem Value="20" Text="20" />
                <asp:ListItem Value="50" Text="50" />
                <asp:ListItem Value="100" Text="100" />
                <asp:ListItem Value="200" Text="200" />
            </asp:DropDownList>
        </div>
        <div class="clear"></div>
    </div>
    <asp:Repeater ID="rptUserList" runat="server">
        <HeaderTemplate>
            <table id="user-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox EnableViewState="false" runat="server" /></th>
                    <th>Tài khoản</th>
                    <th>Họ tên</th>
                    <th>CMND</th>
                    <th>Email</th>
                    <th>Ngày tạo</th>
                    <th>Người tạo</th>
                    <th>Quyền</th>
                    <th>Kích hoạt</th>
                    <th>Trạng thái</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
	            <td>
                    <asp:CheckBox ID="chkAccount" EnableViewState="false" runat="server" />
                    <asp:HiddenField ID="hidAccount" Value='<%# Eval("Account") %>' runat="server" />
                </td>
	            <td><%# Eval("Account") %></td>
                <td><%# Eval("Name") %></td>
                <td><%# Eval("IdNumber") %></td>
                <td><%# Eval("Email") %></td>
                <td title='<%# Eval("UpdatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("UpdatedOn", "{0:dd/MM/yy}")%>
                </td>
                <td><%# Eval("UpdatedBy") %></td>
                <td><%# Eval("RoleName") %></td>
                <td><asp:CheckBox Checked='<%# Eval("Approved") %>' Enabled="false" runat="server" /></td>
                <td><%# Eval("Status") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
