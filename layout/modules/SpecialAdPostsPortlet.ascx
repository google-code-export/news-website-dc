<%@ Control Language="C#" ClassName="SpecialAdPostsPortlet" %>

<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.bxcarousel.min.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#adpost-list").bxCarousel({
            display_num: 1,
            move: 1,
            auto: true,
            auto_interval: 5000,
            controls: true,
            margin: 0,
            auto_hover: true,
            next_text: "Kế tiếp &raquo;",
            prev_text: "&laquo; Trở lại"
        });

        $(".special-adpost .bx_wrap .prev, .special-adpost .bx_wrap .next")
            .appendTo(".special-adpost h2").wrapAll("<div class=\"right\" />");
        $(".special-adpost h2").append("<div class=\"clear\" />");
        $(".special-adpost h2 .prev").after("<span> | </span>");

        if ($(".special-adpost").height() < $(".adpost-search").height()) {
            $(".special-adpost").height($(".adpost-search").height() - 41);
        }
    });
</script>

<div class="portlet special-adpost">
    <h2>Rao vặt nổi bật</h2>
    <ul id="adpost-list" class="post-item-list">
        <li>
            <asp:Image ImageUrl="~/resources/posts/t510695.jpg" AlternateText="Tiêu đề 1" ToolTip="Tiêu đề 1" CssClass="post-avatar left" Width="130px" runat="server" />
            <div class="post-item left">
                <a href="#" class="post-title">Nhà đất: Tiêu đề 1</a>
                <p>1. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <span class="post-info">
                    <%= string.Format("{0:dddd, dd/MM/yyyy, HH:mm:ss}", DateTime.Now) %> |
                    Khu vực: <b>Hồ Chí Minh</b> |
                    Đăng bởi: <b>Waston Nguyen</b>
                </span>
            </div>
            <div class="clear"></div>
        </li>
        <li>
            <asp:Image ImageUrl="~/resources/posts/t510695.jpg" AlternateText="Tiêu đề 1" ToolTip="Tiêu đề 1" CssClass="post-avatar left" Width="130px" runat="server" />
            <div class="post-item left">
                <a href="#" class="post-title">Máy tính: Tiêu đề 1</a>
                <p>1. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <span class="post-info">
                    <%= string.Format("{0:dddd, dd/MM/yyyy, HH:mm:ss}", DateTime.Now) %> |
                    Khu vực: <b>Hồ Chí Minh</b> |
                    Đăng bởi: <b>Waston Nguyen</b>
                </span>
            </div>
            <div class="clear"></div>
        </li>
        <li>
            <asp:Image ImageUrl="~/resources/posts/t510695.jpg" AlternateText="Tiêu đề 1" ToolTip="Tiêu đề 1" CssClass="post-avatar left" Width="130px" runat="server" />
            <div class="post-item left">
                <a href="#" class="post-title">Làm đẹp: Tiêu đề 1</a>
                <p>1. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <span class="post-info">
                    <%= string.Format("{0:dddd, dd/MM/yyyy, HH:mm:ss}", DateTime.Now) %> |
                    Khu vực: <b>Hồ Chí Minh</b> |
                    Đăng bởi: <b>Waston Nguyen</b>
                </span>
            </div>
            <div class="clear"></div>
        </li>
        <li>
            <asp:Image ImageUrl="~/resources/posts/t510695.jpg" AlternateText="Tiêu đề 1" ToolTip="Tiêu đề 1" CssClass="post-avatar left" Width="130px" runat="server" />
            <div class="post-item left">
                <a href="#" class="post-title">Thiết bị văn phòng: Tiêu đề 1</a>
                <p>1. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <span class="post-info">
                    <%= string.Format("{0:dddd, dd/MM/yyyy, HH:mm:ss}", DateTime.Now) %> |
                    Khu vực: <b>Hồ Chí Minh</b> |
                    Đăng bởi: <b>Waston Nguyen</b>
                </span>
            </div>
            <div class="clear"></div>
        </li>
        <li>
            <asp:Image ImageUrl="~/resources/posts/t510695.jpg" AlternateText="Tiêu đề 1" ToolTip="Tiêu đề 1" CssClass="post-avatar left" Width="130px" runat="server" />
            <div class="post-item left">
                <a href="#" class="post-title">Tuyển dụng: Tiêu đề 1</a>
                <p>1. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <span class="post-info">
                    <%= string.Format("{0:dddd, dd/MM/yyyy, HH:mm:ss}", DateTime.Now) %> |
                    Khu vực: <b>Hồ Chí Minh</b> |
                    Đăng bởi: <b>Waston Nguyen</b>
                </span>
            </div>
            <div class="clear"></div>
        </li>
    </ul>
</div>