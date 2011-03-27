﻿<%@ Control Language="C#" ClassName="DetailedPostItem" %>

<script runat="server">
    
    public bool AllowComments { get; set; }
    
</script>

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
    <h1>Hot girl “siêu hot” đến từ Hàn Quốc bên xế khủng</h1>
    <div class="info-bar head">
        <div class="left">
            <span class="post-info">
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %>
                <% if (AllowComments) { %>| <a class="comment-link" href="javascript:void(0)"><b>47 bình luận</b></a><% } %>
            </span>
        </div>
        <div class="right">
            <a href="#" title="Chia sẽ trên Facebook">
                <asp:Image ImageUrl="~/images/icons/facebook.png" runat="server" />
            </a>
            <a href="#" title="Chia sẽ trên Twitter">
                <asp:Image ImageUrl="~/images/icons/twitter.png" runat="server" />
            </a>
        </div>
        <div class="clear"></div>
    </div>
    <p>
        <b>Hwang Mi Hee – Hot Girl đến từ Hàn Quốc là một phần không thể thiếu giúp các chú xế trở nên hấp dẫn và mềm mại hơn.</b>
    </p>
    <div class="content">
        <span style="line-height: 22px; font-family: verdana; font-size: 12px; color: #444444; "> <p style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 15px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; text-align: center; "><strong style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "><a href="http://volang.vn/3-choi-xe/hot-girl-sieu-hot-den-tu-han-quoc-ben-xe-khung?g=1" target="_blank"><br /> </a><span style="color: #154a7f; margin-right: auto; margin-left: auto; border-style: initial; border-color: initial; outline-style: initial; outline-color: initial; border-style: initial; border-color: initial; border-width: initial; border-color: initial; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; "><img alt="" class="aligncenter size-full wp-image-24588" title="Hwang Mi Hee" src="http://volang.vn/wp-content/uploads/2011/02/ava4.jpg" width="578" height="386" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /></span></strong><a href="http://volang.vn/3-choi-xe/hot-girl-sieu-hot-den-tu-han-quoc-ben-xe-khung?g=1" target="_blank" style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; text-decoration: none; color: #154a7f; font-weight: 700; "><em style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "><strong style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "></strong></em></a></p> <p style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 15px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; ">Không quá đình đám nhưng Hwang Mi Hee Cute là cái tên thực sự rất hot mỗi khi xuất hiện tại bất kì triển lãm nào.</p> <p style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 15px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "><span style="color: #154a7f; margin-right: auto; margin-left: auto; border-style: initial; border-color: initial; outline-style: initial; outline-color: initial; border-style: initial; border-color: initial; border-width: initial; border-color: initial; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; font-weight: 700; "><img alt="" class="aligncenter size-medium wp-image-24601" title="Girl (13)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-132-650x487.jpg" width="650" height="487" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /></span></p> <p style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 15px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; ">Với vẻ đẹp trẻ trung như của một cô gái mới lớn mặc dù sinh năm 1982 nhưng ba vòng nảy nở cùng body cực chuẩn có lẽ có đôi chút làm xao lòng những người yêu xe.</p> <p style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 15px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; text-align: right; "><span style="color: #154a7f; margin-right: auto; margin-left: auto; border-style: initial; border-color: initial; outline-style: initial; outline-color: initial; border-style: initial; border-color: initial; border-width: initial; border-color: initial; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; font-weight: 700; "><img alt="" class="aligncenter size-medium wp-image-24592" title="Girl (4)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-42-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24595" title="Girl (7)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-72-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24597" title="Girl (9)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-93-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24598" title="Girl (10)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-102-435x650.jpg" width="435" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24599" title="Girl (11)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-113-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-full wp-image-24589" title="Girl (1)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-112.jpg" width="426" height="640" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24590" title="Girl (2)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-22-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24591" title="Girl (3)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-32-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24593" title="Girl (5)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-52-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24594" title="Girl (6)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-62-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24596" title="Girl (8)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-82-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /><img alt="" class="aligncenter size-medium wp-image-24600" title="Girl (12)" src="http://volang.vn/wp-content/uploads/2011/02/Girl-122-432x650.jpg" width="432" height="650" style="margin-top: 0px; margin-right: auto; margin-bottom: 0px; margin-left: auto; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; border-style: initial; border-color: initial; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-width: initial; border-color: initial; display: block; border-top-color: #dddddd; border-right-color: #dddddd; border-bottom-color: #dddddd; border-left-color: #dddddd; " /></span><strong style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "></strong></p> <div style="text-align: right; "><strong style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "><span style="font-weight: normal; "><strong style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "><em style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "><br /> </em></strong></span></strong></div> <div style="text-align: right; "><strong style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "><span style="font-weight: normal; "><strong style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; "><em style="margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px; border-left-width: 0px; border-style: initial; border-color: initial; outline-width: 0px; outline-style: initial; outline-color: initial; font-size: 12px; vertical-align: baseline; ">Theo</em> GSC</strong></span></strong></div> <p></p> </span>
    </div>
    <div class="info-bar tail">
        <div class="left">
            <span class="post-info">
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %>
                <% if (AllowComments) { %>| <a class="comment-link" href="javascript:void(0)"><b>47 bình luận</b></a><% } %>
            </span>
            <% if (AllowComments) { %><a style="margin-left:10px;" class="button comment-button" href="javascript:void(0)">Bình luận</a><% } %>
        </div>
        <div class="right">
            <a href="#" title="Chia sẽ trên Facebook">
                <asp:Image ImageUrl="~/images/icons/facebook.png" runat="server" />
            </a>
            <a href="#" title="Chia sẽ trên Twitter">
                <asp:Image ImageUrl="~/images/icons/twitter.png" runat="server" />
            </a>
        </div>
        <div class="clear"></div>
    </div>
</div>