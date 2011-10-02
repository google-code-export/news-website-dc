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
        <ul class="ui-form ui-widget">
            <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
        </ul>
        <div class="left">
            <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete" runat="server"
                OnClientClick="return confirmAction('Xóa bình luận được chọn?')" OnClick="btnDelete_Click" />
            <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[postHelpBox]" runat="server" />
        </div>        
        <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh right" runat="server"
            OnClick="btnRefresh_Click" />
        <div class="clear"></div>
        <hr />        
        <div class="left">
            Sắp xếp theo:
            <asp:DropDownList ID="ddlSortColumn" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Sorter_SelectedIndexChanged">
                <asp:ListItem Value="Title" Text="Tiêu đề" />
                <asp:ListItem Value="Post.Title" Text="Bài viết" />
                <asp:ListItem Value="Email" Text="Email" />
                <asp:ListItem Value="UpdatedBy" Text="Người gởi" />
                <asp:ListItem Value="UpdatedOn" Text="Ngày gởi" />
            </asp:DropDownList>
            <asp:DropDownList ID="ddlSortDirection" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Sorter_SelectedIndexChanged">
                <asp:ListItem Value="ASC" Text="A -> Z" />
                <asp:ListItem Value="DESC" Text="Z -> A" />
            </asp:DropDownList>
        </div>
        <div class="right">
            Trang:
            <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" runat="server" Width="50"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged" />
            &nbsp;Số dòng/Trang:
            <asp:DropDownList ID="ddlPageSize" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged">
                <asp:ListItem Value="50" Text="50" />
                <asp:ListItem Value="100" Text="100" />
                <asp:ListItem Value="200" Text="200" />
                <asp:ListItem Value="500" Text="500" />
                <asp:ListItem Value="1000" Text="1000" />
            </asp:DropDownList>
        </div>
        <div class="clear"></div>
    </div>
    <asp:Repeater ID="rptCommentList" runat="server">
        <HeaderTemplate>
            <table id="post-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox EnableViewState="false" runat="server" /></th>
                    <% if (OrderColumn.Equals("Title", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Tiêu đề</th>
                    <% } else { %>
                    <th>Tiêu đề</th>
                    <% } %>
                    <% if (OrderColumn.Equals("Post.Title", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Bài viết</th>
                    <% } else { %>
                    <th>Bài viết</th>
                    <% } %>
                    <% if (OrderColumn.Equals("Email", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Email</th>
                    <% } else { %>
                    <th>Email</th>
                    <% } %>
                    <% if (OrderColumn.Equals("UpdatedBy", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Người gởi</th>
                    <% } else { %>
                    <th>Người gởi</th>
                    <% } %>
                    <% if (OrderColumn.Equals("UpdatedOn", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Ngày gởi</th>
                    <% } else { %>
                    <th>Ngày gởi</th>
                    <% } %>
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
                            <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("Title"), 30) %>
                        </a>               
                    </td>
                    <td>
                        <a href='<%# HostName + Eval("PostUrl") %>' title='<%# Eval("PostTitle") %>' target="_blank">
                            <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("PostTitle"), 30) %>
                        </a>
                    </td>
                    <td title='<%# Eval("Email") %>'>
                        <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("Email"), 20) %>
                    </td>
                    <td title='<%# Eval("UpdatedBy") %>'>
                        <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("UpdatedBy"), 20) %>
                    </td>
                    <td title='<%# Eval("UpdatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                        <%# Eval("UpdatedOn", "{0:dd/MM/yy}")%>
                    </td>
                </tr>
            </ItemTemplate>
        <FooterTemplate>
            </table>            
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>