<%@ Control Language="C#" ClassName="SpecialPostsPortlet" %>

<script runat="server">
    
    public string CssClass { get; set; }

    public bool ClearLayout { get; set; }

    protected override void OnLoad(EventArgs e)
    {
        if (!string.IsNullOrEmpty(CssClass))
        {
            container.CssClass += " " + CssClass;
        }

        if (ClearLayout)
        {
            var clearDiv = new HtmlGenericControl("div");
            clearDiv.Attributes.Add("class", "clear");
            this.Controls.Add(clearDiv);
        }
    }
    
</script>

<link href="<%= Page.ResolveUrl("~/styles/nivo.css") %>" rel="stylesheet" type="text/css" />
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.nivo.slider.pack.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    $(function() {
        $("#nivo-description").text($("#nivo .description:first").text());
        $("#nivo").nivoSlider({
            effect: "sliceDown",
            slices: 5,
            pauseTime: 5000,
            directionNav: false,
            afterChange: function() {
                var idx = $(this).data('nivo:vars').currentSlide;
                $("#nivo-description").text($("#nivo .description").eq(idx).text());
            }
        });
    });
</script>

<asp:Panel ID="container" CssClass="special-posts portlet" runat="server">
    <h2>Tin nổi bật</h2>
    <div id="nivo">
        <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 1" runat="server">
            <asp:Image ImageUrl="~/resources/posts/t510695.jpg" ToolTip="Tiêu đề 1" runat="server" />
            <span class="description">1. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</span>
        </asp:HyperLink>
        <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 2" runat="server">
            <asp:Image ImageUrl="~/resources/posts/t510696.jpg" ToolTip="Tiêu đề 2" runat="server" />
            <span class="description">2. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</span>
        </asp:HyperLink>
        <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 3" runat="server">
            <asp:Image ImageUrl="~/resources/posts/t510697.jpg" ToolTip="Tiêu đề 3" runat="server" />
            <span class="description">3. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</span>
        </asp:HyperLink>
        <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 4" runat="server">
            <asp:Image ImageUrl="~/resources/posts/t510698.jpg" ToolTip="Tiêu đề 4" runat="server" />
            <span class="description">4. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</span>
        </asp:HyperLink>
        <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 5" runat="server">
            <asp:Image ImageUrl="~/resources/posts/t623236.gif" ToolTip="Tiêu đề 5" runat="server" />
            <span class="description">5. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</span>
        </asp:HyperLink>
    </div>
    <div class="nivo-shadow"></div>
    <p id="nivo-description"></p>
</asp:Panel>