<%@ Page Language="C#" MasterPageFile="~/Account/Guest/Guest.Master" AutoEventWireup="true"
    CodeBehind="EditProfile.aspx.cs" Inherits="NewsVn.Web.Account.Guest.EditProfile" %>

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
        $(function () {
            $("#comment_box").parent().appendTo("form:first"); //fix: control event is never called// remove it if dont want page postback- tip: move dialog into form tag
        });
        function bindImg(e) {
            $("span.ui-dialog-title").text("Cập nhật Avatar");
            $("#<%=Image5.ClientID %>").attr("src", $(e).attr("src"));
            $("#<%=imgAvatar.ClientID %>").attr("src", $("#<%=hidImagePath.ClientID  %>").val());
            $("#comment_box").dialog("open");
        };
    </script>
    <style type="text/css">
        .imgUpload_320
        {
            width: 200px;
            height: auto;
        }
        .contentImgUpload_320
        {
            width: 200px;
            height: 220px;
            overflow: hidden;
        }
    </style>
    <div class="portlet" style="height:765px;">
        <h2>
            Cập nhật Thông tin tài khoản:
            <asp:Label runat="server" ID="lblNickName" Text="" />
            <a href="javascript:void(0)" onclick="gotoProfileCommentBox()" class="text-normal font-normal right">
                <asp:Image ID="Image1" ImageUrl="~/images/icons/mail.png" runat="server" Style="vertical-align: top;
                    margin-top: 12px" />
                Nhắn tin </a>
        </h2>
         <div style="width: 65%" class="left">
                <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 150px">
                            <b>Biệt danh:</b>
                        </td>
                        <td style="width: 303px">
                            <b>
                                <asp:Label runat="server" ID="lblNickName_01" Text="" /></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Tên họ:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFullName" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Tuổi:</b>
                        </td>
                        <td>
                            <asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlAge" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Giới tính:</b>
                        </td>
                        <td>
                            <asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlGender" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Tỉnh/Thành phố:</b>
                        </td>
                        <td>
                            <asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlProvince" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Quốc gia:</b>
                        </td>
                        <td>
                            <asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlCountry" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Chiều cao:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtHeight" />
                            (cm)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Cân nặng:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtWeight" />
                            (kg)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Thân hình:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtBodySharp" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Uống rượu:</b>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkDrink" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Hút thuốc:</b>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkSmoke" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Tình trạng hôn nhân:</b>
                        </td>
                        <td>
                            <asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlMaritalStatus" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Tôn giáo:</b>
                        </td>
                        <td>
                            <asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlReligion" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Học vấn:</b>
                        </td>
                        <td>
                            <asp:DropDownList Width="180px" CssClass="dropdown" ID="ddlEdu" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Nghề nghiệp:</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtOccu" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Email:</b>
                        </td>
                        <td colspan="2">
                            <asp:CheckBox runat="server" ID="chkShowEmail" Text="Hiển thị" />
                            &nbsp;<b><asp:Label runat="server" ID="lblEmail" Text="" /></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Điện thoại:</b>
                        </td>
                        <td colspan="2">
                            <asp:CheckBox runat="server" ID="chkShowPhone" Text="Hiển thị" />
                            &nbsp;
                            <asp:TextBox runat="server" ID="txtPhone" Width="195px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Bật mí về bản thân:</b>
                        </td>
                        <td colspan="2">
                            <asp:TextBox runat="server" ID="txtDescription" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Muốn tìm:</b>
                        </td>
                        <td colspan="2">
                            <asp:TextBox runat="server" ID="txtExpectation" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <div>
                                <asp:Literal ID="ltrInitInfoError" EnableViewState="false" runat="server" />
                            </div>
                            <asp:Button runat="server" ID="btnSave" Text="Lưu" CssClass="button-ok" OnClick="btnSave_Click" />&nbsp;
                            <asp:Button runat="server" ID="Button1" Text="Hủy" CssClass="button-back" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 30%" class=" contentImgUpload_320 left">
                <asp:Image ID="Image2" AlternateText="" runat="server" CssClass="imgUpload_320" Style="margin: 7px 0 0;
                    cursor: pointer;" onClick="bindImg(this);" />
            </div>
        <div id="comment_box" class="dialog" style="display: none;">
        <div id="testcomment_box">
            <div style="float: left; width: 250px; margin: 0 20px 0 20px">
                <div style="font-weight: bold">
                    Upload avatar khác
                </div>
                <div>
                    Bạn có thể tải tập tin JPG, GIF hoặc PNG, tối đa là 4MB, kích cỡ tối thiểu 180x180px</div>
                <div>
                    <asp:Image ID="Image5" Width="180px" Height="200px" runat="server" ImageUrl="" Style="margin: 16px 0 0 20px" /></div>
                <div align="center">
                    <i>Avatar của bạn</i></div>
            </div>
            <div style="float: left; width: 250px">
                <div>
                    <asp:Image ID="imgAvatar" Width="200px" Height="256px" runat="server" ImageUrl=""
                        Style="margin: 7px 0 5px 0" /></div>
                <div>
                <asp:FileUpload ID="fileAvatar" runat="server" CssClass="finput inherit_finput" />
                </div>
            </div>
            <div class="clear">
            </div>
            <div align="center">
                <asp:Button ID="btnUpload" CssClass="button-ok" Text="Đồng ý" runat="server" OnClick="btnUpload_Click" />
                <span style="float: left">&nbsp;&nbsp;</span>
                <asp:Button ID="Button2" CssClass="button-cancel" Text="Hủy bỏ" runat="server" />
            </div>
        </div>
    </div>
    <div style="display: none">
        <asp:Button ID="Button3" Text="Hủy bỏ" runat="server" OnClick="Button3_Click" />
        <asp:HiddenField runat="server" ID="hidImagePath" Value="" />
    </div>
    </div>
    
</asp:Content>
