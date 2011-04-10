<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.AdPostsPortlet" %>

<asp:Panel ID="container" CssClass="cate-adposts portlet" Width="465" runat="server">
     <h2>
        <a class="cate-title" href='<%=SeoUrl %>'><%= Title %></a>
        <asp:Repeater runat="server" ID="rptsubCategories">
            <ItemTemplate>
                &raquo; <a style="text-transform:none;" href="javascript:void(0)"><%#Eval("Name") %></a>    
            </ItemTemplate>
        </asp:Repeater>
    </h2>
    <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
        <asp:Repeater ID="rptListAds" runat="server" 
            onitemdatabound="rptListAds_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td style="width:220px;">
                    <asp:HyperLink runat="server" ID="hplnk" />
                    </td>
                    <td><%#string.Format("{0:dd/MM/yyyy}", Eval("CreatedOn")) %></td>
                    <td style="width:120px;"><%#Eval("Location") %></td>
                </tr>        
            </ItemTemplate>
            <FooterTemplate>
                <div style="text-align:center; padding-top:6px;"><asp:Label runat="server" ID="lblEmpty" Visible="false" Text="Không tìm thấy bài viết"></asp:Label></div>
            </FooterTemplate>
        </asp:Repeater>
    </table>
    <p>
        <a class="right" href="../adsubcategory.aspx">&raquo; Các tin khác</a>
    </p>
</asp:Panel>