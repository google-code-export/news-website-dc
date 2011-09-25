<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LatestPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.LatestPostsPortlet" %>
<script type="text/javascript">
    $(function () {
        $(".head-latest-post").each(function (index) {
            $(this).removeClass();
            if (index == 0) {
                $(this).addClass("head-latest-post");
            }
        });
    })
</script>
<asp:Panel ID="container" CssClass="latest-posts portlet" runat="server">
    <h2>
        Tin mới nhất
        <a class="rss" href="#"></a>
   </h2>
    <ul class="post-item-list">
    <asp:Repeater runat="server" ID="rptLatestNews" 
            onitemdatabound="rptLatestNews_ItemDataBound">
        <ItemTemplate>
            <li class="head-latest-post">
            <% if (NoComments){ %><asp:Label runat="server" ID="lblNo_Comment" CssClass="post-comment"><%#Eval("Comments")%></asp:Label><% } %>
                <asp:HyperLink runat="server" ID="hlnkTitle" NavigateUrl='<%#HostName + Eval("SeoUrl") %>'
                Text='<%#Eval("Title") %>' CssClass="post-title wrap"/>
                <span class="post-info">
                <asp:Label runat="server" ID="lblTitle" CssClass="cate" Text='<%#Eval("Cat_Name") %>' />
                    <asp:Label ID="lblApproveOn" runat="server" Text='<%#Eval("ApprovedOn", "{0:dddd, dd/MM/yyyy HH:mm}")%>' />
                </span>
            </li>
        </ItemTemplate>
    </asp:Repeater>    
    </ul>
</asp:Panel>