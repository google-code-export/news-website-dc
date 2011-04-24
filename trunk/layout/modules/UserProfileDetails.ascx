<%@ Control Language="C#" ClassName="UserProfileDetails" %>

<script runat="server">
    //Sample property used only for building layout
    //Replace with real UserProfile.ShowEmail
    public bool ShowEmail { get; set; }
    //Sample property used only for building layout
    //Replace with real UserProfile.ShowPhone
    public bool ShowPhone { get; set; }
    //Use to set sample properties
    //used only for building layout
    protected void Page_Load(object sender, EventArgs args)
    {
        this.ShowEmail = true;
        this.ShowPhone = true;
    }
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
        <span>Ham hố lãng tử</span>
        <a href="javascript:void(0)" onclick="gotoProfileCommentBox()" class="text-normal font-normal right">
            <asp:Image ImageUrl="~/images/icons/mail.png" runat="server" style="vertical-align:top;margin-top:12px" />
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
            <td style="width:303px">hamho_langtu</td>
            <td rowspan="15" valign="top" style="width:155px;background:#fff;padding-top:0">
                <%--Every user has maximum 3 avatars, first avatar will be shown on profile list, if user didnt upload an avatar, use default 'No Photo' image in replace--%>
                <%--In database, each image url will be separated by ';'--%>
                <asp:Image ImageUrl="~/resources/Profiles/no_photo.gif" AlternateText="Nickname" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
                <asp:Image ImageUrl="~/resources/Profiles/no_photo.gif" AlternateText="Nickname" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
                <asp:Image ImageUrl="~/resources/Profiles/no_photo.gif" AlternateText="Nickname" Width="155px" Height="155px" runat="server" style="margin:7px 0 0" />
            </td>
        </tr>
        <tr>
            <td><b>Tên họ:</b></td>
            <td>Ham hố lãng tử</td>
        </tr>
        <tr>
            <td><b>Tuổi:</b></td>
            <td>35</td>
        </tr>
        <tr>
            <td><b>Giới tính:</b></td>
            <td>Nam</td>
        </tr>
        <tr>
            <td><b>Tỉnh/Thành phố:</b></td>
            <td>Hồ Chí Minh</td>
        </tr>
        <tr>
            <td><b>Quốc gia:</b></td>
            <td>Việt Nam</td>
        </tr>
        <tr>
            <td><b>Chiều cao:</b></td>
            <td>1m5</td>
        </tr>
        <tr>
            <td><b>Cân nặng:</b></td>
            <td>200kg</td>
        </tr>
        <tr>
            <td><b>Thân hình:</b></td>
            <td>Mập ú</td>
        </tr>
        <tr>
            <td><b>Uống rượu:</b></td>
            <td>Có</td>
        </tr>
        <tr>
            <td><b>Hút thuốc:</b></td>
            <td>Có</td>
        </tr>
        <tr>
            <td><b>Tình trạng hôn nhân:</b></td>
            <td>Độc thân</td>
        </tr>
        <tr>
            <td><b>Tôn giáo:</b></td>
            <td>Không có đạo</td>
        </tr>
        <tr>
            <td><b>Học vấn:</b></td>
            <td>Sẽ nói sau</td>
        </tr>
        <tr>
            <td><b>Nghề nghiệp:</b></td>
            <td>Sẽ nói sau</td>
        </tr>
        <% if (ShowEmail) { %>
            <tr>
                <td><b>Email:</b></td>
                <td colspan="2">hamho_langtu@yahoo.com</td>
            </tr>
        <% } %>
        <% if (ShowPhone) { %>
            <tr>
                <td><b>Điện thoại:</b></td>
                <td colspan="2">0909.909090</td>
            </tr>
        <% } %>
        <tr>
            <td><b>Bật mí về bản thân:</b></td>
            <td colspan="2">Hơi dâm dê vô giáo dục chút nhưng cũng rất gă lăng.. tăn</td>
        </tr>
        <tr>
            <td><b>Muốn tìm:</b></td>
            <td colspan="2">Người chịu đựng nổi mình</td>
        </tr>
    </table>
</div>
