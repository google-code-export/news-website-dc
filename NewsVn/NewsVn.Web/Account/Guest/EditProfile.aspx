<%@ Page Language="C#" MasterPageFile="~/Account/Guest/Guest.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="NewsVn.Web.Account.Guest.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">

<script type="text/javascript">
    function gotoProfileCommentBox() {
        $("html, body").animate({
            scrollTop: $("#pmessageform_box").offset().top
        }, 1000);
    }
</script>

<div class="portlet">
    <h2>
        Cập nhật Thông tin tài khoản: 
        <asp:Label runat="server" ID="lblNickName" Text=""/>
        <a href="javascript:void(0)" onclick="gotoProfileCommentBox()" class="text-normal font-normal right">
            <asp:Image ID="Image1" ImageUrl="~/images/icons/mail.png" runat="server" style="vertical-align:top;margin-top:12px" />
            Nhắn tin
        </a>
       
    </h2>
     <div class="clear"></div>
    <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width:150px"><b>Biệt danh:</b></td>
            <td style="width:303px"><b> <asp:Label runat="server" ID="lblNickName_01" Text=""/></b></td>
            <td rowspan="15" valign="top" style="width:155px;background:#fff;padding-top:0">
                
                <asp:Image ID="Image2"  AlternateText="" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
                <asp:Image ID="Image3"  AlternateText="" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
                <asp:Image ID="Image4"  AlternateText="" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
            </td>
        </tr>
        <tr>
            <td><b>Tên họ:</b></td>
            <td><asp:TextBox runat="server" ID="txtFullName" /></td>
        </tr>
        <tr>
            <td><b>Tuổi:</b></td>
            <td><asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlAge" runat="server"/></td>
        </tr>
        <tr>
            <td><b>Giới tính:</b></td>
            <td><asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlGender" runat="server" /></td>
        </tr>
        <tr>
            <td><b>Tỉnh/Thành phố:</b></td>
            <td><asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlProvince" runat="server" /></td>
        </tr>
        <tr>
            <td><b>Quốc gia:</b></td>
            <td><asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlCountry" runat="server" /></td>
        </tr>
        <tr>
            <td><b>Chiều cao:</b></td>
            <td><asp:TextBox runat="server" id="txtHeight" /> (cm)</td>
        </tr>
        <tr>
            <td><b>Cân nặng:</b></td>
            <td><asp:TextBox runat="server" id="txtWeight" /> (kg)</td>
        </tr>
        <tr>
            <td><b>Thân hình:</b></td>
            <td><asp:TextBox runat="server" id="txtBodySharp" /></td>
        </tr>
        <tr>
            <td><b>Uống rượu:</b></td>
            <td><asp:CheckBox runat="server" ID="chkDrink" /></td>
        </tr>
        <tr>
            <td><b>Hút thuốc:</b></td>
            <td><asp:CheckBox runat="server" ID="chkSmoke" /></td>
        </tr>
        <tr>
            <td><b>Tình trạng hôn nhân:</b></td>
            <td><asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlMaritalStatus" runat="server" /></td>
        </tr>
        <tr>
            <td><b>Tôn giáo:</b></td>
            <td><asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlReligion" runat="server" /></td>
        </tr>
        <tr>
            <td><b>Học vấn:</b></td>
            <td><asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlEdu" runat="server" /></td>
        </tr>
        <tr>
            <td><b>Nghề nghiệp:</b></td>
            <td><asp:TextBox runat="server" id="txtOccu" /></td>
        </tr>
         <tr>
                <td><b>Email:</b></td>
                <td colspan="2">
                <asp:CheckBox runat="server" ID="chkShowEmail" Text="Hiển thị"  />
                &nbsp;<b><asp:Label runat="server" ID="lblEmail" Text=""/></b></td>
            </tr>
       <tr>
                <td><b>Điện thoại:</b></td>
                <td colspan="2">
                <asp:CheckBox runat="server" ID="chkShowPhone" Text="Hiển thị"   />
                &nbsp; <asp:TextBox runat="server" id="txtPhone" Width="195px"/>
                </td>
            </tr>
        <tr>
            <td><b>Bật mí về bản thân:</b></td>
            <td colspan="2"><asp:TextBox runat="server" id="txtDescription" /></td>
        </tr>
        <tr>
            <td><b>Muốn tìm:</b></td>
            <td colspan="2"><asp:TextBox runat="server" id="txtExpectation" /></td>
        </tr>
         <tr>
            <td colspan="2" style="text-align:center">
            <div>
            <asp:Literal ID="ltrInitInfoError" EnableViewState="false" runat="server" />
            </div>
            <asp:Button runat="server" ID="btnSave" Text="Lưu" CssClass="button" 
                    onclick="btnSave_Click" />&nbsp;
            <asp:Button runat="server" ID="Button1" Text="Hủy" CssClass="button" 
                    onclick="Button1_Click" />
             </td>
        </tr>
    </table>
</div>
</asp:Content>