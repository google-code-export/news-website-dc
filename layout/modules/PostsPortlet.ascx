<%@ Control Language="C#" ClassName="PostsPortlet" %>

<script runat="server">
    
    public string Title { get; set; }
    
    public string CssClass { get; set; }

    public bool ClearLayout { get; set; }

    public bool NoComments { get; set; }

    public object DataSource { get; set; }

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

    protected override void OnDataBinding(EventArgs e)
    {
        
    }
    
</script>

<asp:Panel ID="container" CssClass="cate-posts portlet" runat="server">
    
    <script type="text/javascript">
        $(function () {
            var boundary = "#<%= container.ClientID %>";
            $(boundary + " .avatar-thumb-list img").click(function () {
                var matchItem = $(boundary + " .post-item-list.other li." + $(this).attr("class"));
                var activeItem = $(boundary + " .active-post-item");
                var cloneItem = activeItem.clone();

                var activeAvatar = $(boundary + " .post-avatar");
                var cloneAvatar = activeAvatar.clone();

                activeItem.find(".post-comment").text(matchItem.find(".post-comment").text());
                activeItem.find(".post-title").text(matchItem.find(".post-title").text());
                activeItem.find(".post-info").text(matchItem.find(".post-info").text());
                activeItem.find("p").text(matchItem.find(".description").text());
                activeAvatar.attr("src", $(this).attr("src"));
                activeAvatar.attr("alt", $(this).attr("alt"));
                activeAvatar.attr("title", $(this).attr("title"));
                activeAvatar.css({ "display": "none" });
                activeAvatar.fadeIn(500);

                matchItem.find(".post-comment").text(cloneItem.find(".post-comment").text());
                matchItem.find(".post-title").text(cloneItem.find(".post-title").text());
                matchItem.find(".post-info").text(cloneItem.find(".post-info").text());
                matchItem.find(".description").text(cloneItem.find("p").text());
                $(this).attr("src", cloneAvatar.attr("src"));
                $(this).attr("alt", cloneAvatar.attr("alt"));
                $(this).attr("title", cloneAvatar.attr("title"));
            });
            $(boundary + " .post-item-list li:first-child").addClass("head");
        });
    </script>

    <h2>        
        <a class="cate-title" href="category.aspx"><%= Title %></a>
        <a class="rss" href="#"></a>
    </h2>
    <asp:Image ImageUrl="~/resources/posts/t510695.jpg" AlternateText="Tiêu đề 1" ToolTip="Tiêu đề 1" CssClass="post-avatar left" runat="server" />
    <ul class="avatar-thumb-list right">
        <li><asp:Image ImageUrl="~/resources/posts/t510696.jpg" AlternateText="Tiêu đề 2" ToolTip="Tiêu đề 2" CssClass="item-2" runat="server" /></li>
        <li><asp:Image ImageUrl="~/resources/posts/t510697.jpg" AlternateText="Tiêu đề 3" ToolTip="Tiêu đề 3" CssClass="item-3" runat="server" /></li>
        <li><asp:Image ImageUrl="~/resources/posts/t510698.jpg" AlternateText="Tiêu đề 4" ToolTip="Tiêu đề 4" CssClass="item-4" runat="server" /></li>
        <li><asp:Image ImageUrl="~/resources/posts/t623236.gif" AlternateText="Tiêu đề 5" ToolTip="Tiêu đề 5" CssClass="item-5" runat="server" /></li>        
    </ul>
    <div class="clear"></div>
    <div class="active-post-item">
        <% if (!NoComments){ %><span class="post-comment">26</span><% } %>
        <a href="#" class="post-title wrap">Tiêu đề 1</a>        
        <span class="post-info"><%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %></span>
        <p>1. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
    </div>
    <ul class="post-item-list other">
        <li class="item-2">
            <% if (!NoComments){ %><span class="post-comment">11</span><% } %>
            <% if (!NoComments){ %><div class="wrap"><% } %>
                <a class="post-title inline" href="#">Tiêu đề 2</a> -
                <span class="post-info">
                    <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
                </span>
            <% if (!NoComments){ %></div><% } %>
            <span class="description">2. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</span>
        </li>
        <li class="item-3">
            <% if (!NoComments){ %><span class="post-comment">16</span><% } %>            
            <% if (!NoComments){ %><div class="wrap"><% } %>
                <a class="post-title inline" href="#">Tiêu đề 3</a> -
                <span class="post-info">
                    <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
                </span>
            <% if (!NoComments){ %></div><% } %>
            <span class="description">3. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</span>
        </li>
        <li class="item-4">
            <% if (!NoComments){ %><span class="post-comment">68</span><% } %>            
            <% if (!NoComments){ %><div class="wrap"><% } %>
                <a class="post-title inline" href="#">Tiêu đề 4</a> -
                <span class="post-info">
                    <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
                </span>
            <% if (!NoComments){ %></div><% } %>
            <span class="description">4. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</span>
        </li>
        <li class="item-5">
            <% if (!NoComments){ %><span class="post-comment">87</span><% } %>            
            <% if (!NoComments){ %><div class="wrap"><% } %>
                <a class="post-title inline" href="#">Tiêu đề 5</a> -
                <span class="post-info">
                    <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
                </span>
            <% if (!NoComments){ %></div><% } %>
            <span class="description">5. Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</span>
        </li>
    </ul>
</asp:Panel>