<%@ Page Title="" Language="C#" MasterPageFile="~/UserExtra.master" AutoEventWireup="true" CodeBehind="AdCategory.aspx.cs" Inherits="NewsVn.Web.AdCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="extraHead" Runat="Server">
    <script type="text/javascript">
        $(function () {
            $(".portlet.left").each(function () {
                var rightPortlet = $(this).next(".portlet.right");
                if ($(this).height() < rightPortlet.height()) {
                    $(this).height(rightPortlet.height());
                }
                else if ($(this).height() > rightPortlet.height()) {
                    rightPortlet.height($(this).height());
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" Runat="Server">
    <nsn:SpecialAdPostsPortlet ID="SpecialAdPostsPortlet1" runat="server" />
    <nsn:AdGuideBox ID="AdGuideBox1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideContent" Runat="Server">
    <nsn:AdSearchBox ID="AdSearchBox1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="extraContent" runat="server">
    <nsn:AdPostsPortlet ID="AdPostsPortlet1" Title="Nhà đất" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet ID="AdPostsPortlet2" Title="Ô tô - Xe máy" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:AdPostsPortlet ID="AdPostsPortlet3" Title="Làm đẹp" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet ID="AdPostsPortlet4" Title="Máy tính" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:AdPostsPortlet ID="AdPostsPortlet5" Title="Điện tử - Điện lạnh" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet ID="AdPostsPortlet6" Title="Điện thoại" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:AdPostsPortlet ID="AdPostsPortlet7" Title="Dịch vụ tại nhà" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet ID="AdPostsPortlet8" Title="Tuyển dụng" CssClass="right" ClearLayout="true" runat="server" />
    <nsn:AdPostsPortlet ID="AdPostsPortlet9" Title="Thiết bị văn phòng" CssClass="left" runat="server" />
    <nsn:AdPostsPortlet ID="AdPostsPortlet10" Title="Nhắn tin" CssClass="right" ClearLayout="true" runat="server" />
</asp:Content>
