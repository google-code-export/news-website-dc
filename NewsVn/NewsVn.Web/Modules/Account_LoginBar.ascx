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
            newPassword: $("#<%= txtConfirmPass.ClientID %>").val()
        };
        $("#changePassBox").prev(".ui-dialog-titlebar").find(".ui-dialog-titlebar-close").hide();
        $("#<%= btnOkCP.ClientID %>, #<%= btnCancelCP.ClientID %>").hide();
        var waitHtml = '<%= string.Format(InfoBar, "Đang thực hiện...") %>';
        $("#changePassBox .head").before(waitHtml);
        $.ajax({
            url: serviceUrl + "ChangeUserPassword",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
            success: function (result) {
                alert("Thay đổi mật khẩu thành công!");
                $("#changePassBox").dialog("close");
            }, error: function () {
                alert("Không thể đổi mật khẩu. Vui lòng thử lại.");
            }, complete: function () {
                $("#changePassBox ul li:first-child").remove();
                $("#changePassBox").prev(".ui-dialog-titlebar").find(".ui-dialog-titlebar-close").show();
                $("#<%= btnOkCP.ClientID %>, #<%= btnCancelCP.ClientID %>").show();
                $("#<%= txtOldPass.ClientID %>, #<%= txtNewPass.ClientID %>, #<%= txtConfirmPass.ClientID %>").val("");
                $("#<%= txtOldPass.ClientID %>").focus();
            }
        });
    }
</script>

<div id="accountDetailsBox" class="dialog" title="Chi tiết tài khoản" style="display:none">
    <ul class="ui-form ui-widget"></ul>
    <a class="button-key dialog-trigger[changePassBox] right" href="javascript:void(0)">
        Đổi mật khẩu
    </a>
    <div class="clear"></div>
</div>

<div id="editInfoBox" class="dialog" title="Chỉnh sửa thông tin" style="display:none">
    <ul class="ui-form ui-widget">
        <li class="head">
            <asp:Label AssociatedControlID="txtName" Text="Họ tên *:" runat="server" />
            <asp:TextBox ID="txtName" Width="340" CssClass="validate[required]" MaxLength="150" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtIdNumber" Text="Số CMND *:" runat="server" />
            <asp:TextBox ID="txtIdNumber" Width="340" CssClass="validate[required,custom[number]]" MaxLength="9" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtPhone" Text="Số điện thoại:" runat="server" />
            <asp:TextBox ID="txtPhone" Width="340" CssClass="validate[custom[phone2]]" MaxLength="12" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtDOB" Text="Ngày sinh:" runat="server" />
            <div class="textbox-icon right">
                <asp:TextBox ID="txtDOB" CssClass="datepicker" Width="340" runat="server" />
            </div>
            <div class="clear"></div>
        </li>
        <li>
            <asp:Label AssociatedControlID="rblGender" Text="Giới tính:" runat="server" />
            <asp:RadioButtonList ID="rblGender" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server">
                <asp:ListItem Selected="True" Value="True" Text="Thành viên nam" />
                <asp:ListItem Value="False" Text="Thành viên nữ" />
            </asp:RadioButtonList>
        </li>
        <li>
            <asp:Label AssociatedControlID="ddlLocation" Text="Khu vực:" runat="server" />
            <asp:DropDownList ID="ddlLocation" CssClass="dropdown" Width="346" runat="server">
                <asp:ListItem Value="" Text="[Chọn khu vực]" />
                <asp:ListItem Value="Miền Nam" Text="Miền Nam" />
                <asp:ListItem Value="Miền Trung" Text="Miền Trung" />
                <asp:ListItem Value="Miền Bắc" Text="Miền Bắc" />
            </asp:DropDownList>
        </li>
        <li>
            <asp:Label AssociatedControlID="txtEducation" Text="Trình độ:" runat="server" />
            <asp:TextBox ID="txtEducation" Width="340" MaxLength="50" runat="server" />
        </li>
        <li class="commands">
            <div class="right">
                <asp:HyperLink ID="btnOkEI" CssClass="button-ok" NavigateUrl="javascript:void(0)" Text="Cập nhật" runat="server" />
                <asp:HyperLink ID="btnCancelEI" CssClass="button-cancel" NavigateUrl="javascript:void(0)" Text="Hủy bỏ" runat="server" />
            </div>
            <div class="clear"></div>
        </li>
    </ul>
</div>

<div id="changePassBox" class="dialog" title="Thay đổi mật khẩu" style="display:none">
    <ul class="ui-form ui-widget">
        <li class="head">
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
<a href='<%= string.Format("javascript:viewAccountDetails(\"{0}\")", HttpContext.Current.User.Identity.Name) %>'
    title='Xem thông tin [<%= HttpContext.Current.User.Identity.Name %>]'>
    <b><%= NewsVn.Web.Utils.clsCommon.getEllipsisText(HttpContext.Current.User.Identity.Name, 8) %></b>
</a>
| <asp:LoginStatus LogoutAction="Redirect" LogoutPageUrl='<%$ Code: HostName %>' LogoutText="Thoát" runat="server" />