<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.SpecialPostsPortlet" %>

<link href="<%= Page.ResolveUrl("~/styles/nivo.css") %>" rel="stylesheet" type="text/css" />
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.nivo.slider.pack.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#nivo-description").text($("#nivo .description:first").text());
        $("#nivo").nivoSlider({
            effect: "sliceDown",
            slices: 5,
            pauseTime: 5000,
            directionNav: false,
            afterChange: function () {
                var idx = $(this).data('nivo:vars').currentSlide;
                $("#nivo-description").text($("#nivo .description").eq(idx).text());
            }
        });
    });
</script>

<asp:Panel ID="container" CssClass="special-posts portlet" runat="server">
    <h2>Tin nổi bật</h2>
    <div id="nivo">
        <asp:Repeater ID="rptHotNews" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="hlnkTitle" NavigateUrl='<%# Eval("SeoUrl") %>' ToolTip='<%# Eval("Titlle") %>'  runat="server">
                <asp:Image ID="imgPresentation" ImageUrl='<%# Eval("Avatar") %>' runat="server" ToolTip='<%# Eval("Titlle") %>' />
                <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server" CssClass="description" ></asp:Label>    
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="nivo-shadow"></div>
    <p id="nivo-description"></p>
</asp:Panel>