<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.ViewPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div class="ui-table-toolbar">
        <asp:HyperLink NavigateUrl="#" Text="Thêm" CssClass="button-add left" runat="server" />
        <asp:HyperLink NavigateUrl="#" Text="Sửa" CssClass="button-edit left" runat="server" />
        <asp:HyperLink NavigateUrl="#" Text="Xóa" CssClass="button-delete left" runat="server" />
        <asp:HyperLink NavigateUrl="#" Text="Nạp lại" CssClass="button-refresh right" runat="server" />
        <div class="clear"></div>
        <hr />
        <asp:DropDownList ID="ddlFilterColumn" CssClass="dropdown left" runat="server">
            <asp:ListItem Text="Tiêu đề" />
            <asp:ListItem Text="Người tạo" />
        </asp:DropDownList>
        <asp:DropDownList ID="ddlFilterOption" CssClass="dropdown left" runat="server">
            <asp:ListItem Text="Chính xác" />
            <asp:ListItem Text="Tương đối" />
        </asp:DropDownList>
        <asp:TextBox CssClass="left" Width="150" runat="server" />
        <asp:HyperLink NavigateUrl="#" Text="Lọc danh sách" CssClass="button left" runat="server" />
        <div class="right">
            Trang:
            <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged" />
            &nbsp;Số dòng/Trang:
            <asp:DropDownList ID="ddlPageSize" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged">
                <asp:ListItem Value="15" Text="15" />
                <asp:ListItem Value="25" Text="25" />
                <asp:ListItem Value="35" Text="35" />
                <asp:ListItem Value="45" Text="45" />
                <asp:ListItem Value="55" Text="55" />
            </asp:DropDownList>
        </div>
        <div class="clear"></div>
    </div>    
    <asp:Repeater ID="rptPostList" runat="server">
        <HeaderTemplate>
            <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox EnableViewState="false" runat="server" /></th>
                    <th>Tiêu đề</th>
                    <th>Tạo lúc</th>
                    <th>Người tạo</th>
                    <th>Sửa lúc</th>
                    <th>Người sửa</th>
                    <th>Đã duyệt</th>
                    <th>Duyệt lúc</th>
                    <th>Duyệt bởi</th>
                    <th>Hiển thị</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:CheckBox EnableViewState="false" runat="server" /></td>
                <td>
                    <asp:HyperLink NavigateUrl='<%# Eval("SeoUrl") %>' runat="server">
                        <%# Eval("Title") %>
                    </asp:HyperLink>
                </td>
                <td><%# Eval("CreatedOn", "{0:dd/MM/yy HH:ss}") %></td>
                <td><%# Eval("CreatedBy") %></td>
                <td><%# Eval("UpdatedOn", "{0:dd/MM/yy HH:ss}")%></td>
                <td><%# Eval("UpdatedBy") %></td>
                <td align="center"><asp:CheckBox Checked='<%# Eval("Approved") %>' Enabled="false" runat="server" /></td>
                <td><%# Eval("ApprovedOn", "{0:dd/MM/yy HH:ss}")%></td>
                <td><%# Eval("ApprovedBy") %></td>
                <td align="center"><asp:CheckBox Checked='<%# Eval("Actived") %>' Enabled="false" runat="server" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
