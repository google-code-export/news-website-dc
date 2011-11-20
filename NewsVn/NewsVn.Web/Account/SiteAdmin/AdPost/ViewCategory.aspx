<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewCategory.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.AdPost.ViewCategory" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div id="categoryHelpBox" class="dialog" title="Trợ giúp">

    </div>
    <div class="ui-table-toolbar">
        <ul class="ui-form ui-widget">
            <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
        </ul>
        <asp:HyperLink ID="btnAdd" Text="Thêm" CssClass="button-add left" runat="server"
            NavigateUrl="~/Account/SiteAdmin/AdPost/AddCategory.aspx" />
        <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete left" runat="server"
            OnClientClick="return confirmAction('Xóa danh mục được chọn?')" OnClick="btnDelete_Click" />
        <asp:LinkButton ID="btnToggleActive" Text="Ẩn/Hiện" CssClass="button-toggle left" runat="server"
            OnClientClick="return confirmAction('Ẩn/Hiện danh mục được chọn?')" OnClick="btnToggleActive_Click" />
        <asp:HyperLink Text="Trợ giúp" CssClass="button-help left dialog-trigger[categoryHelpBox]" runat="server" />
        <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh right" runat="server"
            OnClick="btnRefresh_Click" />
        <div class="clear"></div>
    </div>
    <asp:Repeater ID="rptCategoryList" runat="server">
        <HeaderTemplate>
            <table id="category-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox EnableViewState="false" runat="server" /></th>
                    <th>Tên</th>
                    <th>Danh mục cha</th>
                    <th>Tạo vào</th>
                    <th>Sửa vào</th>
                    <th>Hiển thị</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="width:30px">
                    <asp:CheckBox ID="chkID" EnableViewState="false" runat="server" />
                    <asp:HiddenField ID="hidID" Value='<%# Eval("ID") %>' runat="server" />
                </td>
                <td>
                    <a  class="<%# Eval("NameCssClass") %>"
                        href='<%= HostName + "account/siteadmin/adpost/editcategory.aspx?cid=" %><%# Eval("ID") %>'>
                        <%# Eval("Name") %>
                    </a>
                </td>
                <td><%# Eval("ParentName") %></td>
                <td>
                    <%# Eval("UpdatedOn", "{0:dd/MM/yy HH:mm:ss}") %>
                </td>
                <td>
                    <%# Eval("UpdatedOn", "{0:dd/MM/yy HH:mm:ss}") %>
                </td>
                <td style="width:60px" align="center">
                    <asp:CheckBox Checked='<%# Eval("Actived") %>' Enabled="false" runat="server" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
