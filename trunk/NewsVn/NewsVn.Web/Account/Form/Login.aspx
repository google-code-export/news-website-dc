<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NewsVn.Web.Account.Form.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <br/><br/><br/>
    <div class="portlet" style="width:358px;margin:0 auto;">
        <h2>Thông tin đăng nhập</h2>
        <%--<ul class="ui-form ui-widget">
            <li>
                <asp:Label ID="Label1" AssociatedControlID="txtUsername" Text="Tài khoản:" Width="70" runat="server" />
                <asp:TextBox ID="txtUsername" runat="server" />
            </li>
            <li>
                <asp:Label ID="Label2" AssociatedControlID="txtPassword" Text="Mật khẩu:" Width="70" runat="server" />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
            </li>
            <li>
                <label style="width:67px"></label>
                <asp:CheckBox ID="CheckBox1" Text="Nhớ thông tin" runat="server" /> |
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/account/form/lostpassword.aspx" Text="Quên mật khẩu?" runat="server" />
            </li>
            <li class="commands">
                <asp:LinkButton ID="LinkButton1" CssClass="button-login right" Text="Đăng nhập" runat="server" />
                <div class="clear"></div>
            </li>
        </ul>--%>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Account/SiteAdmin/Post/ViewPost.aspx" VisibleWhenLoggedIn="False"></asp:Login>
        <%--<asp:CreateUserWizard runat=server />--%>
    </div>
</asp:Content>

