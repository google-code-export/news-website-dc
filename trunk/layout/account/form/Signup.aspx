<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs args)
    {
        this.GenerateAgeDropDownLists();
    }

    private void GenerateAgeDropDownLists()
    {
        string age = string.Empty;
        for (int i = 18; i <= 80; i++)
        {
            age = i.ToString();
            ddlAge.Items.Add(new ListItem(age, age));
        }
    }
    
    protected void Start_Click(object sender, EventArgs args)
    {
        wzUserSignUp.ActiveStepIndex = 1;
    }

    protected void Finish_Click(object sender, EventArgs args)
    {
        wzUserSignUp.ActiveStepIndex = 2;
    }
</script>

<asp:Content ContentPlaceHolderID="head" runat="server">
<link href="<%= Page.ResolveUrl("~/styles/validation.css") %>" rel="stylesheet" type="text/css" />
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine-vi.js") %>" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        $("#content").css({ "min-height": "120px" });

        var selector = $("#<%= ddlSecurityQuestion.ClientID %>, #<%= ddlCountry.ClientID %>");
        selector.selectmenu({ width: "356px" });
        $(selector).each(function () {
            $("#" + $(this).attr("id") + "-menu").width(362);
        });
        /* Decoy textboxes are used only to fix validation for styled dropdownlist
        To insert data, please use ddlABC.SelectedValue as usual
        */
        selector.change(function () {
            $(this).prev(".decoy").val($(this).val());
        });
        $("#<%= ddlSecurityQuestion.ClientID %>-button .ui-selectmenu-icon,"
            + "#<%= ddlSecurityQuestion.ClientID %>-button .ui-selectmenu-status,"
            + "#<%= ddlCountry.ClientID %>-button .ui-selectmenu-icon,"
            + "#<%= ddlCountry.ClientID %>-button .ui-selectmenu-status")
        .click(function () {
            $("#<%= ddlSecurityQuestion.ClientID %>-menu").css({ "zIndex": 100 });
            $("#<%= ddlCountry.ClientID %>-menu").css({ "zIndex": 100 });
        });

        selector = "#<%= ddlAge.ClientID %>, #<%= ddlGender.ClientID %>";
        $(selector).selectmenu({ width: "100px" });
        $(selector).each(function () {
            $("#" + $(this).attr("id") + "-menu").width(106);
        });

        $("#accountform_box select, #profileform_box select").next(".ui-selectmenu").addClass("select");
        $("#accountform_box select, #profileform_box select").next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");

        $("#<%= txtConfirmPassword.ClientID %>").addClass("validate[required,equals[<%= txtPassword.ClientID %>]]");
    });
    
    function checkCreateAccountValidation() {
        return $("#accountform_box").validationEngine('validate');
    }

    function checkCreateProfileValidation() {
        return $("#profileform_box").validationEngine('validate');
    }
</script>
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server">
    <br/>
    <div class="portlet" style="width:470px;margin:0 auto;">
        <asp:Wizard ID="wzUserSignUp" CssClass="ui-wizard" Width="470" runat="server">
            <WizardSteps>
                <asp:WizardStep StepType="Start" AllowReturn="false" runat="server">
                    <h2>Thông tin tài khoản mới</h2>
                    <ul id="accountform_box" class="ui-form ui-widget">
                        <li>
                            <asp:Label AssociatedControlID="txtUsername" Text="Tài khoản:" Width="100" runat="server" />
                            <asp:TextBox ID="txtUsername" Width="352" CssClass="validate[required]" MaxLength="50" runat="server" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="txtPassword" Text="Mật khẩu:" Width="100" runat="server" />
                            <asp:TextBox ID="txtPassword" TextMode="Password" Width="352" CssClass="validate[required]" runat="server" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="txtConfirmPassword" Text="Xác nhận lại:" Width="100" runat="server" />
                            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" Width="352" runat="server" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="ddlSecurityQuestion" Text="Câu hỏi bảo mật:" Width="100" runat="server" />
                            <asp:TextBox ID="txtSecurityQuestion" Width="352" CssClass="validate[required] decoy" runat="server" />
                            <asp:DropDownList ID="ddlSecurityQuestion" runat="server">
                                <asp:ListItem Value="" Text="[Chọn câu hỏi bảo mật]" />
	                            <asp:ListItem Value="1" Text="Lúc nhỏ bạn thích xem hoạt hình nào nhất?" />
	                            <asp:ListItem Value="2" Text="Món khoái khẩu của bạn lúc nhỏ là gì?" />
	                            <asp:ListItem Value="3" Text="Nhân vật  trong phim mà bạn thích nhất là ai?" />
	                            <asp:ListItem Value="4" Text="Ai  là tác giả bạn thích nhất?" />
	                            <asp:ListItem Value="5" Text="Đội thể thao bạn thích nhất tên gì?" />
	                            <asp:ListItem Value="6" Text="Tên của nhạc sĩ bạn thích nhất?" />
	                            <asp:ListItem Value="7" Text="Tựa quyển sách bạn thích đọc nhất?" />
	                            <asp:ListItem Value="8" Text="Màu sắc ưa thích của bạn?" />
                            </asp:DropDownList>
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="txtSecurityAnswer" Text="Trả lời:" Width="100" runat="server" />
                            <asp:TextBox ID="txtSecurityAnswer" Width="352" CssClass="validate[required]" runat="server" />
                        </li>
                    </ul>
                </asp:WizardStep>
                <asp:WizardStep StepType="Finish" runat="server">
                    <h2>Khởi tạo hồ sơ</h2>
                    <ul id="profileform_box" class="ui-form ui-widget">
                        <li style="border-bottom:1px dotted #333;">
                            Các trường có dấu <b>*</b> là bắt buộc |
                            Vui lòng nhập <b>Tiếng Việt Unicode có dấu</b>
                        </li><li></li>
                        <li>
                            <asp:Label AssociatedControlID="txtNickname" Text="* Biệt danh:" Width="100" runat="server" />
                            <asp:TextBox ID="txtNickname" Width="352" CssClass="validate[required]" MaxLength="50" runat="server" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="txtName" Text="* Tên họ:" Width="100" runat="server" />
                            <asp:TextBox ID="txtName" Width="352" CssClass="validate[required]" MaxLength="150" runat="server" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="" Text="Tuổi:" Width="100" runat="server" />
                            <asp:DropDownList ID="ddlAge" runat="server" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="" Text="Giới tính:" Width="100" runat="server" />
                            <asp:DropDownList ID="ddlGender" runat="server">
                                <asp:ListItem Value="True" Text="Nam" />
                                <asp:ListItem Value="False" Text="Nữ" />
                            </asp:DropDownList>
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="txtLocation" Text="Tỉnh/Thành phố:" Width="100" runat="server" />
                            <asp:TextBox ID="txtLocation" Width="352" MaxLength="200" runat="server" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="ddlCountry" Text="Quốc gia:" Width="100" runat="server" />
                            <asp:DropDownList ID="ddlCountry" runat="server">
                                <asp:ListItem Value="" Text="[Chọn quốc gia]" />
                                <asp:ListItem Value="af" Text="Afghanistan" />
                                <asp:ListItem Value="eg" Text="Ai Cập" />
                                <asp:ListItem Value="al" Text="Albania" />
                                <asp:ListItem Value="dz" Text="Algeria" />
                                <asp:ListItem Value="as" Text="American Samoa" />
                                <asp:ListItem Value="ad" Text="Andorra" />
                                <asp:ListItem Value="ao" Text="Angola" />
                                <asp:ListItem Value="ai" Text="Anguilla" />
                                <asp:ListItem Value="uk" Text="Anh Quốc" />
                                <asp:ListItem Value="aq" Text="Antarctica" />
                                <asp:ListItem Value="ag" Text="Antigua và Barbuda" />
                                <asp:ListItem Value="ar" Text="Argentina" />
                                <asp:ListItem Value="am" Text="Armenia" />
                                <asp:ListItem Value="aw" Text="Aruba" />
                                <asp:ListItem Value="au" Text="Australia" />
                                <asp:ListItem Value="at" Text="Austria" />
                                <asp:ListItem Value="az" Text="Azerbaijan" />
                                <asp:ListItem Value="pl" Text="Ba Lan" />
                                <asp:ListItem Value="bs" Text="Bahamas" />
                                <asp:ListItem Value="bh" Text="Bahrain" />
                                <asp:ListItem Value="bd" Text="Bangladesh" />
                                <asp:ListItem Value="bb" Text="Barbados" />
                                <asp:ListItem Value="by" Text="Belarus" />
                                <asp:ListItem Value="bz" Text="Belize" />
                                <asp:ListItem Value="bj" Text="Benin" />
                                <asp:ListItem Value="bm" Text="Bermuda" />
                                <asp:ListItem Value="bt" Text="Bhutan" />
                                <asp:ListItem Value="bo" Text="Bolivia" />
                                <asp:ListItem Value="ba" Text="Bosnia và Herzegovina" />
                                <asp:ListItem Value="bw" Text="Botswana" />
                                <asp:ListItem Value="br" Text="Brazil" />
                                <asp:ListItem Value="bn" Text="Brunei" />
                                <asp:ListItem Value="bg" Text="Bulgaria" />
                                <asp:ListItem Value="bf" Text="Burkina Faso" />
                                <asp:ListItem Value="bi" Text="Burundi" />
                                <asp:ListItem Value="kp" Text="Bắc Triều Tiên" />
                                <asp:ListItem Value="be" Text="Bỉ" />
                                <asp:ListItem Value="pt" Text="Bồ Đào Nha" />
                                <asp:ListItem Value="ci" Text="Bờ Biển Ngà" />
                                <asp:ListItem Value="kh" Text="Cambodia" />
                                <asp:ListItem Value="cm" Text="Cameroon" />
                                <asp:ListItem Value="ca" Text="Canada" />
                                <asp:ListItem Value="cv" Text="Cape Verde" />
                                <asp:ListItem Value="td" Text="Chad" />
                                <asp:ListItem Value="cl" Text="Chile" />
                                <asp:ListItem Value="co" Text="Colombia" />
                                <asp:ListItem Value="km" Text="Comoros" />
                                <asp:ListItem Value="cg" Text="Congo" />
                                <asp:ListItem Value="cr" Text="Costa Rica" />
                                <asp:ListItem Value="hr" Text="Croatia" />
                                <asp:ListItem Value="cu" Text="Cuba" />
                                <asp:ListItem Value="cy" Text="Cyprus" />
                                <asp:ListItem Value="ae" Text="Các tiểu Vương quốc Ả Rập Thống nhất" />
                                <asp:ListItem Value="um" Text="Các tiểu đảo xa của Mỹ" />
                                <asp:ListItem Value="cz" Text="Cộng hòa Czech" />
                                <asp:ListItem Value="do" Text="Cộng hòa Dominican" />
                                <asp:ListItem Value="cd" Text="Cộng hòa Dân chủ Congo" />
                                <asp:ListItem Value="cf" Text="Cộng hòa Trung Phi" />
                                <asp:ListItem Value="dj" Text="Djibouti" />
                                <asp:ListItem Value="dm" Text="Dominica" />
                                <asp:ListItem Value="ec" Text="Ecuador" />
                                <asp:ListItem Value="sv" Text="El Salvador" />
                                <asp:ListItem Value="gq" Text="Equatorial Guinea" />
                                <asp:ListItem Value="er" Text="Eritrea" />
                                <asp:ListItem Value="ee" Text="Estonia" />
                                <asp:ListItem Value="et" Text="Ethiopia" />
                                <asp:ListItem Value="fj" Text="Fiji" />
                                <asp:ListItem Value="gf" Text="French Guyana" />
                                <asp:ListItem Value="pf" Text="French Polynesia" />
                                <asp:ListItem Value="ga" Text="Gabon" />
                                <asp:ListItem Value="gm" Text="Gambia" />
                                <asp:ListItem Value="ge" Text="Georgia" />
                                <asp:ListItem Value="gh" Text="Ghana" />
                                <asp:ListItem Value="gi" Text="Gibraltar" />
                                <asp:ListItem Value="gl" Text="Greenland" />
                                <asp:ListItem Value="gd" Text="Grenada" />
                                <asp:ListItem Value="gp" Text="Guadeloupe" />
                                <asp:ListItem Value="gu" Text="Guam" />
                                <asp:ListItem Value="gt" Text="Guatemala" />
                                <asp:ListItem Value="gn" Text="Guinea" />
                                <asp:ListItem Value="gw" Text="Guinea-Bissau" />
                                <asp:ListItem Value="gy" Text="Guyana" />
                                <asp:ListItem Value="ht" Text="Haiti" />
                                <asp:ListItem Value="hn" Text="Honduras" />
                                <asp:ListItem Value="hu" Text="Hungary" />
                                <asp:ListItem Value="gr" Text="Hy Lạp" />
                                <asp:ListItem Value="nl" Text="Hà Lan" />
                                <asp:ListItem Value="kr" Text="Hàn Quốc" />
                                <asp:ListItem Value="hk" Text="Hồng Kông" />
                                <asp:ListItem Value="is" Text="Iceland" />
                                <asp:ListItem Value="id" Text="Indonesia" />
                                <asp:ListItem Value="ir" Text="Iran" />
                                <asp:ListItem Value="iq" Text="Iraq" />
                                <asp:ListItem Value="ie" Text="Ireland" />
                                <asp:ListItem Value="il" Text="Israel" />
                                <asp:ListItem Value="it" Text="Italy" />
                                <asp:ListItem Value="jm" Text="Jamaica" />
                                <asp:ListItem Value="jo" Text="Jordan" />
                                <asp:ListItem Value="kz" Text="Kazakhstan" />
                                <asp:ListItem Value="ke" Text="Kenya" />
                                <asp:ListItem Value="xe" Text="Khu Trung lập Iraq-Saudi Arabia" />
                                <asp:ListItem Value="ki" Text="Kiribati" />
                                <asp:ListItem Value="kw" Text="Kuwait" />
                                <asp:ListItem Value="kg" Text="Kyrgyzstan" />
                                <asp:ListItem Value="lv" Text="Latvia" />
                                <asp:ListItem Value="lb" Text="Lebanon" />
                                <asp:ListItem Value="ls" Text="Lesotho" />
                                <asp:ListItem Value="lr" Text="Liberia" />
                                <asp:ListItem Value="ly" Text="Libya" />
                                <asp:ListItem Value="li" Text="Liechtenstein" />
                                <asp:ListItem Value="lt" Text="Lithuania" />
                                <asp:ListItem Value="fm" Text="Liên bang Micronesia" />
                                <asp:ListItem Value="lu" Text="Luxembourg" />
                                <asp:ListItem Value="la" Text="Lào" />
                                <asp:ListItem Value="ps" Text="Lãnh thổ Palestine" />
                                <asp:ListItem Value="xx" Text="Lãnh thổ bị tranh chấp" />
                                <asp:ListItem Value="io" Text="Lãnh thổ Ấn Độ Dương thuộc Anh" />
                                <asp:ListItem Value="mo" Text="Macau" />
                                <asp:ListItem Value="mk" Text="Macedonia" />
                                <asp:ListItem Value="mg" Text="Madagascar" />
                                <asp:ListItem Value="mw" Text="Malawi" />
                                <asp:ListItem Value="my" Text="Malaysia" />
                                <asp:ListItem Value="mv" Text="Maldives" />
                                <asp:ListItem Value="ml" Text="Mali" />
                                <asp:ListItem Value="mt" Text="Malta" />
                                <asp:ListItem Value="mq" Text="Martinique" />
                                <asp:ListItem Value="mr" Text="Mauritania" />
                                <asp:ListItem Value="mu" Text="Mauritius" />
                                <asp:ListItem Value="yt" Text="Mayotte" />
                                <asp:ListItem Value="mx" Text="Mexico" />
                                <asp:ListItem Value="md" Text="Moldova" />
                                <asp:ListItem Value="mc" Text="Monaco" />
                                <asp:ListItem Value="mn" Text="Mongolia" />
                                <asp:ListItem Value="me" Text="Montenegro" />
                                <asp:ListItem Value="ms" Text="Montserrat" />
                                <asp:ListItem Value="ma" Text="Morocco" />
                                <asp:ListItem Value="mz" Text="Mozambique" />
                                <asp:ListItem Value="mm" Text="Myanmar" />
                                <asp:ListItem Value="us" Text="Mỹ" />
                                <asp:ListItem Value="no" Text="Na-uy" />
                                <asp:ListItem Value="za" Text="Nam Phi" />
                                <asp:ListItem Value="na" Text="Namibia" />
                                <asp:ListItem Value="nr" Text="Nauru" />
                                <asp:ListItem Value="np" Text="Nepal" />
                                <asp:ListItem Value="an" Text="Netherlands Antilles" />
                                <asp:ListItem Value="nc" Text="New Caledonia" />
                                <asp:ListItem Value="nz" Text="New Zealand" />
                                <asp:ListItem Value="ru" Text="Nga" />
                                <asp:ListItem Value="jp" Text="Nhật" />
                                <asp:ListItem Value="ni" Text="Nicaragua" />
                                <asp:ListItem Value="ne" Text="Niger" />
                                <asp:ListItem Value="ng" Text="Nigeria" />
                                <asp:ListItem Value="nu" Text="Niue" />
                                <asp:ListItem Value="om" Text="Oman" />
                                <asp:ListItem Value="pk" Text="Pakistan" />
                                <asp:ListItem Value="pw" Text="Palau" />
                                <asp:ListItem Value="pa" Text="Panama" />
                                <asp:ListItem Value="pg" Text="Papua New Guinea" />
                                <asp:ListItem Value="py" Text="Paraguay" />
                                <asp:ListItem Value="pe" Text="Peru" />
                                <asp:ListItem Value="ph" Text="Philippines" />
                                <asp:ListItem Value="fr" Text="Pháp" />
                                <asp:ListItem Value="fi" Text="Phần Lan" />
                                <asp:ListItem Value="pr" Text="Puerto Rico" />
                                <asp:ListItem Value="qa" Text="Qatar" />
                                <asp:ListItem Value="ax" Text="Quần đảo Aland" />
                                <asp:ListItem Value="mp" Text="Quần đảo Bắc Mariana" />
                                <asp:ListItem Value="ky" Text="Quần đảo Cayman" />
                                <asp:ListItem Value="cc" Text="Quần đảo Cocos (Keeling)" />
                                <asp:ListItem Value="ck" Text="Quần đảo Cook" />
                                <asp:ListItem Value="fk" Text="Quần đảo Falkland" />
                                <asp:ListItem Value="fo" Text="Quần đảo Faroe" />
                                <asp:ListItem Value="mh" Text="Quần đảo Marshall" />
                                <asp:ListItem Value="gs" Text="Quần đảo Nam Georgia và Nam Sandwich" />
                                <asp:ListItem Value="pn" Text="Quần đảo Pitcairn" />
                                <asp:ListItem Value="sb" Text="Quần đảo Solomon" />
                                <asp:ListItem Value="pi" Text="Quần đảo Spratly" />
                                <asp:ListItem Value="tc" Text="Quần đảo Turks và Caicos" />
                                <asp:ListItem Value="vg" Text="Quần đảo Virgin thuộc Anh" />
                                <asp:ListItem Value="vi" Text="Quần đảo Virgin thuộc Mỹ" />
                                <asp:ListItem Value="re" Text="Reunion" />
                                <asp:ListItem Value="ro" Text="Rumani" />
                                <asp:ListItem Value="rw" Text="Rwanda" />
                                <asp:ListItem Value="sh" Text="Saint Helena và Dependencies" />
                                <asp:ListItem Value="kn" Text="Saint Kitts và Nevis" />
                                <asp:ListItem Value="lc" Text="Saint Lucia" />
                                <asp:ListItem Value="pm" Text="Saint Pierre và Miquelon" />
                                <asp:ListItem Value="vc" Text="Saint Vincent và The Grenadines" />
                                <asp:ListItem Value="ws" Text="Samoa" />
                                <asp:ListItem Value="sm" Text="San Marino" />
                                <asp:ListItem Value="st" Text="Sao Tome và Principe" />
                                <asp:ListItem Value="sn" Text="Senegal" />
                                <asp:ListItem Value="rs" Text="Serbia" />
                                <asp:ListItem Value="sc" Text="Seychelles" />
                                <asp:ListItem Value="sl" Text="Sierra Leone" />
                                <asp:ListItem Value="sg" Text="Singapore" />
                                <asp:ListItem Value="sk" Text="Slovakia" />
                                <asp:ListItem Value="si" Text="Slovenia" />
                                <asp:ListItem Value="so" Text="Somalia" />
                                <asp:ListItem Value="lk" Text="Sri Lanka" />
                                <asp:ListItem Value="sd" Text="Sudan" />
                                <asp:ListItem Value="sr" Text="Suriname" />
                                <asp:ListItem Value="sj" Text="Svalbard và Jan Mayen" />
                                <asp:ListItem Value="sz" Text="Swaziland" />
                                <asp:ListItem Value="sy" Text="Syria" />
                                <asp:ListItem Value="tj" Text="Tajikistan" />
                                <asp:ListItem Value="tz" Text="Tanzania" />
                                <asp:ListItem Value="va" Text="Thành phố Vatican" />
                                <asp:ListItem Value="th" Text="Thái Lan" />
                                <asp:ListItem Value="tr" Text="Thổ Nhĩ Kỳ" />
                                <asp:ListItem Value="ch" Text="Thụy Sĩ" />
                                <asp:ListItem Value="se" Text="Thụy Điển" />
                                <asp:ListItem Value="tg" Text="Togo" />
                                <asp:ListItem Value="tk" Text="Tokelau" />
                                <asp:ListItem Value="to" Text="Tonga" />
                                <asp:ListItem Value="tt" Text="Trinidad và Tobago" />
                                <asp:ListItem Value="cn" Text="Trung Quốc" />
                                <asp:ListItem Value="tn" Text="Tunisia" />
                                <asp:ListItem Value="tm" Text="Turkmenistan" />
                                <asp:ListItem Value="tv" Text="Tuvalu" />
                                <asp:ListItem Value="es" Text="Tây Ban Nha" />
                                <asp:ListItem Value="eh" Text="Tây Sahara" />
                                <asp:ListItem Value="ug" Text="Uganda" />
                                <asp:ListItem Value="ua" Text="Ukraine" />
                                <asp:ListItem Value="uy" Text="Uruguay" />
                                <asp:ListItem Value="uz" Text="Uzbekistan" />
                                <asp:ListItem Value="vu" Text="Vanuatu" />
                                <asp:ListItem Value="ve" Text="Venezuela" />
                                <asp:ListItem Value="vn" Text="Việt Nam" />
                                <asp:ListItem Value="tf" Text="Vùng lãnh thổ phía Nam của Pháp" />
                                <asp:ListItem Value="wf" Text="Wallis và Futuna" />
                                <asp:ListItem Value="ye" Text="Yemen" />
                                <asp:ListItem Value="zm" Text="Zambia" />
                                <asp:ListItem Value="zw" Text="Zimbabwe" />
                                <asp:ListItem Value="dk" Text="Đan Mạch" />
                                <asp:ListItem Value="tw" Text="Đài Loan" />
                                <asp:ListItem Value="tl" Text="Đông Timor" />
                                <asp:ListItem Value="bv" Text="Đảo Bouvet" />
                                <asp:ListItem Value="cx" Text="Đảo Christmas" />
                                <asp:ListItem Value="hm" Text="Đảo Heard và Quần đảo Mcdonald" />
                                <asp:ListItem Value="nf" Text="Đảo Norfolk" />
                                <asp:ListItem Value="de" Text="Đức" />
                                <asp:ListItem Value="sa" Text="Ả Rập Saudi" />
                                <asp:ListItem Value="in" Text="Ấn Độ" />
                            </asp:DropDownList>
                        </li>                        
                        <li>
                            <asp:Label AssociatedControlID="txtEmail" Text="* Email:" Width="100" runat="server" />
                            <asp:TextBox ID="txtEmail" Width="352" CssClass="validate[required,custom[email]]" MaxLength="100" runat="server" />
                        </li>
                        <li>
                            <asp:Label AssociatedControlID="txtPhone" Text="Điện thoại:" Width="100" runat="server" />
                            <asp:TextBox ID="txtPhone" Width="352" CssClass="validate[custom[phone2]]" MaxLength="12" runat="server" />
                        </li>                        
                    </ul>
                </asp:WizardStep>
                <asp:WizardStep StepType="Complete" runat="server">
                    <h2>Hoàn tất đăng ký</h2>
                    <p>
                        Bạn đã đăng ký thành công. Xem hồ sơ của bạn
                        <asp:HyperLink NavigateUrl="~/account/guest/myprofile.aspx" Text="tại đây" runat="server" />.
                    </p>
                </asp:WizardStep>
            </WizardSteps>
            <StartNavigationTemplate>
                <asp:LinkButton Text="Tiếp tục" CssClass="button" style="margin-top:5px" runat="server"
                    OnClick="Start_Click" OnClientClick="return checkCreateAccountValidation()" />
            </StartNavigationTemplate>
            <FinishNavigationTemplate>
                <asp:LinkButton Text="Hoàn tất" CssClass="button" style="margin-top:5px" runat="server"
                    OnClick="Finish_Click" OnClientClick="return checkCreateProfileValidation()" />
            </FinishNavigationTemplate>
        </asp:Wizard>
    </div>
</asp:Content>

