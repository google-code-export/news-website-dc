<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master"
    AutoEventWireup="true" CodeBehind="EditAdPostPosition.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Misc.EditAdPostPosition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">
<script type="text/javascript">
    function ConfirmDelete(id) {
        if (confirm('Bạn có muốn xóa banner này không?')) {
            $("#<%=hidDel.ClientID %>").val(id);
            return true;
        }
        return false;
    }
</script>
    <div class="portlet">
        <h2>
            vị trí:
            <%= bannerPosition%></h2>
        Loại Banner:
        <asp:DropDownList ID="ddlBannerType" runat="server">
        </asp:DropDownList>
        <h2>
            Danh sách các Banner</h2>
        <asp:Repeater ID="rptCurrentBannerList" runat="server" 
            onitemdatabound="rptCurrentBannerList_ItemDataBound">
            <HeaderTemplate>
                <table id="post-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            ID
                        </th>
                        <th>
                            Vị trí
                        </th>
                        <th>
                            Tiêu đề
                        </th>
                        <th>
                            Chiều rộng
                        </th>
                        <th>
                            Chiều cao
                        </th>
                        <th>
                            Url
                        </th>
                        <th>
                            Hình ảnh
                        </th>
                        <th>
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='<%= HostName + "account/siteadmin/misc/editbannerdetail.aspx?bannerid=" %><%# Eval("ID") %>'
                            title='<%# Eval("ID") %>'>
                            <%# Eval("ID") %>
                        </a>
                    </td>
                    <td>
                        <%# Eval("BannerPosition") %>
                    </td>
                    <td>
                        <%# Eval("Title") %>
                    </td>
                    <td>
                        <%# Eval("Width") %>
                    </td>
                    <td>
                        <%# Eval("Height") %>
                    </td>
                    <td>
                        <a target='_blank'  href='<%# Eval("Url") %>' title='<%# Eval("Title") %>'>
                            <%# Eval("Title")%>
                        </a>
                    </td>
                    <td>
                        <img width="200" height="60" src=' <%# Eval("Url") %>' alt='<%# Eval("Title") %>' />
                    </td>
                    <td>
                        <a href='<%= HostName + "account/siteadmin/misc/editbannerdetail.aspx?bannerid=" %><%# Eval("ID") %>'
                            title='<%# Eval("ID") %>'>Chỉnh sửa
                        </a>|
                        <asp:LinkButton ID="lbtnDel" runat="server" onclick="lbtnDel_Click">Xóa</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <ul id="update_category_form" class="ui-form ui-widget main" style="width: 766px">
            <li class="commands">
                <div class="right">
                    <asp:LinkButton ID="btnInsert" Text="Thêm banner" CssClass="button-ok" 
                        runat="server" onclick="btnInsert_Click" />
                    <a href="ViewAdBox.aspx" class="button-back">Hủy</a>
                </div>
                <div class="clear">
                </div>
            </li>
        </ul>
    </div>
     <asp:HiddenField ID="hidDel" runat="server" Value="0" />
</asp:Content>
