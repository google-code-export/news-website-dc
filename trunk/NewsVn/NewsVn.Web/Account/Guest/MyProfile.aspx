<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Guest/Guest.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="NewsVn.Web.Account.Guest.MyProfile" %>

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
        Thông tin của:
        <asp:Label runat="server" ID="lblNickName" Text=""/>
       <a href="javascript:void(0)" onclick="gotoProfileCommentBox()" class="text-normal font-normal right">
           <asp:LinkButton runat="server" ID="lnkbtnEditProfile" PostBackUrl="~/thanh-vien/cap-nhat-tai-khoan.aspx" >
           <asp:Image ID="Image1" ImageUrl="~/images/icons/EditProfile.png" runat="server"  style="vertical-align:top;margin-top:12px"/>
           Cập nhật tài khoản</asp:LinkButton> 
        </a>
       
    </h2>
     <div class="clear"></div>
    <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
       <%-- <tr>
            <th colspan="3" align="left">
                Hiện tại: <%= string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) %>
                | Xem: <%= string.Format("{0:N0}", 1234) %>
            </th>
        </tr>--%>
        <tr>
            <td style="width:150px"><b>Biệt danh:</b></td>
            <td style="width:303px"><asp:Label runat="server" ID="lblNickName_01" Text=""/></td>
            <td rowspan="15" valign="top" style="width:155px;background:#fff;padding-top:0">
                
                <asp:Image ID="Image2"  AlternateText="" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
                <asp:Image ID="Image3"  AlternateText="" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
                <asp:Image ID="Image4"  AlternateText="" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
            </td>
        </tr>
        <tr>
            <td><b>Tên họ:</b></td>
            <td><asp:Label runat="server" ID="lblFullName" Text=""/></td>
        </tr>
        <tr>
            <td><b>Tuổi:</b></td>
            <td><asp:Label runat="server" ID="lblAge" Text=""/></td>
        </tr>
        <tr>
            <td><b>Giới tính:</b></td>
            <td><asp:Label runat="server" ID="lblGender" Text=""/></td>
        </tr>
        <tr>
            <td><b>Tỉnh/Thành phố:</b></td>
            <td><asp:Label runat="server" ID="lblProvince" Text=""/></td>
        </tr>
        <tr>
            <td><b>Quốc gia:</b></td>
            <td><asp:Label runat="server" ID="lblCountry" Text=""/></td>
        </tr>
        <tr>
            <td><b>Chiều cao:</b></td>
            <td><asp:Label runat="server" ID="lblHeight" Text=""/> (cm)</td>
        </tr>
        <tr>
            <td><b>Cân nặng:</b></td>
            <td><asp:Label runat="server" ID="lblWeight" Text=""/> (kg)</td>
        </tr>
        <tr>
            <td><b>Thân hình:</b></td>
            <td><asp:Label runat="server" ID="lblBodyShape" Text=""/></td>
        </tr>
        <tr>
            <td><b>Uống rượu:</b></td>
            <td><asp:Label runat="server" ID="lblDrink" Text=""/></td>
        </tr>
        <tr>
            <td><b>Hút thuốc:</b></td>
            <td><asp:Label runat="server" ID="lblSmoke" Text=""/></td>
        </tr>
        <tr>
            <td><b>Tình trạng hôn nhân:</b></td>
            <td><asp:Label runat="server" ID="lblMarialStatus" Text=""/></td>
        </tr>
        <tr>
            <td><b>Tôn giáo:</b></td>
            <td><asp:Label runat="server" ID="lblReligion" Text=""/></td>
        </tr>
        <tr>
            <td><b>Học vấn:</b></td>
            <td><asp:Label runat="server" ID="lblEdu" Text=""/></td>
        </tr>
        <tr>
            <td><b>Nghề nghiệp:</b></td>
            <td><asp:Label runat="server" ID="lblOccu" Text=""/></td>
        </tr>
         <tr>
                <td><b>Email:</b></td>
                <td colspan="2">
                <asp:CheckBox runat="server" ID="chkShowEmail" Text="Hiển thị" Enabled="false" />
                &nbsp;<asp:Label runat="server" ID="lblEmail" Text=""/> </td>
            </tr>
       <tr>
                <td><b>Điện thoại:</b></td>
                <td colspan="2">
                <asp:CheckBox runat="server" ID="chkShowPhone" Text="Hiển thị"  Enabled="false" />
                &nbsp; <asp:Label runat="server" ID="lblPhone" Text=""/>
                </td>
            </tr>
        <tr>
            <td><b>Bật mí về bản thân:</b></td>
            <td colspan="2"><asp:Label runat="server" ID="lblDescription" Text=""/></td>
        </tr>
        <tr>
            <td><b>Muốn tìm:</b></td>
            <td colspan="2"><asp:Label runat="server" ID="lblExpectation" Text=""/></td>
        </tr>
    </table>
</div>

</asp:Content>
