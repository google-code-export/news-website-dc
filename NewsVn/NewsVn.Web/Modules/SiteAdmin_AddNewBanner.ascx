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
            <asp:DropDownList ID="ddlPositionType" runat="server"  Width="450" CssClass="validate[required]"/>
        </li>
        <li>
            <asp:Label ID="Label12" Text="Loại quảng cáo:" runat="server" Width="120" />
            <asp:DropDownList ID="ddlObjectType" runat="server"  Width="450" CssClass="validate[required]"/>
        </li>
        <li>
            <asp:Label ID="Label2" Text="* Chiều rộng:" runat="server" Width="120" />
            <asp:TextBox ID="txtWidth" CssClass="validate[required]" Width="350" runat="server" MaxLength="4" />&nbsp;<span><b>(px) Vd: 320</b></span>
        </li>
        <li>
            <asp:Label ID="Label3" Text="* Chiều cao:" runat="server" Width="120" />
            <asp:TextBox ID="txtHeight" CssClass="validate[required]" Width="350" runat="server" MaxLength="4"/>&nbsp;<span><b>(px) Vd: 120</b></span>
        </li>
       
        <li>
            <asp:Label ID="Label6" Text="* Tiêu đề:" runat="server" Width="120" />
            <asp:TextBox ID="txtTitle" Width="450" runat="server" MaxLength="280" />
        </li>
        <li>
            <asp:Label ID="Label7" Text="Link đến:" runat="server" Width="120" />
            <asp:TextBox ID="txtUrlLinkTo" Width="450" runat="server" MaxLength="280" />
        </li>
        <li>
            <asp:Label ID="Label8" Text="Khách hàng:" runat="server" Width="120" />
            <asp:TextBox ID="txtCustomer" Width="450" runat="server" MaxLength="280" />
        </li>
        <li>
            <asp:Label ID="Label10" Text="Mô tả Khách hàng:" runat="server" Width="120" />
            <asp:TextBox ID="txtCustomerDesc" Width="450" runat="server" MaxLength="280" Rows="8" TextMode="MultiLine" />
        </li>
        <li>
            <asp:Label ID="Label9" Text="Đơn giá:" runat="server" Width="120" />
            <asp:TextBox ID="txtPrice" Width="450" runat="server" MaxLength="280" />
        </li>
         <li>
            <asp:Label ID="Label5" Text="Url:" runat="server" Width="120" />
            <asp:TextBox ID="txtUrl" Width="450" runat="server" MaxLength="280" Enabled="true" />
        </li>
        <li>
            <asp:Label ID="Label111" Text="Hình ảnh:" runat="server" Width="120px" />
            <div class="contentImgUpload_320">
            <asp:Image ID="imgBanner" runat="server" CssClass="imgUpload_320"/>
            </div>
            
        </li>
        <li>
            <%--<asp:Label ID="Label4" Text="Hình ảnh:" runat="server" Width="120" />
            <asp:Image ID="imgBanner" runat="server" />--%>
            <asp:Label ID="Label4" Text="Upload Banner:" runat="server" Width="120" />
            <asp:FileUpload ID="fileAvatar"  runat="server" />
           <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Upload" CssClass="button-ok"/>
            
        </li>
         <li>
             <asp:Label ID="Label13" Text="Kích hoạt:" runat="server" Width="120" />
           <asp:CheckBox runat="server" ID="chkActivated" Checked="false" />
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