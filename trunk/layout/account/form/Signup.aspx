<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" %>

<script runat="server">

</script>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server">
    <br/><br/><br/>
    <div class="portlet" style="width:358px;margin:0 auto;">
        <asp:Wizard Width="358" runat="server">
            <StartNextButtonStyle CssClass="button" />
            <WizardSteps>
                <asp:WizardStep StepType="Start" runat="server">
                    <h2>Thông tin tài khoản mới</h2>
                </asp:WizardStep>
                <asp:WizardStep StepType="Complete" runat="server">
                    <h2>Hoàn tất đăng ký</h2>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
</asp:Content>

