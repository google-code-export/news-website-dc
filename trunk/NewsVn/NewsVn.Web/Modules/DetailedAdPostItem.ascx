<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailedAdPostItem.ascx.cs" Inherits="NewsVn.Web.Modules.DetailedAdPostItem" %>
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
        $(".detailed-post .content img").lazyload({
            threshold: 150,
            effect: "fadeIn",
            placeholder: "http://lh5.ggpht.com/_XrWO8mEpDy0/TEdXIqjrAUI/AAAAAAAAAkU/3lwqSFT8IRQ/grey.gif"
        });
        $(".comment-button, .comment-link").click(function () {
            $("#comment_box").dialog("open");
        });
    });
</script>
<style type="text/css">
.imagedropshadow {
	padding: 5px;
	border: solid 2px #CCC;
}
.hoverStyle:hover img.imagedropshadow {
	border: solid 2px #ffb4ae;
	-moz-box-shadow: 1px 1px 5px #999;
	-webkit-box-shadow: 1px 1px 5px #999;
        box-shadow: 1px 1px 5px #999;
}
</style>
<div class="portlet detailed-post">
    <h1><%=AdsTitle %></h1>
    <div class="info-bar head">
        <div class="left">
            <span class="post-info">
                <%= string.Format("{0:dddd, dd/MM/yyyy}", CreatedOn)%> |
                 Khu vực: <b><%=NewsVn.Web.Utils.clsCommon.getLocationName(Location)%></b> 
                | Liên hệ:<b> <%=CreateBy%></b>
            </span>
        </div>
        <div class="right">
            <a href="#" title="Chia sẽ trên Facebook">
                <asp:Image ID="Image1" ImageUrl="~/images/icons/facebook.png" runat="server" />
            </a>
            <a href="#" title="Chia sẽ trên Twitter">
                <asp:Image ID="Image2" ImageUrl="~/images/icons/twitter.png" runat="server" />
            </a>
        </div>
        <div class="clear"></div>
    </div>
    <div class="content">
   <table width="100%">
    <tr>
    <td style="vertical-align:top">
    <p >
            <%=AdsContent %>
        </p>
    </td>
    
    <td style="vertical-align:top">
    <a href="javascript:void(0)" class="hoverStyle"><img class="imagedropshadow" src='<%=Avatar %>' alt='<%=AdsTitle %>' width="120px" height="120px" style="overflow:hidden; margin: 10px 10px 10px 5px;" /></a> 
    <div><i>(Click vào hình để xem ảnh lớn hơn)</i></div>
    </td>
    </tr>
   </table>
    </div>
    <div class="info-bar tail">
        <div class="left">
            <span class="post-info">
                <%= string.Format("{0:dddd, dd/MM/yyyy}", CreatedOn)%> |
                 Khu vực: <b><%=NewsVn.Web.Utils.clsCommon.getLocationName(Location)%></b> 
                | Liên hệ:<b> <%=CreateBy%></b>
            </span>
        </div>
        <div class="right">
            <a href="#" title="Chia sẽ trên Facebook">
                <asp:Image ID="Image3" ImageUrl="~/images/icons/facebook.png" runat="server" />
            </a>
            <a href="#" title="Chia sẽ trên Twitter">
                <asp:Image ID="Image4" ImageUrl="~/images/icons/twitter.png" runat="server" />
            </a>
        </div>
        <div class="clear"></div>
    </div>
</div>