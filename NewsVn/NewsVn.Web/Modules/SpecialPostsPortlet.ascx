<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SpecialPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.SpecialPostsPortlet" %>

<script type="text/javascript">
    var sliderInterval;

    $(function () {
        $("#slider .slider-item").each(function (index) {
            $("#slider-trackers div").before($("<a>", {
                "href": "javascript:void(0)",
                "title": $(this).find("a:first").attr("title"),
                "click": function () {
                    runSlider(index);
                    sliderInterval = clearInterval(sliderInterval);
                    sliderInterval = setInterval("runSlider()", 5000);
                }
            }));
        });
        var noTrackers = $("#slider-trackers a").size();
        $("#slider-trackers").css({ "width": noTrackers * 16 + noTrackers * 2 + "px" });
        $("#slider").hover(function () {
            sliderInterval = clearInterval(sliderInterval);
        }, function () {
            sliderInterval = setInterval("runSlider()", 5000);
        });
        $("#slider-caption").css({ "opacity": 0.8 });
        runSlider(0);
        sliderInterval = setInterval("runSlider()", 5000);
    });

    function runSlider(index) {
        if (index == null || index == undefined) {
            index = $("#slider").data("current-index");
        }
        var items = $("#slider .slider-item");
        var current = items.eq(index);
        var trackers = $("#slider-trackers a");
        items.hide();
        $("#slider-caption p").text(current.find("a:first").attr("title"));
        $("#slider-description").text(current.find(".description").text());
        trackers.removeClass("active");
        trackers.eq(index).addClass("active");
        current.fadeIn(500, function () {
            $("#slider-shadow").show();
            $("#slider-caption").show();
            $("#slider-trackers").show();
        });
        index++;
        if (index == items.size()) {
            index = 0;
        }
        $("#slider").data("current-index", index);
    }
</script>

<asp:Panel ID="container" CssClass="special-posts portlet" runat="server">
    <h2><%=CateTitle %></h2>
    <div id="slider">
        <asp:Repeater ID="rptHotNews" runat="server">
            <ItemTemplate>
                <div class="slider-item">
                    <asp:HyperLink ID="hlnkTitle" NavigateUrl='<%# Eval("SeoUrl") %>' ToolTip='<%# Eval("Title") %>' runat="server">
                        <asp:Image ID="imgPresentation" ImageUrl='<%# Eval("Avatar") %>' runat="server" ToolTip='<%# Eval("Title") %>' Width="340px" Height="250px" />
                        <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server" CssClass="description" ></asp:Label>    
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>   
        <div id="slider-caption"><p></p></div>     
    </div>
    <div id="slider-shadow"></div>
    <div id="slider-trackers">
        <div class="clear"></div>
    </div>
    <p id="slider-description"></p>
</asp:Panel>