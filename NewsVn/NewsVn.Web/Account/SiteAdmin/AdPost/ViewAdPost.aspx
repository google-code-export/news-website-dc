<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewAdPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.AdPost.ViewAdPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <nsn:FilterAdPost OnFiltered="fpViewAdPost_Filtered" runat="server" />
    <div id="adpostHelpBox" class="dialog" title="Trợ giúp">
        <p><b>Sửa rao nhanh</b>: Bấm vào tiêu đề của một tin bất kỳ</p>
        <p><b>Xóa rao nhanh</b>: Chọn các dòng muốn xóa trong danh sách tin, sau đó bấm nút 'Xóa'</p>
        <p><b>Ẩn/Hiện rao nhanh</b>: Chọn các dòng trong danh sách tin, bấm nút 'Ẩn/Hiện'</p>
    </div>
    <div class="ui-table-toolbar">
        <ul class="ui-form ui-widget">
            <asp:Literal ID="ltrInfo" EnableViewState="false" runat="server" />
            <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
        </ul>
        <div class="left">
            <asp:HyperLink ID="btnAdd" Text="Thêm" CssClass="button-add" runat="server"
                NavigateUrl="~/rao-nhanh-dang-ky.aspx" Target="_blank" />
            <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete" runat="server"
                OnClientClick="return confirmAction('Xóa rao nhanh được chọn?')" OnClick="btnDelete_Click" />
            <asp:LinkButton ID="btnToggleActive" Text="Ẩn/Hiện" CssClass="button-toggle" runat="server"
                OnClientClick="return confirmAction('Ẩn/Hiện rao nhanh được chọn?')" OnClick="btnToggleActive_Click" />        
            <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[adpostHelpBox]" runat="server" />    
        </div>
        <div class="right">
            <b><asp:Literal ID="ltrAdPostCount" runat="server" /></b>&nbsp;&nbsp;
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
                <asp:ListItem Value="Category.Name" Text="Danh mục" />                
                <asp:ListItem Value="CreatedOn" Text="Ngày đăng" />
                <asp:ListItem Value="CreatedBy" Text="Người đăng" />                               
                <asp:ListItem Value="UpdatedOn" Text="Ngày sửa" />
                <asp:ListItem Value="UpdatedBy" Text="Người sửa" />
            </asp:DropDownList>
            <asp:DropDownList ID="ddlSortDirection" CssClass="dropdown" Width="70px" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Sorter_SelectedIndexChanged">
                <asp:ListItem Value="ASC" Text="A -> Z" />
                <asp:ListItem Value="DESC" Text="Z -> A" />
            </asp:DropDownList>
            <asp:LinkButton ID="btnClearSort" CssClass="button-clear" Text="Bỏ sắp xếp" Visible="false" 
                runat="server" onclick="btnClearSort_Click" />
            <asp:HyperLink ID="lnkFilter" Text="Lọc rao nhanh" CssClass="button-filter dialog-trigger[filterBox]" runat="server" />
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
    <asp:Repeater ID="rptAdPostList" runat="server">
        <HeaderTemplate>
            <table id="post-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox EnableViewState="false" runat="server" /></th>                    
                    <% if (OrderColumn.Equals("Title", StringComparison.OrdinalIgnoreCase)) { %>
                    <th class='sorted-<%= OrderDirection %>'>Tiêu đề</th>
                    <% } else { %>
                    <th>Tiêu đề</th>
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
                    <th>Hết hạn</th>
                    <th>Hiển thị</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:CheckBox ID="chkID" EnableViewState="false" runat="server"  />
                    <asp:HiddenField ID="hidID" Value='<%# Eval("ID") %>' runat="server" /> 
                </td>
                <td style="width:300px">
                    <!--href='<%= HostName + "account/siteadmin/adpost/editadpost.aspx?pid=" %><%# Eval("ID") %>'-->
                    <a class="<%# Eval("TitleCssClass") %>"
                        href='#'
                        title='<%# Eval("Title") %>'>
                        <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("Title"), 40) %>    
                    </a>
                </td>                
                <td style="width:200px">
                    <a href='<%= HostName + "account/siteadmin/adpost/editcategory.aspx?cid=" %><%# Eval("CategoryID") %>'
                        title='<%# Eval("CategoryName") %>'>
                        <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("CategoryName"), 30) %>
                    </a>
                </td>
                <td title='<%# Eval("CreatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("CreatedOn", "{0:dd/MM/yy}")%>
                </td>
                <td style="width:150px" title='<%# Eval("CreatedBy")%>'>
                    <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("CreatedBy"), 20)%>
                </td>
                <td title='<%# Eval("UpdatedOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("UpdatedOn", "{0:dd/MM/yy}")%>
                </td>
                <td style="width:30px" title='<%# Eval("UpdatedBy")%>'>
                    <%# NewsVn.Web.Utils.clsCommon.getEllipsisText(Eval("UpdatedBy"), 20)%>
                </td>
                <td title='<%# Eval("ExpiredOn", "{0:dd/MM/yy HH:mm:ss}") %>'>
                    <%# Eval("ExpiredOn", "{0:dd/MM/yy}")%>
                </td>
                <td align="center"><asp:CheckBox Checked='<%# Eval("Actived") %>' Enabled="false" runat="server" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
