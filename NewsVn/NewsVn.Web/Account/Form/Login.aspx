<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NewsVn.Web.Account.Form.Login" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #content { min-height: 0; padding-top: 10px; }
    </style>
    <link href="<%= Page.ResolveUrl("~/styles/validation.css") %>" rel="stylesheet" type="text/css" />
    <script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine-vi.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("input[id$=UserName]:eq(0)").focus();
        });

        function checkValidation() {
            return $("#loginform_box").validationEngine('validate');
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server">
    <div class="portlet" style="margin:0">
        <h2>Thông tin đăng nhập</h2>        
        <div class="left" style="width:590px">
            <asp:Image ImageUrl="~/Images/login_banner.jpg" Width="590" runat="server" />
        </div>
        <div class="right" style="width:358px">
            <asp:LoginView ID="loginView" runat="server">
                <AnonymousTemplate>
                    <asp:Panel DefaultButton="login$LoginButton" runat="server">
                    <asp:Login ID="login" runat="server" FailureAction="Refresh" Width="100%"
                        DestinationPageUrl="~/Account/SiteAdmin/"
                        PasswordRecoveryUrl="~/Account/Form/LostPassword.aspx">
                        <LayoutTemplate>                
                            <ul id="loginform_box" class="ui-form ui-widget">
                                <li>
                                    <asp:Label ID="UserNameLabel" runat="server" Width="70" AssociatedControlID="UserName" Text="Tài khoản:" />
                                    <asp:TextBox ID="UserName" CssClass="validate[required]" runat="server" />
                                </li>
                                <li>
                                    <asp:Label ID="PasswordLabel" runat="server" Width="70" AssociatedControlID="Password" Text="Mật khẩu:" />
                                    <asp:TextBox ID="Password" CssClass="validate[required]" runat="server" TextMode="Password" />
                                </li>
                                <li>
                                    <label style="width:67px"></label>
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Nhớ thông tin" /> |
                                    <asp:HyperLink ID="PasswordRecoveryLink" runat="server" Text="Quên mật khẩu?"
                                        NavigateUrl="~/Account/Form/LostPassword.aspx" />
                                </li>                            
                                <li class="commands">
                                    <asp:Button ID="LoginButton" style="display:none;" UseSubmitBehavior="false" CommandName="Login" runat="server" />
                                    <asp:LinkButton ID="LoginLinkButton" runat="server" CommandName="Login" CssClass="button-login right" Text="Đăng nhập"
                                        OnClientClick="return checkValidation()" />
                                    <div class="clear"></div>
                                </li>
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                            </ul>
                        </LayoutTemplate>
                    </asp:Login>
                    </asp:Panel>
                    <hr />
                    <p>
                        Bạn chưa có tài khoản? Hay nhanh tay đăng ký để được tham gia tìm bạn 4 phương trên trang web của chúng tôi.
                        Với lượt truy cập lớn và hồ sơ mới cập nhật mỗi ngày. Còn chờ gì nữa, hay đăng ký ngay thôi!
                    </p>
                    <asp:HyperLink NavigateUrl="~/Account/Form/Signup.aspx" CssClass="button-register right" style="font-size:1.19em" Text="Đăng ký" runat="server" />
                    <div class="clear"></div>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <ul class="form ui-widget">
                        <li>                            
                            <div style="padding:0 .7em;" class="ui-state-highlight ui-corner-all"> 
		                        <p>
		                            <span style="float:left; margin:.15em .3em 0;" class="ui-icon ui-icon-info"></span>
		                            Bạn đã đăng nhập. Click vào
                                    <b><asp:HyperLink NavigateUrl="#" Text="đây" style="color:#082A73" runat="server" /></b>
                                    để vào trang tài khoản.
		                        </p>
	                        </div>
                        </li>
                    </ul>
                </LoggedInTemplate>
            </asp:LoginView>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>

