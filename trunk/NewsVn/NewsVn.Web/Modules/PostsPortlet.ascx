<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.PostsPortlet" %>
<script runat="server">
    
    public string Title { get; set; }

    public int Figure { get; set; }
    
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

<asp:Panel ID="container" CssClass="cate-posts portlet" runat="server">
    <h2><%= Title %> <span>(<%= string.Format("{0:N0}", Figure) %> mục tin)</span></h2>
    <div class="content">
        
    </div>
</asp:Panel>