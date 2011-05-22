<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialAdPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.SpecialAdPostsPortlet" %>
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.bxcarousel.min.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#adpost-list").bxCarousel({
            display_num: 1,
            move: 1,
            auto: true,
            auto_interval: 5000,
            controls: true,
            margin: 0,
            auto_hover: true,
            next_text: "Kế tiếp &raquo;",
            prev_text: "&laquo; Trở lại"
        });

        $(".special-adpost .bx_wrap .prev, .special-adpost .bx_wrap .next")
            .appendTo(".special-adpost h2").wrapAll("<div class=\"right\" />");
        $(".special-adpost h2").append("<div class=\"clear\" />");
        $(".special-adpost h2 .prev").after("<span> | </span>");

        if ($(".special-adpost").height() < $(".adpost-search").height()) {
            $(".special-adpost").css({ height: $(".adpost-search").height() - 49 });
        }
    });
</script>
<div class="portlet special-adpost">
    <h2>Rao vặt nổi bật</h2>
    <ul id="adpost-list" class="post-item-list">
    <asp:Repeater runat="server" ID="rptSpecialAds">
        <ItemTemplate>
            <li>
                <img src='<%# Page.ResolveUrl((string)DataBinder.Eval(Container.DataItem, "Avatar")) %>' alt='<%#Eval("Title") %>' title='<%#Eval("Title") %>' class="post-avatar left" width="130px" />
                <div class="post-item left">
                    <a href='<%#Eval("SeoUrl") %>' class="post-title"><%#Eval("Name") %>: <%#Eval("Title") %></a>
                    <p>
                        <%#NewsVn.Web.Utils.clsCommon.hintDesc(Eval("Content").ToString(),300)%>
                    </p>
                    <span class="post-info">
                        <%# Eval("CreatedOn", "{0:dddd, dd/MM/yyyy, HH:mm})" ) %> |
                        Khu vực: <b><%#NewsVn.Web.Utils.clsCommon.getLocationName(int.Parse(Eval("Location").ToString()))%></b> |
                        Đăng bởi: <b><%#Eval("CreatedBy") %></b>
                    </span>
                </div>
                <div class="clear"></div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    </ul>
</div>