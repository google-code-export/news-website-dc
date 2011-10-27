<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdmin_UpdateBannerDetail.ascx.cs"
    Inherits="NewsVn.Web.Modules.SiteAdmin_UpdateBannerDetail" %>
<div class="portlet">
    <h2>
        Chỉnh sửa thông tin banner</h2>
    <ul id="update_post_form" class="ui-form ui-widget">
        <li>
            <asp:Label ID="Label1" Text="Vị trí:" runat="server" Width="120" />
            <asp:TextBox ID="txtPosition" Width="450" runat="server" MaxLength="280" Enabled="false" />
        </li>
        <li>
            <asp:Label ID="Label2" Text="Chiều rộng:" runat="server" Width="120" />
            <asp:TextBox ID="txtWidth" Width="450" runat="server" MaxLength="280" Enabled="false" />
        </li>
        <li>
            <asp:Label ID="Label3" Text="Chiều cao:" runat="server" Width="120" />
            <asp:TextBox ID="txtHeight" Width="450" runat="server" MaxLength="280" Enabled="false" />
        </li>
        <li>
            <asp:Label ID="Label5" Text="Url:" runat="server" Width="120" />
            <asp:TextBox ID="txtUrl" Width="450" runat="server" MaxLength="280" Enabled="false" />
        </li>
        <li>
            <asp:Label ID="Label6" Text="Tiêu đề:" runat="server" Width="120" />
            <asp:TextBox ID="txtTitle" Width="450" runat="server" MaxLength="280" />
        </li>
        <li>
            <asp:Label ID="Label4" Text="Hình ảnh:" runat="server" Width="120" />
            <asp:Image ID="imgBanner" runat="server" />
        </li>
        <li>
            <asp:LinkButton ID="lbtnUpload" Text="Upload banner khác" CssClass="button-ok" runat="server" />
        </li>
        <li class="commands">
            <div class="right">
                <asp:LinkButton ID="btnUpdate" Text="Lưu" CssClass="button-ok" runat="server" />
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
</div>
