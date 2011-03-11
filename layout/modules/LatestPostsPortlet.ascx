<%@ Control Language="C#" ClassName="LatestPostsPortlet" %>

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

<asp:Panel ID="container" CssClass="latest-posts portlet" runat="server">
    <h2>Tin mới nhất</h2>
    <div class="content">
        
    </div>
</asp:Panel>