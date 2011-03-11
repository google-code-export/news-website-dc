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

<asp:Panel ID="container" CssClass="special-posts portlet" runat="server">
    <h2>Tin nổi bật</h2>
    <div class="content">
        <div id="nivo">
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 1" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t510695.jpg" runat="server" />
            </asp:HyperLink>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 2" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t510696.jpg" runat="server" />
            </asp:HyperLink>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 3" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t510697.jpg" runat="server" />
            </asp:HyperLink>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 4" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t510698.jpg" runat="server" />
            </asp:HyperLink>
            <asp:HyperLink NavigateUrl="#" ToolTip="Tiêu đề 5" runat="server">
                <asp:Image ImageUrl="~/resources/posts/t623236.gif" runat="server" />
            </asp:HyperLink>
        </div>
        <div class="nivo-shadow"></div>
    </div>
</asp:Panel>