<%@ Control Language="C#" ClassName="CommentBox" %>

<script type="text/javascript">
    $(function () {
        $("#comment_box").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            width: 900
        });
        $("#comment_box .comment-list li:first-child").addClass("head");
        var selectorID = "#<%= ddlOrder.ClientID %>";
        var linkSelector = $(selectorID);
        linkSelector.selectmenu({ width: "84px" });
        linkSelector.next(".ui-selectmenu").addClass("select");
        linkSelector.next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $(selectorID + "-menu").width(90);
    });
</script>

<div id="comment_box" title="Bình luận: Hot girl “siêu hot” đến từ Hàn Quốc bên xế khủng (47)">        
    <ul class="ui-form ui-widget left">
        <li>
            <b>Bình luận của bạn:</b>
        </li>
        <li>
            <asp:Label AssociatedControlID="txtName" Text="Họ tên:" runat="server" />
            <asp:TextBox ID="txtName" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtEmail" Text="Email" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" runat="server" />
            <asp:TextBox ID="txtTitle" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtComment" Text="Nội dung:" CssClass="forarea" runat="server" />
            <asp:TextBox ID="txtComment" TextMode="MultiLine" Rows="8" runat="server" />
        </li>
        <li class="command">
            <asp:Button Text="Gởi bình luận" CssClass="button right" runat="server" />
            <div class="clear"></div>
        </li>
    </ul>
    <div class="comment-list right">
        <div class="list-command">
            <div class="data-pager left">
                <span>Trang:</span>
                <a href="#">1</a>
                <a href="#">2</a>
                <a href="#">3</a>
                <span>4</span>
                <a href="#">5</a>
            </div>
            <div class="right">
                Sắp xếp theo:
                <asp:DropDownList ID="ddlOrder" runat="server">
                    <asp:ListItem Value="desc" Text="Mới nhất" />
                    <asp:ListItem Value="asc" Text="Cũ nhất" />
                </asp:DropDownList>
            </div>
            <div class="clear"></div>
        </div>
        <ul>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
            <li>
                <b>Tiêu đề bình luận</b>
                <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
                <i>(Tên người bình luận)</i>
            </li>
        </ul>
    </div>
    <div class="clear"></div>
</div>