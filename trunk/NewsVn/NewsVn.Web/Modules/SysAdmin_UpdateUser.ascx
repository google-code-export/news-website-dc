<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysAdmin_UpdateUser.ascx.cs" Inherits="NewsVn.Web.Modules.SysAdmin_UpdateUser" %>

<script type="text/javascript">
    $(function () {
        $("#<%= ddlRole.ClientID %>").change(function () {
            $(this).prev(".decoy").val($(this).val());
        });
        $("#<%= txtDOB.ClientID %>").datepicker("option", {
            changeMonth: true,
            changeYear: true,
            minDate: "-55y",
            maxDate: "-18y"
        });
    });
    function checkValidation() {
        return $("#update_user_form").validationEngine('validate');
    }
</script>

<div id="updateUserHelpBox" class="dialog" title="Trợ giúp">
</div>
<ul id="update_user_form" class="ui-form ui-widget main" style="width:456px">
    <asp:Literal ID="ltrInfo" EnableViewState="false" runat="server" />
    <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
    <li style="margin:0 0 10px;border-bottom:1px dotted #333;">
        Các thông tin bắt buộc để tạo mới tài khoản
    </li>
    <li>
        <asp:Label AssociatedControlID="txtUsername" Text="Tài khoản:" runat="server" />
        <asp:TextBox ID="txtUsername" Width="340" CssClass="validate[required]" MaxLength="50" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="txtEmail" Text="Email:" runat="server" />
        <asp:TextBox ID="txtEmail" Width="340" CssClass="validate[required,custom[email]]" MaxLength="110" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="ddlRole" Text="Quyền truy cập:" runat="server" />
        <asp:TextBox ID="txtRole" CssClass="validate[required] decoy" Width="340" runat="server" />
        <asp:DropDownList ID="ddlRole" CssClass="dropdown" Width="346" runat="server">
            <asp:ListItem Value="" Text="[Chọn quyền truy cập]" />
        </asp:DropDownList>
    </li>
    <li style="margin:10px 0;border-bottom:1px dotted #333;">
        Các thông tin dành cho quản lý tài khoản. Có dấu <b>*</b> là bắt buộc.
    </li>
    <li>
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
            <asp:HyperLink NavigateUrl="~/Account/SysAdmin/User/ViewUser.aspx" Text="Quay lại" CssClass="button-back" runat="server" />
            <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[updateUserHelpBox]" runat="server" />
            <asp:LinkButton ID="btnUpdate" Text="Khởi tạo" CssClass="button-ok" runat="server"
                OnClientClick="return checkValidation()" OnClick="btnUpdate_Click" />
        </div>
        <div class="clear"></div>
    </li>
</ul>