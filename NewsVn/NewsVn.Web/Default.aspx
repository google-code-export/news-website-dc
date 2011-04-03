<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NewsVn.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" runat="server">    
    <script type="text/javascript">
        $(function () { 
            $(".portlet.left").each(function () {
                var rightPortlet = $(this).next(".portlet.right");
                if ($(this).height() < rightPortlet.height()) {
                    $(this).height(rightPortlet.height()-7);
                }
                else {
                    rightPortlet.height($(this).height()-7);
                }
            });
        });
        </script>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <nsn:SpecialPostsPortlet CssClass="left" runat="server" ID="pletHotNews" />
    <nsn:LatestPostsPortlet CssClass="right" ClearLayout="true" runat="server" ID="pletLatestNews"/>
    <nsn:SpecialEventsPortlet runat="server"  ID="pletSpecialEvents"/>
    <div id="postArea" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContentBottom" runat="server">
    <nsn:SideTabsBox runat="server" ID="pletSideTabBar"  />
</asp:Content>
