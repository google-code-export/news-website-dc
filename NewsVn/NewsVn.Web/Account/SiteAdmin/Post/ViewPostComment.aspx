<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewPostComment.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.ViewPostComment" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#commentContentBox").dialog({
                autoOpen: false,
                resizable: false,
                modal: true,
                width: 500
            });
        });
        
        function viewCommentContent(id) {
            var dataObj = { commentID: id }
            $.ajax({
                url: serviceUrl + "ViewCommentContent",
                data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
                success: function (result) {
                    $("#commentContentBox").html(result.d);
                },
                complete: function () {
                    $("#commentContentBox").dialog("open");
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div id="commentContentBox" class="dialog" title="Nội dung bình luận" style="display:none">
        <p></p>
    </div>
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
                    <th>Tiêu đề</th>
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
                        <a href='javascript:viewCommentContent(<%# Eval("ID") %>)' title='<%# Eval("Title") %>'>
                            <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("Title").ToString(), 30) %>
                        </a>               
                    </td>
                    <td>
                        <a href='<%# HostName + Eval("PostUrl") %>' title='<%# Eval("PostTitle") %>' target="_blank">
                            <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("PostTitle").ToString(), 30) %>
                        </a>
                    </td>
                    <td>
                        <%# Eval("Email") %>
                    </td>
                    <td>
                        <%# Eval("UpdatedBy") %>
                    </td>
                    <td>
                        <%# Eval("UpdatedOn", "{0:dd/MM/yy hh:mm}") %>
                    </td>
                </tr>
            </ItemTemplate>
        <FooterTemplate>
            </table>            
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>