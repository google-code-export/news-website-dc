<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewPostComment.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.ViewPostComment" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div class="ui-table-toolbar">
        <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete left" runat="server"
            OnClientClick="return confirmDelete()" OnClick="btnDelete_Click" />
        <asp:HyperLink Text="Trợ giúp" CssClass="button-help left dialog-trigger[postHelpBox]" runat="server" />
        <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh right" runat="server"
            OnClick="btnRefresh_Click" />
    </div>
    <asp:Repeater ID="rptCommentList" runat="server">
        <HeaderTemplate>
            <table id="post-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox EnableViewState="false" runat="server" /></th>
                    <th>Tiêu đề</th
                    <th>Bài viết</th>
                    <th>Email</th>
                    <th>Người gởi</th>
                    <th>Gởi vào</th>
                </tr>
        </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="chkID" EnableViewState="false" runat="server" />
                        <asp:HiddenField ID="hidID" Value='<%# Eval("ID") %>' runat="server" /> 
                    </td>
                    <td>
                        <%# Eval("Title") %>                        
                    </td>
                    <td>
                        <a href='<%= HostName + "account/siteadmin/post/editpost.aspx?pid=" %><%# Eval("PostID") %>'
                            title='<%# Eval("PostTitle") %>'>
                            <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("PostTitle").ToString(), 30) %>
                        </a>
                    </td>
                    <td>
                        <%# Eval("Email") %>
                    </td>
                    <td>
                        <%# Eval("CreatedBy") %>
                    </td>
                    <td>
                        <%# Eval("CreatedOn", "{0:dd/MM/yy hh:mm}") %>
                    </td>
                </tr>
            </ItemTemplate>
        <FooterTemplate>
            </table>            
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>