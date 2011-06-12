<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.AdPostsPortlet" %>


<asp:Panel ID="container" CssClass="cate-adposts portlet" Width="465" runat="server">
     <h2>
        <a id="lnkCatTitle" class="cate-title" href='javascript:void(0);'><%= Title %><input type="hidden" id="hidSeoUrl" value='<%= SeoName%>' /></a>
        
        <asp:Repeater runat="server" ID="rptsubCategories">
            <ItemTemplate>
                &raquo; <a id="lnkCatTitle" style="text-transform:none;" href="javascript:void(0);"><%#Eval("Name") %><input type="hidden" id="hidSeoUrl" value='<%#Eval("SeoName") %>' /></a>    
                
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
                    <td><%#string.Format("{0:dd/MM/yyyy}", Eval("CreatedOn"))%></td>
                    <td style="width:120px;"><%# NewsVn.Web.Utils.clsCommon.getLocationName(int.Parse(Eval("Location").ToString())) %></td>
                </tr>        
            </ItemTemplate>
            <FooterTemplate>
                <div style="text-align:center; padding-top:6px;">
                    <asp:Label runat="server" ID="lblEmpty" Visible="false" Text="Không tìm thấy bài viết"></asp:Label>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </table>
    <p>
        <a class="right" id="lnkOthersAds" href='<%=SeoUrl %>'>&raquo; Các tin khác</a>
    </p>
</asp:Panel>