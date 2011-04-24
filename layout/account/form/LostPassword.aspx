<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" %>

<script runat="server">

</script>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server">
    <div class="portlet" style="width:470px;margin:0 auto;">
        <h2>Phục hồi mật khẩu</h2>
        <asp:PasswordRecovery ID="passwordRecovery" runat="server">
            <UserNameTemplate>                
                <ul class="ui-form ui-widget">
                    <li>
                        <asp:Label AssociatedControlID="UserName" Text="Tên tài khoản:" Width="100" runat="server" />
                        <asp:TextBox ID="UserName" Width="352" runat="server" />
                    </li>
                    <li class="commands">
                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Tiếp tục" 
                            CssClass="button right" OnClientClick="" style="margin:0" />
                        <div class="clear"></div>
                    </li>
                    <li>
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                    </li>
                </ul>
            </UserNameTemplate>
            <QuestionTemplate>
                <ul class="ui-form ui-widget">
                    <li>
                        <asp:Literal ID="UserName" runat="server"></asp:Literal>
                    </li>
                    <li>
                        <asp:Literal ID="Question" runat="server"></asp:Literal>
                    </li>
                    <li>
                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Answer:</asp:Label>
                        <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                    </li>
                    <li class="commands">
                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Submit"
                            CssClass="button right" OnClientClick="" style="margin:0" />
                        <div class="clear"></div>
                    </li>
                    <li>
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                    </li>
                </ul>
            </QuestionTemplate>
            <SuccessTemplate>
                Your password has been sent to you.
            </SuccessTemplate>
            
        </asp:PasswordRecovery>        
    </div>
</asp:Content>

