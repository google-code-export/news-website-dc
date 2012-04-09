<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdFormBox.ascx.cs" Inherits="NewsVn.Web.Modules.AdFormBox" %>

<link href="<%= Page.ResolveUrl("~/styles/validation.css") %>" rel="stylesheet" type="text/css" />
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine-vi.js") %>" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        var linkSelector = $("#<%= ddlCategory.ClientID %>, #<%= ddlLocation.ClientID %>");
        linkSelector.selectmenu({ width: "274px" });
        linkSelector.next(".ui-selectmenu").addClass("select");
        linkSelector.next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $("#<%= ddlCategory.ClientID %>" + "-menu").width(280);
        $("#<%= ddlLocation.ClientID %>" + "-menu").width(280);
        linkSelector.change(function () {
            $(this).prev(".decoy").val($(this).val());
        });
        /* Decoy textboxes are used only to fix validation for styled dropdownlist
        To insert data, please use ddlABC.SelectedValue as usual
        */

        var fileUpload = $("#<%= fileAvatar.ClientID %>");
        fileUpload.css({ opacity: 0 });
        fileUpload.change(function () {
            $("#<%= txtAvatar.ClientID %>").val(fileUpload.val());
        });
    });

    function checkValidation() {
        return $("#adform_box").validationEngine('validate');
    }
</script>

<div id="adform_box" class="portlet">
    <h2>Đăng quảng cáo rao vặt</h2>
    <ul class="ui-form ui-widget">
        <li style="border-bottom:1px dotted #333;">
            Các trường có dấu <b>*</b> là bắt buộc |
            Vui lòng nhập <b>Tiếng Việt Unicode có dấu</b>
        </li><li></li>
        <li>
            <asp:Label ID="Label1" AssociatedControlID="txtTitle" Text="* Tiêu đề:" runat="server" />
            <asp:TextBox ID="txtTitle" Width="534" CssClass="validate[required]" runat="server" />
        </li>
        <li>
        <table><tr>
        <td align="left">
        <asp:Label ID="Label2" AssociatedControlID="editorContent" Text="* Nội dung:" runat="server" />
        </td><td align="right">
        <%--<nsn:Editor ID="editorContent" runat="server" AutoConfigure="Minimal" CssClass="validate[required]"
            Height="250" Width="534" ContextMenuMode="Minimal" ShowDecreaseButton="False" ShowToolBar="false" ShowBottomBar="false"
            ShowEnlargeButton="False" ShowGroupMenuImage="False" FilesPath="" Text="" BreakElement="Br" />--%>
            <asp:TextBox ID="editorContent"  Height="250" Width="534" CssClass="validate[required]" TextMode="MultiLine" Rows="16" runat="server" />
        </td></tr></table>
            
            
        
        </li>
        <li>
            <asp:Label ID="Label3" AssociatedControlID="fileAvatar" Text="Ảnh minh họa:" runat="server" />
            <asp:FileUpload ID="fileAvatar" CssClass="file-upload" runat="server" />
            <asp:TextBox ID="txtAvatar" Width="438" runat="server" />
            <span class="button">Đăng ảnh</span>
        </li>
        <li>
            <asp:Label ID="Label4" AssociatedControlID="ddlCategory" Text="* Phân loại:" runat="server" />
            <asp:TextBox ID="txtCategory" CssClass="validate[required] decoy" runat="server" />
            <asp:DropDownList ID="ddlCategory" runat="server">
                <asp:ListItem Value="" Text="[Chọn loại Quảng cáo Rao vặt]" />
                <asp:ListItem Value="1" Text="Loại..." />
            </asp:DropDownList>            
        </li>
        <li>
            <asp:Label ID="Label5" AssociatedControlID="ddlLocation" Text="* Tỉnh/Thành:" runat="server" />
            <asp:TextBox ID="txtLocation" CssClass="validate[required] decoy" runat="server" />
            <asp:DropDownList ID="ddlLocation" runat="server">
                <asp:ListItem Value="0" Text="[Chọn Tỉnh/Thành]" />
                <asp:ListItem Value="0" Text="Toàn quốc" />
                <asp:ListItem Value="1" Text="Hà Nội" />
                <asp:ListItem Value="2" Text="Hồ Chí Minh" />
                <asp:ListItem Value="3" Text="Các tỉnh miền Bắc" />
                <asp:ListItem Value="4" Text="Các tỉnh miền Nam" />
            </asp:DropDownList>
        </li>        
        <li style="border-bottom:1px dotted #333;"></li><li></li>
        <li>
            <asp:Label ID="Label6" AssociatedControlID="txtContact" Text="* Liên hệ:" runat="server" />
            <asp:TextBox ID="txtContact" CssClass="validate[required]" runat="server" />
        </li>
        <li>
            <asp:Label ID="Label7" AssociatedControlID="txtContactEmail" Text="Email:" runat="server" />
            <asp:TextBox ID="txtContactEmail" CssClass="validate[custom[email]]" runat="server" />
        </li>
        <li>
            <asp:Label ID="Label8" AssociatedControlID="txtContactAddress" Text="Địa chỉ:" runat="server" />
            <asp:TextBox ID="txtContactAddress" runat="server" />
        </li>
        <li>
            <asp:Label ID="Label9" AssociatedControlID="txtContactPhone" Text="Điện thoại:" runat="server" />
            <asp:TextBox ID="txtContactPhone" CssClass="validate[custom[phone2]]" runat="server" />
        </li>
        <li class="commands">
        <div>
                                <asp:Literal ID="ltrInitInfoError" EnableViewState="false" runat="server" />
                            </div>
            <asp:LinkButton ID="btnResetAdPost" Text="Hủy bỏ" CssClass="button-cancel right" runat="server" />
            <asp:LinkButton ID="btnSubmitAdPost" Text="Đăng tin" CssClass="button-ok right" runat="server"
                OnClientClick="return checkValidation();" style="margin-right:5px;" 
                onclick="btnSubmitAdPost_Click" />            
            <div class="clear"></div>
        </li>
    </ul>
    <asp:HiddenField runat="server" ID="hidImagePath" Value="" />
</div>