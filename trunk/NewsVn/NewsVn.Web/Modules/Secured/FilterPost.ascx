<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterPost.ascx.cs" Inherits="NewsVn.Web.Modules.Secured.FilterPost" %>

<script type="text/javascript">
    $(function () {
        // This is to fix bug related to jquery ui dialog
        // is not rendered inside asp.net form tag
        // cause server controls lose values on postback
        $("#filterBox").parent().appendTo("#filterBoxContainer");
    });     
</script>

<div id="postFilterHelpBox" class="dialog" title="Trợ giúp">
    Filter Hint
</div>
<div id="filterBoxContainer"></div>
<div id="filterBox" class="dialog" title="Lọc danh sách tin tức">
    <asp:Panel DefaultButton="btnFilter" runat="server">
        <ul class="ui-form ui-widget">
            <li>
                <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" runat="server" />
                <asp:TextBox ID="txtTitle" runat="server" />
            </li>
            <li>
                <asp:Label AssociatedControlID="txtCategoryName" Text="Danh mục:" runat="server" />
                <asp:TextBox ID="txtCategoryName" runat="server" />
            </li>
            <li>
                <asp:Label AssociatedControlID="txtUpdatedBy" Text="Người cập nhật:" runat="server" />
                <asp:TextBox ID="txtUpdatedBy" runat="server" />
            </li>
            <li>
                <asp:Label AssociatedControlID="txtUpdatedOn" Text="Ngày cập nhật:" runat="server" />            
                <div class="textbox-icon right">
                    <asp:TextBox ID="txtUpdatedOn" CssClass="datepicker" runat="server" />
                </div>
                <div class="clear"></div>
            </li>
            <li>
                <asp:Label AssociatedControlID="txtApprovedBy" Text="Người duyệt:" runat="server" />
                <asp:TextBox ID="txtApprovedBy" runat="server" />
            </li>
            <li>
                <asp:Label AssociatedControlID="txtApprovedOn" Text="Ngày duyệt:" runat="server" />            
                <div class="textbox-icon right">
                    <asp:TextBox ID="txtApprovedOn" CssClass="datepicker" runat="server" />
                </div>
                <div class="clear"></div>
            </li>
            <li>
                <asp:Label AssociatedControlID="ddlFilterMethod" Text="Phương pháp:" runat="server" />
                <asp:DropDownList ID="ddlFilterMethod" CssClass="dropdown" Width="276" runat="server">
                    <asp:ListItem Value="Relative" Text="Lọc tương đối" />
                    <asp:ListItem Value="Absolute" Text="Lọc tuyệt đối" />
                </asp:DropDownList>
            </li>
            <li>
                <asp:Label AssociatedControlID="ddlFilterChain" Text="Kết điều kiện:" runat="server" />
                <asp:DropDownList ID="ddlFilterChain" CssClass="dropdown" Width="276" runat="server">
                    <asp:ListItem Value="LinkOne" Text="Lọc theo từng điều kiện" />
                    <asp:ListItem Value="LinkAll" Text="Lọc theo tất cả điều kiện" />
                </asp:DropDownList>
            </li>
            <li class="commands">
                <div class="right">
                    <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[postFilterHelpBox]" runat="server" />
                    <asp:LinkButton ID="btnFilter" Text="Lọc danh sách" CssClass="button-filter" 
                        runat="server" onclick="btnFilter_Click" />
                </div>
                <div class="clear"></div>
            </li>
        </ul>
    </asp:Panel>
</div>
