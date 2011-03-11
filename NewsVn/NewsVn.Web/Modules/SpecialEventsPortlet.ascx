<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialEventsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.SpecialEventsPortlet" %>
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

<asp:Panel ID="container" CssClass="special-events portlet" runat="server">
    <h2>Sự kiện nổi bật</h2>
    <div class="content">
        
    </div>
</asp:Panel>