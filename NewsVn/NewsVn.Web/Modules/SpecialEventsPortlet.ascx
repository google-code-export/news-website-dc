<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialEventsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.SpecialEventsPortlet" %>

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
        <asp:Repeater ID="rptSpecialEvents" runat="server">
            <ItemTemplate>
                <li>
                    <asp:HyperLink NavigateUrl='<%# HostName + Eval("SeoUrl") %>' ToolTip='<%# Eval("Title") %>' runat="server">
                        <asp:Image ImageUrl='<%#Eval("Avatar") %>' runat="server" />
                        <center><asp:HyperLink CssClass="post-title inline" NavigateUrl='<%#HostName+ Eval("SeoUrl") %>' Text='<%# Eval("Title") %>' runat="server"/></center>
                    </asp:HyperLink>    
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Panel>