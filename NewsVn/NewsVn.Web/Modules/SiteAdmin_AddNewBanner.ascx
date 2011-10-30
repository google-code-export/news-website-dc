<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdmin_AddNewBanner.ascx.cs" Inherits="NewsVn.Web.Modules.SiteAdmin_AddNewBanner" %>
<script type="text/javascript">
    function checkValidation() {
        return $("#update_post_form").validationEngine('validate');
    }
</script>

<asp:UpdatePanel runat="server" ID="upd">
<Triggers>
        <asp:PostBackTrigger ControlID="Button1" />
        <asp:PostBackTrigger ControlID="btnInsert" />
</Triggers>
<ContentTemplate>




<div class="portlet">
    <h2>
        Thêm banner mới</h2>
    <ul id="update_post_form" class="ui-form ui-widget">
     <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
        <li>
            <asp:Label ID="Label1" Text="Vị trí:" runat="server" Width="120" />
            <asp:TextBox ID="txtPosition" Width="450" runat="server" MaxLength="280" Enabled="false" />
        </li>
        <li>
            <asp:Label ID="Label2" Text="Chiều rộng:" runat="server" Width="120" />
            <asp:TextBox ID="txtWidth" CssClass="validate[required]" Width="350" runat="server" MaxLength="4" />&nbsp;<span><b>(px) Vd: 320</b></span>
        </li>
        <li>
            <asp:Label ID="Label3" Text="Chiều cao:" runat="server" Width="120" />
            <asp:TextBox ID="txtHeight" CssClass="validate[required]" Width="350" runat="server" MaxLength="4"/>&nbsp;<span><b>(px) Vd: 120</b></span>
        </li>
        <li>
            <asp:Label ID="Label5" Text="Url:" runat="server" Width="120" />
            <asp:TextBox ID="txtUrl" CssClass="validate[required]" Width="450" runat="server" MaxLength="280" Enabled="false"/>
        </li>
        <li>
            <asp:Label ID="Label6" Text="Tiêu đề:" runat="server" Width="120" />
            <asp:TextBox ID="txtTitle" CssClass="validate[required]" Width="450" runat="server" MaxLength="280" />
        </li>
         <li>
            <asp:Label ID="Label7" Text="Hình ảnh:" runat="server" Width="120" />
            <asp:Image ID="imgBanner" runat="server" />
        </li>
        <li>
            <%--<asp:Label ID="Label4" Text="Hình ảnh:" runat="server" Width="120" />
            <asp:Image ID="imgBanner" runat="server" />--%>
            <asp:Label ID="Label4" Text="Upload Banner:" runat="server" Width="120" />
            <asp:FileUpload ID="fileAvatar"  runat="server" />
           <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Upload" CssClass="button-ok"/>
            
        </li>
        
        <li class="commands">
            <div class="left">
                <asp:LinkButton ID="btnInsert" Text="Thêm" CssClass="button-ok" runat="server"   OnClientClick="return checkValidation()"
                    onclick="btnInsert_Click" />&nbsp;
               <a href="ViewAdBox.aspx" class="button-back">Hủy</a>
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
</div>
</ContentTemplate>
</asp:UpdatePanel>