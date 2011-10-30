<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdmin_UpdateBannerDetail.ascx.cs"
    Inherits="NewsVn.Web.Modules.SiteAdmin_UpdateBannerDetail" %>
    <style type="text/css">
    .imgUpload_320
    {
        width:500px;
        height:auto;
      
     }
     .contentImgUpload_320
     {
          width:500px;
        height:500px;
           overflow:hidden;
         }
    </style>
    <script type="text/javascript">
        function checkValidation() {
            return $("#update_post_form").validationEngine('validate');
        }
</script>
<div class="portlet">
    <h2>
        Chỉnh sửa thông tin banner</h2>
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
            <asp:TextBox ID="txtUrl" Width="450" runat="server" MaxLength="280" Enabled="false" />
        </li>
        <li>
            <asp:Label ID="Label6" Text="Tiêu đề:" runat="server" Width="120" />
            <asp:TextBox ID="txtTitle" Width="450" runat="server" MaxLength="280" />
        </li>
        <li>
            <asp:Label ID="Label4" Text="Hình ảnh:" runat="server" Width="120px" />
            <div class="contentImgUpload_320">
            <asp:Image ID="imgBanner" runat="server" CssClass="imgUpload_320"/>
            </div>
            
        </li>
        <li>
             <asp:FileUpload ID="fileAvatar"  runat="server" />
           <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Upload" CssClass="button-ok"/>
        </li>
        <li class="commands">
             <div class="left">
                <asp:LinkButton ID="btnUpdate" Text="Lưu" CssClass="button-ok" runat="server"  OnClientClick="return checkValidation()"
                     onclick="btnUpdate_Click" />&nbsp;
               <a href="ViewAdBox.aspx" class="button-back">Hủy</a>
            </div>
            <div class="clear">
            </div>
        </li>
    </ul>
</div>
