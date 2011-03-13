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
                    <asp:HyperLink ID="hlnk" NavigateUrl="#" ToolTip='<%#Eval("Titlle") %>' runat="server">
                        <asp:Image ID="imgAvatar" ImageUrl='<%#Eval("Avatar") %>' runat="server" />
                        <center><asp:HyperLink CssClass="post-title inline" ID="hlnksubLink" NavigateUrl='<%#Eval("SeoUrl") %>' Text='<%#Eval("Titlle") %>' runat="server"/></center>
                    </asp:HyperLink>    
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <%--<li>
            <asp:HyperLink ID="HyperLink1" NavigateUrl="#" ToolTip="Tiêu đề sự kiện 1 nè nè nè nè" runat="server">
                <asp:Image ID="Image1" ImageUrl="~/resources/posts/t510695.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 1 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink2" NavigateUrl="#" ToolTip="Tiêu đề sự kiện 2 nè nè nè nè" runat="server">
                <asp:Image ID="Image2" ImageUrl="~/resources/posts/t510696.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 2 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink3" NavigateUrl="#" ToolTip="Tiêu đề sự kiện 3 nè nè nè nè" runat="server">
                <asp:Image ID="Image3" ImageUrl="~/resources/posts/t510697.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 3 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink4" NavigateUrl="#" ToolTip="Tiêu đề sự kiện 4 nè nè nè nè" runat="server">
                <asp:Image ID="Image4" ImageUrl="~/resources/posts/t510698.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 4 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink5" NavigateUrl="#" ToolTip="Tiêu đề sự kiện 5 nè nè nè nè" runat="server">
                <asp:Image ID="Image5" ImageUrl="~/resources/posts/t623236.gif" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 5 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink6" NavigateUrl="#" ToolTip="Tiêu đề sự kiện 6 nè nè nè nè" runat="server">
                <asp:Image ID="Image6" ImageUrl="~/resources/posts/t623236.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 6 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink7" NavigateUrl="#" ToolTip="Tiêu đề sự kiện 7 nè nè nè nè" runat="server">
                <asp:Image ID="Image7" ImageUrl="~/resources/posts/t510697.jpg" runat="server" />
                <center><a class="post-title inline" href="#">Tiêu đề sự kiện 7 nè nè nè nè</a></center>
            </asp:HyperLink>
        </li>--%>
    </ul>
</asp:Panel>