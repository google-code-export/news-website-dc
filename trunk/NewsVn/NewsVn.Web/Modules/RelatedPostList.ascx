<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RelatedPostList.ascx.cs" Inherits="NewsVn.Web.Modules.RelatedPostList" %>
<script type="text/javascript">
    $(function () {
        $(".related-posts .post-item-list li:first-child").addClass("head");
    });
</script>

<div class="portlet related-posts">
    <h2>Các tin khác</h2>
    <ul class="post-item-list">
     <asp:Repeater ID="rptRelationPost" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%#HostName+Eval("SeoUrl") %>' class="post-title inline"><%#Eval("Title") %></a>
                - <span class="post-info"><%# string.Format("{0:dddd, dd/MM/yyyy}",Eval("ApprovedOn")) %></span>
            </li>
        </ItemTemplate>
     </asp:Repeater>
    </ul>
</div>
