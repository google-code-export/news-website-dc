<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.ViewPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div style=" background:#FFFFFF;padding: 10px 0 0;position: fixed;top: 0;width: 77.4%;">
        <asp:HyperLink NavigateUrl="#" Text="Thêm" CssClass="button left" runat="server" />
        <asp:HyperLink NavigateUrl="#" Text="Sửa" CssClass="button left" runat="server" />
        <asp:HyperLink NavigateUrl="#" Text="Xóa" CssClass="button left" runat="server" />
        <asp:HyperLink NavigateUrl="#" Text="Nạp lại" CssClass="button right" runat="server" />
        <div class="clear"></div>
        <hr />
    </div>    
    <asp:Repeater ID="rptPostList" runat="server">
        <HeaderTemplate>
            <table style="margin-top:50px" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox runat="server" /></th>
                    <th>Tiêu đề</th>
                    <th>Tạo lúc</th>
                    <th>Người tạo</th>
                    <th>Sửa lúc</th>
                    <th>Người sửa</th>
                    <th>Đã duyệt</th>
                    <td>Duyệt lúc</td>
                    <th>Duyệt bởi</th>
                    <th>Hiển thị</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:CheckBox runat="server" /></td>
                <td><%# Eval("Title") %></td>
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
    <asp:Label ID="noPages" runat="server" />
</asp:Content>
