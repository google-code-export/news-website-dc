﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdmin_UpdatePost.ascx.cs" Inherits="NewsVn.Web.Modules.SiteAdmin_UpdatePost" %>

<script type="text/javascript">
    $(function () {
        $("#<%= txtCategory.ClientID %>").hide();
        $("#<%= ddlCategory.ClientID %>").change(function () {
            $(this).prev(".decoy").val($(this).val());
        });
    });
    $(function () {
        $("#<%= txtDescription.ClientID %>").maxlength({ maxCharacters:295,status: false, showAlert: true }); ;
    });
    function checkValidation() {
        return $("#update_post_form").validationEngine('validate');
    }
    function PreventMaxLength(Object, MaxLen) {
        if (Object.value.length >= MaxLen) { return false; }
    }
    function PreventMaxLengthPaste(Object, MaxLen) {
        event.returnValue = false;
        if ((Object.value.length + window.clipboardData.getData("Text").length) >= MaxLen) {
            return false;
        }
        event.returnValue = true;
    }
</script>

<div id="updatePostHelpBox" class="dialog" title="Trợ giúp">
</div>
<ul id="update_post_form" class="ui-form ui-widget">
    <li>
        <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" runat="server" />
        <asp:TextBox ID="txtTitle" Width="450" CssClass="validate[required]" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="txtAvatar" Text="Hình đại diện:" runat="server" />
        <asp:TextBox ID="txtAvatar" Width="450" CssClass="validate[required]" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="ddlCategory" Text="Danh mục:" runat="server" />
        <asp:TextBox ID="txtCategory" CssClass="validate[required] decoy" runat="server" />
        <asp:DropDownList ID="ddlCategory" CssClass="dropdown" Width="456" runat="server">
            <asp:ListItem Value="" Text="[Chọn danh mục]" />
        </asp:DropDownList>        
    </li>
    <li>
        <label></label>
        <asp:Label AssociatedControlID="chkActived" Text="Cho phép hiển thị:" CssClass="checkbox-label" runat="server" />
        <asp:CheckBox ID="chkActived" Checked="true" runat="server" />
        &nbsp;|&nbsp;
        <asp:Label AssociatedControlID="chkAllowComments" Text="Cho phép bình luận:" CssClass="checkbox-label" runat="server" />
        <asp:CheckBox ID="chkAllowComments" Checked="true" runat="server" />
        &nbsp;|&nbsp;
        <asp:Label AssociatedControlID="chkCheckPageView" Text="Theo dõi lượt truy cập:" CssClass="checkbox-label" runat="server" />
        <asp:CheckBox ID="chkCheckPageView" Checked="true" runat="server" />
        <asp:CheckBox ID="chkApproved" Checked="true" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="txtDescription" Text="Mô tả:" runat="server" />
        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="5" Rows="8" Width="650" CssClass="validate[required]" runat="server"
        />
    </li>
    <li>
        <p><asp:Label AssociatedControlID="editorContent" Text="Nội dung:" runat="server" /></p>
        <nsn:Editor ID="editorContent" runat="server" AutoConfigure="Default" CssClass="validate[required]"
            Height="550px" Width="100%" ContextMenuMode="Default" ShowDecreaseButton="False" 
            ShowEnlargeButton="False" ShowGroupMenuImage="False" FilesPath="" Text="" />
    </li>
    <li class="commands">
        <div class="right">
            <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ViewPost.aspx" Text="Quay lại" CssClass="button-back" runat="server" />
            <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[updatePostHelpBox]" runat="server" />
            <asp:LinkButton ID="btnUpdate" Text="Lưu" CssClass="button-ok" runat="server"
                OnClientClick="return checkValidation()" OnClick="btnUpdate_Click" />
        </div>
        <div class="clear"></div>
    </li>
</ul>