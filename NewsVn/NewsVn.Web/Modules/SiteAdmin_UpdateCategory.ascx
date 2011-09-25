<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdmin_UpdateCategory.ascx.cs" Inherits="NewsVn.Web.Modules.SiteAdmin_UpdateCategory" %>

<script type="text/javascript">
    $(function () {
        $("#<%= ddlParentCategory.ClientID %>").change(function () {
            $(this).prev(".decoy").val($(this).val());
        });
        $("#<%= txtDescription.ClientID %>").maxlength({ maxCharacters: 300, status: false, showAlert: true });
    });
    function checkValidation() {
        return $("#update_category_form").validationEngine('validate');
    }
</script>

<div id="updateCategoryHelpBox" class="dialog" title="Trợ giúp">
</div>
<ul id="update_category_form" class="ui-form ui-widget main" style="width:766px">
    <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
    <li>
        <asp:Label AssociatedControlID="txtName" Text="Tên danh mục:" runat="server" />
        <asp:TextBox ID="txtName" Width="450" CssClass="validate[required]" runat="server" />
    </li>    
    <li>
        <asp:Label AssociatedControlID="ddlParentCategory" Text="Danh mục cha:" runat="server" />
        <asp:TextBox ID="txtParentCategory" CssClass="validate[required] decoy" Width="450" runat="server" />
        <asp:DropDownList ID="ddlParentCategory" CssClass="dropdown" Width="456" runat="server">
            <asp:ListItem Value="" Text="[Chọn danh mục cha]" />
        </asp:DropDownList>
    </li>
    <li>
        <label></label>
        <asp:Label AssociatedControlID="chkActived" Text="Cho phép hiển thị:" CssClass="checkbox-label" runat="server" />
        <asp:CheckBox ID="chkActived" Checked="true" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="txtDescription" Text="Mô tả:" runat="server" />
        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="5" Rows="8" Width="650" CssClass="validate[required]"  runat="server" />
    </li>    
    <li class="commands">
        <div class="right">
            <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ViewCategory.aspx" Text="Quay lại" CssClass="button-back" runat="server" />
            <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[updateCategoryHelpBox]" runat="server" />
            <asp:LinkButton ID="btnUpdate" Text="Lưu" CssClass="button-ok" runat="server"
                OnClientClick="return checkValidation()" OnClick="btnUpdate_Click" />
        </div>
        <div class="clear"></div>
    </li>
</ul>