<%@ Control Language="C#" ClassName="SpecialEventsPortlet" %>

<script runat="server">
    
    public string CssClass { get; set; }

    public bool ClearLayout { get; set; }

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
    
</script>

<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.bxcarousel.min.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#event-list").bxCarousel({
            display_num: 4,
            move: 1,
            auto_interval: 5000,
            auto: true,
            controls: false,
            margin: 10,
            auto_hover: true
        });
    });
</script>

<asp:Panel ID="container" CssClass="special-events portlet" runat="server">
    <h2>Sự kiện nổi bật</h2>
    <ul id="event-list">
        <li>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề sự kiện 1 nè nè nè nè" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t510695.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 1 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề sự kiện 2 nè nè nè nè" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t510696.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 2 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề sự kiện 3 nè nè nè nè" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t510697.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 3 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề sự kiện 4 nè nè nè nè" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t510698.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 4 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề sự kiện 5 nè nè nè nè" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t623236.gif" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 5 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề sự kiện 6 nè nè nè nè" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t623236.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 6 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề sự kiện 7 nè nè nè nè" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t510697.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 7 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
    </ul>
</asp:Panel>