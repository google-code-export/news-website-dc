<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LatestPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.LatestPostsPortlet" %>
<script type="text/javascript">
    $(function () {
        $(".head-latest-post").each(function (index) {
            $(this).removeClass();
            if (index == 0) {
                $(this).addClass("head-latest-post");
            }
        });
    })
</script>
<asp:Panel ID="container" CssClass="latest-posts portlet" runat="server">
    <h2>
        Tin mới nhất
        <a class="rss" href="#"></a>
   </h2>
    <ul class="post-item-list">
    <asp:Repeater runat="server" ID="rptLatestNews">
        <ItemTemplate>
            <li class="head-latest-post">
            <asp:Label runat="server" ID="lblNo_Comment" CssClass="post-comment">105</asp:Label>
                <asp:HyperLink runat="server" ID="hlnkTitle" NavigateUrl="#"
                Text='<%#Eval("Titlle") %>' CssClass="post-title wrap"/>
                <span class="post-info">
                <asp:Label runat="server" ID="lblTitle" CssClass="cate" Text='<%#Eval("Category.Name") %>' />
                    <asp:Label ID="lblApproveOn" runat="server" Text='<%#Eval("ApprovedOn")%>' />
                </span>
            </li>
        </ItemTemplate>
    </asp:Repeater>
       <%-- <li class="head">
            <span class="post-comment">105</span>
            <a class="post-title wrap" href="#">
                Mẹo tiết kiệm nhiên liệu cho thời "bão giá"
            </a>
            <span class="post-info">
                <span class="cate">Kinh tế, Việt Nam</span>
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
            </span>
        </li>
        <li>
            <span class="post-comment">12</span>
            <a class="post-title wrap" href="#">
                Truy tìm dấu vết UFO
            </a>
            <span class="post-info">
                <span class="cate">Khoa học</span>
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
            </span>
        </li>
        <li>
            <span class="post-comment">105</span>
            <a class="post-title wrap" href="#">
                Mẹo tiết kiệm nhiên liệu cho thời "bão giá"
            </a>
            <span class="post-info">
                <span class="cate">Kinh tế, Việt Nam</span>
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
            </span>
        </li>
        <li>
            <span class="post-comment">12</span>
            <a class="post-title wrap" href="#">
                Truy tìm dấu vết UFO
            </a>
            <span class="post-info">
                <span class="cate">Khoa học</span>
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
            </span>
        </li>
        <li>
            <span class="post-comment">105</span>
            <a class="post-title wrap" href="#">
                Mẹo tiết kiệm nhiên liệu cho thời "bão giá"
            </a>
            <span class="post-info">
                <span class="cate">Kinh tế, Việt Nam</span>
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
            </span>
        </li>
        <li>
            <span class="post-comment">12</span>
            <a class="post-title wrap" href="#">
                Truy tìm dấu vết UFO
            </a>
            <span class="post-info">
                <span class="cate">Khoa học</span>
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
            </span>
        </li>
        <li>
            <span class="post-comment">12</span>
            <a class="post-title wrap" href="#">
                Truy tìm dấu vết UFO
            </a>
            <span class="post-info">
                <span class="cate">Khoa học</span>
                <%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now)%>
            </span>
        </li>--%>
    </ul>
</asp:Panel>