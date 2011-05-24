<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailedPostItem.ascx.cs" Inherits="NewsVn.Web.Modules.DetailedPostItem" %>

<script type="text/javascript">
    $(function () {
        $(".detailed-post .content img").each(function () {
            $(this).wrap("<a class=\"post-photo\" rel=\"post-gallery\" href=\"" + $(this).attr("src") + "\" />");
        });
        $("a.post-photo").fancybox({
            centerOnScroll: true,
            titlePosition: 'inside',
            cyclic: true
        });
        $(".detailed-post .content img").lazyload({ threshold: 150, effect: "fadeIn" });
        $(".comment-button, .comment-link").click(function () {
            $("#comment_box").dialog("open");
        });
    });
</script>
<div class="portlet detailed-post">
    <h1><asp:Label runat="server" ID="lblTitle"></asp:Label></h1>
    <div class="info-bar head">
        <div class="left">
            <span class="post-info">
                <asp:Label runat="server" ID="lblApprovedOn"></asp:Label>
                <% if (AllowComment) { %>| <a class="comment-link" href="javascript:void(0)"><b><asp:Label runat="server" ID="lblNumberComments"></asp:Label> bình luận </b></a><% } %>
            </span>
        </div>
        <div class="right">
            <a href='http://www.facebook.com/sharer.php?u=<%=SeoUrl %>&t=<%=Server.UrlEncode( Datasource.Title) %>'title="Chia sẽ trên Facebook" target="_blank">
                <asp:Image ID="Image1" ImageUrl="/images/icons/facebook.png" runat="server" />
            </a>
             <a href='http://twitter.com/home?status=<%=Server.UrlEncode( Datasource.Title) %> <%=SeoUrl %>' title="Chia sẽ trên Twitter" target="_blank">
                <asp:Image ID="Image2" ImageUrl="/images/icons/twitter.png" runat="server" />
            </a>
        </div>
        <div class="clear"></div>
    </div>
    <p>
        <b>
        <asp:Label runat="server" ID="lblDescription"></asp:Label>
        </b>
    </p>
    <div class="content">
        <span style="line-height: 22px; font-family: verdana; font-size: 12px; color: #444444; "> 
        <asp:Literal ID="ltrContent" runat="server"></asp:Literal> </span>
    </div>
    <div class="info-bar tail">
        <div class="left">
            <span class="post-info">
                <asp:Label runat="server" ID="lblApprovedOnbtm"></asp:Label>
                <% if (AllowComment) { %>| <a class="comment-link" href="javascript:void(0)"><b><asp:Label runat="Server" id="lblNumberCommentbot" /> bình luận</b></a><% } %>
            </span>
            <% if (AllowComment) { %><a style="margin-left:10px;" class="button comment-button" href="javascript:void(0)">Bình luận</a><% } %>
        </div>
        <div class="right">
            <a href='http://www.facebook.com/sharer.php?u=<%=SeoUrl %>&t=<%=Server.UrlEncode( Datasource.Title) %>' title="Chia sẽ trên Facebook" target="_blank">
                <asp:Image ID="Image3" ImageUrl="/images/icons/facebook.png" runat="server" />
            </a>
            <a href='http://twitter.com/home?status=<%=Server.UrlEncode( Datasource.Title) %> <%=SeoUrl %>' title="Chia sẽ trên Twitter" target="_blank">
                <asp:Image ID="Image4" ImageUrl="/images/icons/twitter.png" runat="server" />
            </a>
        </div>
        <div class="clear"></div>
    </div>
</div>

