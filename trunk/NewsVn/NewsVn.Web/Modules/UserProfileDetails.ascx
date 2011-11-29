<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserProfileDetails.ascx.cs" Inherits="NewsVn.Web.Modules.UserProfileDetails" %>

<script runat="server">
    
</script>

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
        <span><%= Datasource.Nickname %></span>
        <a href="javascript:void(0)" onclick="gotoProfileCommentBox()" class="text-normal font-normal right">
            <asp:Image ID="Image1" ImageUrl="" runat="server" style="vertical-align:top;margin-top:12px" />
            Nhắn tin
        </a>
        <div class="clear"></div>
    </h2>
    <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th colspan="3" align="left">
                Hiện tại: <%= string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) %>
                | Xem: <%= string.Format("{0:N0}", 1234) %>
            </th>
        </tr>
        <tr>
            <td style="width:150px"><b>Biệt danh:</b></td>
            <td style="width:303px"><%=Datasource.Nickname %></td>
            <td rowspan="15" valign="top" style="width:155px;background:#fff;padding-top:0">
                <asp:Image ID="Image2"  AlternateText="" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
            </td>
        </tr>
        <tr>
            <td><b>Tên họ:</b></td>
            <td><%=Datasource.Name %></td>
        </tr>
        <tr>
            <td><b>Tuổi:</b></td>
            <td><%=Datasource.Age %></td>
        </tr>
        <tr>
            <td><b>Giới tính:</b></td>
            <td><asp:Label runat="server" ID="lblGender" Text=""/></td>
        </tr>
        <tr>
            <td><b>Tỉnh/Thành phố:</b></td>
            <td><asp:Label runat="server" ID="lblLocation" Text=""/></td>
        </tr>
        <tr>
            <td><b>Quốc gia:</b></td>
            <td><asp:Label runat="server" ID="lblCountry" Text=""/></td>
        </tr>
        <tr>
            <td><b>Chiều cao:</b></td>
            <td><asp:Label runat="server" ID="lblHeight" Text=""/></td>
        </tr>
        <tr>
            <td><b>Cân nặng:</b></td>
            <td><asp:Label runat="server" ID="lblWeight" Text=""/></td>
        </tr>
        <tr>
            <td><b>Thân hình:</b></td>
            <td><%=Datasource.BodyShape %></td>
        </tr>
        <tr>
            <td><b>Uống rượu:</b></td>
            <td><%=Datasource.Drink==true?"Có":"Không" %></td>
        </tr>
        <tr>
            <td><b>Hút thuốc:</b></td>
            <td><%=Datasource.Smoke==true?"Có":"Không" %></td>
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
            <td><asp:Label runat="server" ID="lblEducation" Text=""/></td>
        </tr>
        <tr>
            <td><b>Nghề nghiệp:</b></td>
            <td><%=Datasource.Career %></td>
        </tr>
        <% if (ShowEmail) { %>
            <tr>
                <td><b>Email:</b></td>
                <td colspan="2"><%=Datasource.Email %></td>
            </tr>
        <% } %>
        <% if (ShowPhone) { %>
            <tr>
                <td><b>Điện thoại:</b></td>
                <td colspan="2"><%=Datasource.Phone %></td>
            </tr>
        <% } %>
        <tr>
            <td><b>Bật mí về bản thân:</b></td>
            <td colspan="2"><%=Datasource.Description %></td>
        </tr>
        <tr>
            <td><b>Muốn tìm:</b></td>
            <td colspan="2"><%=Datasource.Expectation %></td>
        </tr>
    </table>
</div>
