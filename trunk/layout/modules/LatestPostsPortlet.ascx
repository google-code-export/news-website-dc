<%@ Control Language="C#" ClassName="LatestPostsPortlet" %>

<script runat="server">
    
    public string CssClass { get; set; }

    public bool ClearLayout { get; set; }

    public bool NoCategoryName { get; set; }

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

<asp:Panel ID="container" CssClass="latest-posts portlet" runat="server">
    <h2>
        Tin mới nhất
        <a class="rss" href="#"></a>
   </h2>
    <ul class="post-item-list">
        <li class="head">
            <span class="post-comment">105</span>
            <a class="post-title wrap" href="#">
                Mẹo tiết kiệm nhiên liệu cho thời "bão giá"
            </a>
            <span class="post-info">
                <% if (!NoCategoryName) { %><span class="cate">Kinh tế, Việt Nam</span><% } %>
                &nbsp;<%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %>
            </span>
        </li>
        <li>
            <span class="post-comment">12</span>
            <a class="post-title wrap" href="#">
                Truy tìm dấu vết UFO
            </a>
            <span class="post-info">
                <% if (!NoCategoryName) { %><span class="cate">Khoa học</span><% } %>
                &nbsp;<%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %>
            </span>
        </li>
        <li>
            <span class="post-comment">105</span>
            <a class="post-title wrap" href="#">
                Mẹo tiết kiệm nhiên liệu cho thời "bão giá"
            </a>
            <span class="post-info">
                <% if (!NoCategoryName) { %><span class="cate">Kinh tế, Việt Nam</span><% } %>
                &nbsp;<%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %>
            </span>
        </li>
        <li>
            <span class="post-comment">12</span>
            <a class="post-title wrap" href="#">
                Truy tìm dấu vết UFO
            </a>
            <span class="post-info">
                <% if (!NoCategoryName) { %><span class="cate">Khoa học</span><% } %>
                &nbsp;<%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %>
            </span>
        </li>
        <li>
            <span class="post-comment">105</span>
            <a class="post-title wrap" href="#">
                Mẹo tiết kiệm nhiên liệu cho thời "bão giá"
            </a>
            <span class="post-info">
                <% if (!NoCategoryName) { %><span class="cate">Kinh tế, Việt Nam</span><% } %>
                &nbsp;<%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %>
            </span>
        </li>
        <li>
            <span class="post-comment">12</span>
            <a class="post-title wrap" href="#">
                Truy tìm dấu vết UFO
            </a>
            <span class="post-info">
                <% if (!NoCategoryName) { %><span class="cate">Khoa học</span><% } %>
                &nbsp;<%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %>
            </span>
        </li>
        <li>
            <span class="post-comment">12</span>
            <a class="post-title wrap" href="#">
                Truy tìm dấu vết UFO
            </a>
            <span class="post-info">
                <% if (!NoCategoryName) { %><span class="cate">Khoa học</span><% } %>
                &nbsp;<%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %>
            </span>
        </li>
    </ul>
</asp:Panel>