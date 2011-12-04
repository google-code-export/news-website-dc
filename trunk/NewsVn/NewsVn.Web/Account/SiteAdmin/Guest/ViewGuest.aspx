<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewGuest.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Guest.ViewGuest" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#userDetailsBox").dialog({
                autoOpen: false,
                resizable: false,
                modal: true,
                width: 450
            });
        });

        function viewUserDetails(username) {
            var dataObj = { userName: username };
            $.ajax({
                url: serviceUrl + "ViewUserDetails",
                data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
                success: function (result) {
                    $("#userDetailsBox ul").html(result.d);
                },
                complete: function () {
                    $("#userDetailsBox").dialog("open");
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div id="userHelpBox" class="dialog" title="Trợ giúp">
        
    </div>
    <div id="userDetailsBox" class="dialog" title="Chi tiết tài khoản" style="display:none">
        <ul class="ui-form ui-widget"></ul>
    </div>
    <div class="ui-table-toolbar">
        <ul class="ui-form ui-widget">
            <asp:Literal ID="ltrInfo" EnableViewState="false" runat="server" />
            <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
        </ul>        
        <div class="left">
            <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete" runat="server"
                OnClientClick="return confirmAction('Xóa tài khoản được chọn?')" 
                onclick="btnDelete_Click" />
            <asp:LinkButton ID="btnApprove" Text="Kích hoạt/Vô hiệu" CssClass="button-ok" runat="server"            
                OnClientClick="return confirmAction('Kích hoạt/Vô hiệu tài khoản được chọn?')" 
                OnClick="btnApprove_Click" />
            <asp:LinkButton ID="btnResetPassword" Text="Đặt lại mật khẩu" CssClass="button-reset" runat="server"            
                OnClientClick="return confirmAction('Đặt lại mật khẩu cho tài khoản được chọn?')" 
                OnClick="btnResetPassword_Click" />
            <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[userHelpBox]" runat="server" />
        </div>
        <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh right" 
            runat="server" OnClick="btnRefresh_Click" />
        <div class="clear"></div>
        <hr />
        <div class="left">
            Sắp xếp theo:
            <asp:DropDownList ID="ddlSortColumn" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Sorter_SelectedIndexChanged">
                <asp:ListItem Value="Account" Text="Tài khoản" />
                <asp:ListItem Value="Name" Text="Họ tên" />
                <asp:ListItem Value="Nickname" Text="Nickname" />
                <asp:ListItem Value="Email" Text="Email" />
                <asp:ListItem Value="UpdatedOn" Text="Ngày tạo" />              
            </asp:DropDownList>
            <asp:DropDownList ID="ddlSortDirection" CssClass="dropdown" Width="70px" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Sorter_SelectedIndexChanged">
                <asp:ListItem Value="ASC" Text="A -> Z" />
                <asp:ListItem Value="DESC" Text="Z -> A" />
            </asp:DropDownList>
            <asp:LinkButton ID="btnClearSort" CssClass="button-clear" Text="Bỏ sắp xếp" Visible="false" 
                runat="server" onclick="btnClearSort_Click" />
        </div>
        <div class="right">
            Trang:
            <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" runat="server" Width="50"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged" />
            &nbsp;Số dòng/Trang:
            <asp:DropDownList ID="ddlPageSize" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged">
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
                    <% if (OrderColumn.Equals("Account", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Tài khoản</th>
                    <% } else { %>
                    <th>Tài khoản</th>
                    <% } %>
                    <% if (OrderColumn.Equals("Name", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Họ tên</th>
                    <% } else { %>
                    <th>Họ tên</th>
                    <% } %>
                    <% if (OrderColumn.Equals("Nickname", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Nickname</th>
                    <% } else { %>
                    <th>Nickname</th>
                    <% } %>
                    <th>Giới tính</th>
                    <% if (OrderColumn.Equals("Email", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Email</th>
                    <% } else { %>
                    <th>Email</th>
                    <% } %>
                    <% if (OrderColumn.Equals("UpdatedOn", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Ngày tạo</th>
                    <% } else { %>
                    <th>Ngày tạo</th>
                    <% } %>
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
	            <td>
                    <a href='<%# Eval("Account", "javascript:viewUserDetails(\"{0}\")") %>'>
                        <b><%# Eval("Account") %></b>
                    </a>
                </td>
                <td><%# Eval("Name") %></td>
                <td><%# Eval("Nickname") %></td>
                <td><%# Eval("NamedGender") %></td>
                <td><%# Eval("Email") %></td>
                <td title='<%# Eval("UpdatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("UpdatedOn", "{0:dd/MM/yy}")%>
                </td>
                <td><asp:CheckBox Checked='<%# Eval("Approved") %>' Enabled="false" runat="server" /></td>
                <td><%# Eval("Status") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
