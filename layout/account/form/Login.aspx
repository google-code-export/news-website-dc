<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" %>

<script runat="server">

</script>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server">
    <br/><br/><br/>
    <div class="portlet" style="width:358px;margin:0 auto;">
        <h2>Thông tin đăng nhập</h2>
        <ul class="ui-form ui-widget">
            <li>
                <asp:Label AssociatedControlID="txtUsername" Text="Tài khoản:" Width="70" runat="server" />
                <asp:TextBox ID="txtUsername" runat="server" />
            </li>
            <li>
                <asp:Label AssociatedControlID="txtPassword" Text="Mật khẩu:" Width="70" runat="server" />
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
            </li>
            <li>
                <label style="width:67px"></label>
                <asp:CheckBox Text="Nhớ thông tin" runat="server" /> |
                <asp:HyperLink NavigateUrl="~/account/form/lostpassword.aspx" Text="Quên mật khẩu?" runat="server" />
            </li>
            <li class="commands">
                <asp:LinkButton CssClass="button-login right" Text="Đăng nhập" runat="server" />
                <div class="clear"></div>
            </li>
        </ul>
    </div>
</asp:Content>

