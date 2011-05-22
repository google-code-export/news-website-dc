<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedAdPostList.ascx.cs" Inherits="NewsVn.Web.Modules.RelatedAdPostList" %>
<script type="text/javascript">
    $(function () {
        $(".related-posts .post-item-list li:first-child").addClass("head");
    });
</script>

<div class="portlet related-posts">
    <h2>Các tin khác</h2>
    <ul class="post-item-list">
        <asp:Repeater runat="server" ID="rptAdsRelated" 
            onitemdatabound="rptAdsRelated_ItemDataBound">
            <ItemTemplate>
                <li>
                    <a href='' class="post-title inline"><%#Eval("Title") %></a>
                    <span class="post-info right"><%# string.Format("{0:dd/MM/yyyy}", Eval("CreatedOn")) %></span>
                    <div class="clear"></div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                <div style="text-align:center; padding-top:6px;"><asp:Label runat="server" ID="lblEmpty" Visible="false" Text="Không tìm thấy bài viết"></asp:Label></div>
            </FooterTemplate>
        </asp:Repeater>
    </ul>
</div>