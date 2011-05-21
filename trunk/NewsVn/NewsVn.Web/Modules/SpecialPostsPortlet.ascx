<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.SpecialPostsPortlet" %>

<link href="<%= Page.ResolveUrl("~/styles/nivo.css") %>" rel="stylesheet" type="text/css" />
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.nivo.slider.js") %>" type="text/javascript"></script>
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
    <h2><%=CateTitle %></h2>
    <div id="nivo">
        <asp:Repeater ID="rptHotNews" runat="server">
            <ItemTemplate>
                <asp:HyperLink ID="hlnkTitle" NavigateUrl='<%# Eval("SeoUrl") %>' ToolTip='<%# Eval("Title") %>'  runat="server">
                <img src='<%# Eval("Avatar") %>' style="width:340px !important; height:250px !important;" title='<%# Eval("Title") %>'/>
                <%--<asp:Image ID="imgPresentation" ImageUrl='<%# Eval("Avatar") %>' runat="server" ToolTip='<%# Eval("Title") %>' Width="340px" Height="250px" />--%>
                <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server" CssClass="description" ></asp:Label>    
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="nivo-shadow"></div>
    <p id="nivo-description"></p>
</asp:Panel>