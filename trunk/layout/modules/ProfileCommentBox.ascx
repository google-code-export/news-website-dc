<%@ Control Language="C#" ClassName="ProfileCommentBox" %>

<link href="<%= Page.ResolveUrl("~/styles/validation.css") %>" rel="stylesheet" type="text/css" />
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine-vi.js") %>" type="text/javascript"></script>

<script type="text/javascript">

    function checkValidation() {
        return $("#pcommentform_box").validationEngine('validate');
    }
</script>

<div class="portlet">
    <h2>
        Bình luận cho:
        <span>Ham hố lãng tử</span>
    </h2>
    <ul id="pcommentform_box" class="ui-form ui-widget">
        <li style="border-bottom:1px dotted #333;">
            Vui lòng nhập <b>Tiếng Việt Unicode có dấu</b>
        </li><li></li>
        <li>
            <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" Width="100" runat="server" />
            <asp:TextBox ID="txtTitle" Width="534" CssClass="validate[required]" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtContent" Text="Bình luận:" Width="100" runat="server" />
            <asp:TextBox ID="txtContent" Width="534" CssClass="validate[required]" runat="server"
                TextMode="MultiLine" Rows="8" MaxLength="300" />
        </li>
        <li class="commands">            
            <asp:LoginView runat="server">
                <AnonymousTemplate>
                    <asp:HyperLink CssClass="button-login right" Text="Đăng nhập để bình luận" runat="server"
                        NavigateUrl="~/account/form/login.aspx" style="margin:0" />
                </AnonymousTemplate>
                <RoleGroups>
                    <asp:RoleGroup Roles="Guest">
                        <ContentTemplate>
                            <asp:LinkButton ID="btnComment" Text="Bình luận" CssClass="button-send right" runat="server"
                                OnClientClick="return checkValidation();" style="margin:0" />
                        </ContentTemplate>
                    </asp:RoleGroup>
                </RoleGroups>
            </asp:LoginView>
            <div class="clear"></div>
        </li>
    </ul>
</div>
