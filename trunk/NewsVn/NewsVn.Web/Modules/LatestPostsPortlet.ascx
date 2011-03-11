<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LatestPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.LatestPostsPortlet" %>
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
    <ul class="post-item-list">
        <li>
            <span class="post-comment">105</span>
            <a class="post-title latest" href="#">
                Mẹo tiết kiệm nhiên liệu cho thời "bão giá"
            </a>
            <span class="post-info">
                <span class="cate">Kinh tế, Việt Nam</span>
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
            </span>
        </li>
    </ul>
</asp:Panel>