<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsVn.Web.Default" %>

<asp:Content ContentPlaceHolderID="extraHead" runat="server">
    <script type="text/javascript">
        $(function () {
            $(".portlet.left").each(function () {
                var rightPortlet = $(this).next(".portlet.right").eq(0);
                if (rightPortlet.size() == 0) {
                    rightPortlet = $(this).siblings(".portlet.right").eq(0);
                    if ($(this).height() < rightPortlet.height()) {
                        $(this).css({ height: rightPortlet.height() });
                    }
                    else {
                        rightPortlet.css({ height: $(this).height() });
                    }
                } else {
                    if ($(this).height() < rightPortlet.height()) {
                        $(this).css({ height: rightPortlet.height() - 7 });
                    }
                    else {
                        rightPortlet.css({ height: $(this).height() - 7 });
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SpecialPostsPortlet CssClass="left" runat="server" ID="pletHotNews" />
    <nsn:LatestPostsPortlet CssClass="right" ClearLayout="true" runat="server" ID="pletLatestNews"/>
    <nsn:SpecialEventsPortlet runat="server"  ID="pletSpecialEvents"/>
    <div id="postArea" runat="server"></div>
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
    <nsn:QuickSearchBox ID="QuickSearchBox1" runat="server" />
    <div id="adboxArea" runat="server"></div>
    <%--<nsn:AdBoxList ID="AdBoxList1" runat="server" />--%>
    <nsn:SideTabsBox runat="server" ID="pletSideTabBar"  />
    <nsn:HotVideoList ID="HotVideoList1" runat="server" />
</asp:Content>
