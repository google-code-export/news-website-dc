<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Account_LoginBar.ascx.cs" Inherits="NewsVn.Web.Modules.Account_LoginBar" %>

<script type="text/javascript">
    $(function () {
        $("#accountDetailsBox").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            width: 450
        });
        $("#editInfoBox, #changePassBox").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            width: 482
        });
        $("#<%= btnOkCP.ClientID %>").click(function () {
            changeAccountPassword();
        });
    });

    function viewAccountDetails(username) {
        var dataObj = { userName: username };
        $.ajax({
            url: serviceUrl + "ViewUserDetails",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
            success: function (result) {
                $("#accountDetailsBox ul").html(result.d);
            },
            complete: function () {
                $("#accountDetailsBox").dialog("open");
            }
        });
    }

    function changeAccountPassword() {
        var dataObj = {
            oldPassword: $("#<%= txtOldPass.ClientID %>").val(),
            newPassword: $("#<%= txtNewPass.ClientID %>").val(),
            confirmPassword: $("#<%= txtConfirmPass.ClientID %>").val()
        };
        $.ajax({
            url: serviceUrl + "ChangeUserPassword",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
            success: function (result) {

            }, error: function () {
                var errorHtml = '<%= string.Format(ErrorBar, "Không thể đổi mật khẩu. Vui lòng thử lại.") %>';
                $("#changePassBox .commands").before(errorHtml);
            }
        });
    }
</script>

<div id="accountDetailsBox" class="dialog" title="Chi tiết tài khoản" style="display:none">
    <ul class="ui-form ui-widget"></ul>
    <div class="right" style="margin:10px 0">
        <a class="button-edit dialog-trigger[editInfoBox]" href="javascript:void(0)">
            Chỉnh sửa thông tin
        </a>
        <a class="button-key dialog-trigger[changePassBox]" href="javascript:void(0)">
            Đổi mật khẩu
        </a>        
    </div>
    <div class="clear"></div>
</div>

<div id="editInfoBox" class="dialog" title="Chỉnh sửa thông tin" style="display:none">
    <ul class="ui-form ui-widget">
        <li>
            
        </li>
    </ul>
</div>

<div id="changePassBox" class="dialog" title="Thay đổi mật khẩu" style="display:none">
    <ul class="ui-form ui-widget">
        <li>
            <asp:Label AssociatedControlID="txtOldPass" Text="Mật khẩu cũ:" Width="120" runat="server" />
            <asp:TextBox ID="txtOldPass" TextMode="Password" Width="320" CssClass="validate[required]" MaxLength="50" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtNewPass" Text="Mật khẩu mới:" Width="120" runat="server" />
            <asp:TextBox ID="txtNewPass" TextMode="Password" Width="320" CssClass="validate[required]" MaxLength="50" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtConfirmPass" Text="Mật khẩu xác nhận:" Width="120" runat="server" />
            <asp:TextBox ID="txtConfirmPass" TextMode="Password" Width="320" CssClass="validate[required]" MaxLength="50" runat="server" />
        </li>
        <li class="commands">
            <div class="right">
                <asp:HyperLink ID="btnOkCP" CssClass="button-ok" NavigateUrl="javascript:void(0)" Text="Đổi" runat="server" />
                <asp:HyperLink ID="btnCancelCP" CssClass="button-cancel" NavigateUrl="javascript:void(0)" Text="Hủy bỏ" runat="server" />
            </div>
            <div class="clear"></div>
        </li>
    </ul>
</div>

Xin chào,
<a href='<%= string.Format("javascript:viewAccountDetails(\"{0}\")", HttpContext.Current.User.Identity.Name) %>' title="Xem thông tin tài khoản">
    <asp:LoginName Font-Bold="true" runat="server" />    
</a>
| <asp:LoginStatus LogoutAction="Redirect" LogoutPageUrl='<%$ Code: HostName + "trang-chu.aspx" %>' LogoutText="Thoát" runat="server" />