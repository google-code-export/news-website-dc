<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="NewsVn.Web.Account.Form.Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <br/><br/><br/>
    <div class="portlet" style="width:358px;margin:0 auto;">
        <asp:Wizard ID="Wizard1" Width="358" runat="server">
            <StartNextButtonStyle CssClass="button" />
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" StepType="Start" runat="server">
                    <h2>Thông tin tài khoản mới</h2>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" StepType="Complete" runat="server">
                    <h2>Hoàn tất đăng ký</h2>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </div>
</asp:Content>

