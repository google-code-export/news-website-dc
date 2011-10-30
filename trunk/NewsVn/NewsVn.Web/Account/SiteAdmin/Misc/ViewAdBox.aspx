<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ViewAdBox.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Misc.ViewAdBox" %>
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
        <h2>Danh sách các vị trí Banner quảng cáo</h2>
        <asp:Repeater ID="rptBannerPositon" runat="server">
        <HeaderTemplate>
            <table id="post-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th>Vị trí Banner</th>
                    <th>Loại banner</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href='<%= HostName + "account/siteadmin/misc/editadpostposition.aspx?pid=" %><%# Eval("PositionID") +"&tid=" %> <%#Eval("TypeID")%>'
                     title='<%# Eval("bannerPosition") %>'><%# Eval("bannerPosition") %>
                    </a>
                </td>
                <td>
                    <%# Eval("bannerType") %>
                </td>                
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
</br>
<div class="portlet">
        <h2>Danh sách các Banner quảng cáo hiện tại</h2>
         <asp:Repeater ID="rptCurrentBannerList" runat="server" 
            onitemdatabound="rptCurrentBannerList_ItemDataBound">
        <HeaderTemplate>
            <table id="post-table" class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th>ID</th>
                    <th>Vị trí</th>
                    <th>Tiêu đề</th>
                    <th>Chiều rộng</th>
                    <th>Chiều cao</th>
                    <th>Hình ảnh</th>
                    <th>Url</th>
                    <th></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href='<%= HostName + "account/siteadmin/misc/editbannerdetail.aspx?bannerid=" %><%# Eval("ID") %>' 
                    title='<%# Eval("ID") %>'> <%# Eval("ID") %>
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
                    <img width="200" height="60" src=' <%# Eval("Url") %>' alt ='<%# Eval("Title") %>' />
                </td>
                 <td >
                    <a target="_blank" href='<%# Eval("Url") %>' title='<%# Eval("Title") %>'>
                       <%# Eval("Title")%>
                    </a>
                </td>
                <td>
                     <a href='<%= HostName + "account/siteadmin/misc/editbannerdetail.aspx?bannerid=" %><%# Eval("ID") %>' 
                    title='<%# Eval("ID") %>'>Chỉnh sửa</a>
                </td>
                 <td>
                   <asp:LinkButton runat="server" ID="lnkbtnDel" Text="Xóa"  onclick="lnkbtnDel_Click"  />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:HiddenField ID="hidDel" runat="server" Value="0" />
</div>  

</asp:Content>
