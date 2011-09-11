<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileCommentBox.ascx.cs" Inherits="NewsVn.Web.Modules.ProfileCommentBox" %>

<script runat="server">
    //Sample property used only for building layout
    //Replace with real UserProfile.ShowEmail
    public bool ShowEmail { get; set; }
    //Use to set sample properties
    //used only for building layout
    protected void Page_Load(object sender, EventArgs args)
    {
        this.ShowEmail = true;
    }
</script>

<link href="<%= Page.ResolveUrl("~/styles/validation.css") %>" rel="stylesheet" type="text/css" />
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine-vi.js") %>" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        var linkSelector = $("#<%= ddlCategory.ClientID %>")
        linkSelector.selectmenu({ width: "274px" });
        linkSelector.next(".ui-selectmenu").addClass("select");
        linkSelector.next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $("#<%= ddlCategory.ClientID %>" + "-menu").width(280);
    });

    function checkValidation() {
        return $("#pmessageform_box").validationEngine('validate');
    }
</script>

<div class="portlet">
    <h2>
        Gởi tin nhắn cho:
        <span><%= _accUserNickName %></span>
    </h2>
    <ul id="pmessageform_box" class="ui-form ui-widget">
        <li style="border-bottom:1px dotted #333;">
            Các trường có dấu <b>*</b> là bắt buộc |
            Vui lòng nhập <b>Tiếng Việt Unicode có dấu</b>
        </li><li></li>
        <%--Shows options only when host profile allow to view email address--%>
        <%--Message sender can choose whether to send to NewsVN account (insert record into database)--%>
        <%--or directly to host profile's email (use POP3)--%>
        <% if (ShowEmail) { %>
        <li>
            <asp:Label ID="Label1" AssociatedControlID="ddlCategory" Text="Gởi lời nhắn đến:" Width="100" runat="server" />
            <asp:DropDownList ID="ddlCategory" runat="server">
                <asp:ListItem Value="1" Text="Tài khoản trên NewsVN" />
                <asp:ListItem Value="2" Text="Tài khoản Email" />
            </asp:DropDownList>            
        </li>
        <% } %>
        <li>
            <asp:Label ID="Label2" AssociatedControlID="txtTitle" Text="* Tiêu đề:" Width="100" runat="server" />
            <asp:TextBox ID="txtTitle" Width="534" CssClass="validate[required]" runat="server" />
        </li>
        <li>
            <asp:Label ID="Label3" AssociatedControlID="txtContent" Text="* Nội dung nhắn:" Width="100" runat="server" />
            <asp:TextBox ID="txtContent" Width="534" CssClass="validate[required]" runat="server"
                TextMode="MultiLine" Rows="8" MaxLength="300" />
        </li>
        <li class="commands">            
            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                    <asp:HyperLink ID="HyperLink1" CssClass="button-login right" Text="Đăng nhập để gởi tin" runat="server"
                        NavigateUrl="~/account/form/login.aspx" style="margin:0" />
                </AnonymousTemplate>
                <RoleGroups>
                    <asp:RoleGroup Roles="Guest">
                        <ContentTemplate>
                            <asp:LinkButton ID="btnSendMessage" Text="Gởi đi" CssClass="button-send right" runat="server"
                                OnClientClick="return checkValidation();" style="margin:0" OnClick="btnAddComment_Click"/>
                        </ContentTemplate>
                    </asp:RoleGroup>
                </RoleGroups>
            </asp:LoginView>
            <div class="clear"></div>
        </li>
    </ul>
</div>
