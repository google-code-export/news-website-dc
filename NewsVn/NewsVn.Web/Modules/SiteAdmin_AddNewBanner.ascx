<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdmin_AddNewBanner.ascx.cs" Inherits="NewsVn.Web.Modules.SiteAdmin_AddNewBanner" %>
<div class="portlet">
    <h2>
        Thêm banner mới</h2>
    <ul id="update_post_form" class="ui-form ui-widget">
        <li>
            <asp:Label ID="Label1" Text="Vị trí:" runat="server" Width="120" />
            <asp:TextBox ID="txtPosition" Width="450" runat="server" MaxLength="280" Enabled=false />
        </li>
        <li>
            <asp:Label ID="Label2" Text="Chiều rộng:" runat="server" Width="120" />
            <asp:TextBox ID="txtWidth" CssClass="validate[required]" Width="450" runat="server" MaxLength="280" />
        </li>
        <li>
            <asp:Label ID="Label3" Text="Chiều cao:" runat="server" Width="120" />
            <asp:TextBox ID="txtHeight" CssClass="validate[required]" Width="450" runat="server" MaxLength="280"/>
        </li>
        <li>
            <asp:Label ID="Label5" Text="Url:" runat="server" Width="120" />
            <asp:TextBox ID="txtUrl" CssClass="validate[required]" Width="450" runat="server" MaxLength="280"/>
        </li>
        <li>
            <asp:Label ID="Label6" Text="Tiêu đề:" runat="server" Width="120" />
            <asp:TextBox ID="txtTitle" CssClass="validate[required]" Width="450" runat="server" MaxLength="280" />
        </li>
        <li>
            <%--<asp:Label ID="Label4" Text="Hình ảnh:" runat="server" Width="120" />
            <asp:Image ID="imgBanner" runat="server" />--%>
            <asp:Label ID="Label4" Text="Upload Banner:" runat="server" Width="120" />
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </li>
        
        <li class="commands">
            <div class="right">
                <asp:LinkButton ID="btnInsert" Text="Thêm" CssClass="button-ok" runat="server" 
                    onclick="btnInsert_Click" />
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
</div>