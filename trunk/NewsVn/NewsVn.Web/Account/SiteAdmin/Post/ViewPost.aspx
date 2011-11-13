<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.ViewPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">    
    <nsn:FilterPost ID="fpViewPost" runat="server"
        OnFiltered="fpViewPost_Filtered" />
    <div id="postHelpBox" class="dialog" title="Trợ giúp">
        <p><b>Thêm tin mới</b>: Bấm vào nút 'Thêm'</p>
        <p><b>Sửa tin</b>: Bấm vào tiêu đề của một tin bất kỳ</p>
        <p><b>Xóa tin</b>: Chọn các dòng muốn xóa trong danh sách tin, sau đó bấm nút 'Xóa'</p>
        <p><b>Ẩn/Hiện tin</b>: Chọn các dòng trong danh sách tin, bấm nút 'Ẩn/Hiện'</p>
        <p><b>Duyệt tin</b>: Chọn các dòng trong danh sách tin, bấm 'Duyệt'</p>
    </div>
    <div class="ui-table-toolbar">
        <ul class="ui-form ui-widget">
            <asp:Literal ID="ltrInfo" EnableViewState="false" runat="server" />
            <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
        </ul>
        <div class="left">
            <asp:HyperLink ID="btnAdd" Text="Thêm" CssClass="button-add" runat="server"
                NavigateUrl="~/Account/SiteAdmin/Post/AddPost.aspx" />
            <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete" runat="server"
                OnClientClick="return confirmAction('Xóa tin được chọn?')" OnClick="btnDelete_Click" />
            <asp:LinkButton ID="btnToggleActive" Text="Ẩn/Hiện" CssClass="button-toggle" runat="server"
                OnClientClick="return confirmAction('Ẩn/Hiện tin được chọn?')" OnClick="btnToggleActive_Click" />
            <asp:LinkButton ID="btnApprove" Text="Duyệt" CssClass="button-ok" runat="server"
                OnClientClick="return confirmAction('Duyệt tin được chọn?')" OnClick="btnApprove_Click" />
            <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[postHelpBox]" runat="server" />
        </div>
        <div class="right">
            <b><asp:Literal ID="ltrPostCount" runat="server" /></b>&nbsp;&nbsp;
            <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh" runat="server"
            OnClick="btnRefresh_Click" />
        </div>
        <div class="clear"></div>
        <hr />
        <div class="left">
            Sắp xếp theo:
            <asp:DropDownList ID="ddlSortColumn" CssClass="dropdown" Width="120px" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Sorter_SelectedIndexChanged">
                <asp:ListItem Value="Title" Text="Tiêu đề" />
                <asp:ListItem Value="PageView" Text="Lượt xem" />
                <asp:ListItem Value="Category.Name" Text="Danh mục" />                
                <asp:ListItem Value="CreatedOn" Text="Ngày đăng" />
                <asp:ListItem Value="CreatedBy" Text="Người đăng" />                               
                <asp:ListItem Value="UpdatedOn" Text="Ngày sửa" />
                <asp:ListItem Value="UpdatedBy" Text="Người sửa" />
                <asp:ListItem Value="ApprovedOn" Text="Ngày duyệt" />
                <asp:ListItem Value="ApprovedBy" Text="Người duyệt" />
            </asp:DropDownList>
            <asp:DropDownList ID="ddlSortDirection" CssClass="dropdown" Width="70px" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Sorter_SelectedIndexChanged">
                <asp:ListItem Value="ASC" Text="A -> Z" />
                <asp:ListItem Value="DESC" Text="Z -> A" />
            </asp:DropDownList>
            <asp:LinkButton ID="btnClearSort" CssClass="button-clear" Text="Bỏ sắp xếp" Visible="false" 
                runat="server" onclick="btnClearSort_Click" />
            <asp:HyperLink ID="lnkFilter" Text="Lọc tin tức" CssClass="button-filter dialog-trigger[filterBox]" runat="server" />
            <asp:LinkButton ID="btnClearFilter" CssClass="button-clear" Text="Bỏ lọc" Visible="false" 
                runat="server" onclick="btnClearFilter_Click" />
        </div>
        <div class="right">
            Trang:
            <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" Width="50" runat="server"
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
    <asp:Repeater ID="rptPostList" runat="server">
        <HeaderTemplate>
            <table id="post-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox EnableViewState="false" runat="server" /></th>
                    <% if (OrderColumn.Equals("Title", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Tiêu đề</th>
                    <% } else { %>
                    <th>Tiêu đề</th>
                    <% } %>
                    <% if (OrderColumn.Equals("PageView", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Lượt xem</th>
                    <% } else { %>
                    <th>Lượt xem</th>
                    <% } %>
                    <% if (OrderColumn.Equals("Category.Name", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Danh mục</th>
                    <% } else { %>
                    <th>Danh mục</th>
                    <% } %>
                    <% if (OrderColumn.Equals("CreatedOn", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Đăng vào</th>
                    <% } else { %>
                    <th>Đăng vào</th>
                    <% } %>
                    <% if (OrderColumn.Equals("CreatedBy", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Đăng bởi</th>
                    <% } else { %>
                    <th>Đăng bởi</th>
                    <% } %>
                    <% if (OrderColumn.Equals("UpdatedOn", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Sửa vào</th>
                    <% } else { %>
                    <th>Sửa vào</th>
                    <% } %>
                    <% if (OrderColumn.Equals("UpdatedBy", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Sừa bởi</th>
                    <% } else { %>
                    <th>Sừa bởi</th>
                    <% } %>
                    <th>Đã duyệt</th>
                    <% if (OrderColumn.Equals("ApprovedOn", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Duyệt vào</th>
                    <% } else { %>
                    <th>Duyệt vào</th>
                    <% } %>
                    <% if (OrderColumn.Equals("ApprovedBy", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Duyệt bởi</th>
                    <% } else { %>
                    <th>Duyệt bởi</th>
                    <% } %>
                    <th>Hiển thị</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="chkID" EnableViewState="false" runat="server"  />
                    <asp:HiddenField ID="hidID" Value='<%# Eval("ID") %>' runat="server" /> 
                </td>
                <td>
                    <a href='<%= HostName + "account/siteadmin/post/editpost.aspx?pid=" %><%# Eval("ID") %>'
                        class='<%# Eval("TitleCssClass") %>' title='<%# Eval("Title") %>'>
                        <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("Title"), 30) %>
                    </a>
                </td>
                <td align="center"><%#Eval("PageView", "{0:N0}") %></td>
                <td>
                    <a href='<%= HostName + "account/siteadmin/post/editcategory.aspx?cid=" %><%# Eval("CategoryID") %>'
                        title='<%# Eval("CategoryName") %>'>
                        <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("CategoryName"), 30) %>
                    </a>
                </td>
                <td title='<%# Eval("CreatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("CreatedOn", "{0:dd/MM/yy}")%>
                </td>
                <td title='<%# Eval("CreatedBy")%>'>
                    <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("CreatedBy"), 20)%>
                </td>
                <td title='<%# Eval("UpdatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("UpdatedOn", "{0:dd/MM/yy}")%>
                </td>
                <td title='<%# Eval("UpdatedBy")%>'>
                    <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("UpdatedBy"), 20)%>
                </td>
                <td align="center"><asp:CheckBox Checked='<%# Eval("Approved") %>' Enabled="false" runat="server" /></td>
                <td title='<%# Eval("ApprovedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("ApprovedOn", "{0:dd/MM/yy}")%>
                </td>
                <td title='<%# Eval("ApprovedBy")%>'>
                    <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("ApprovedBy"), 20)%>
                </td>
                <td align="center"><asp:CheckBox Checked='<%# Eval("Actived") %>' Enabled="false" runat="server" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
