<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileSearchBox.ascx.cs" Inherits="NewsVn.Web.Modules.ProfileSearchBox" %>


<script type="text/javascript">
    $(function () {
        var selector = "#<%= ddlAvatarAvailable.ClientID %>, #<%= ddlMaritalStatus.ClientID %>,"
            + "#<%= ddlEducation.ClientID %>, #<%= ddlReligion.ClientID %>, #<%= ddlCountry.ClientID %>, #<%= ddlLocation.ClientID %>";
        $(selector).selectmenu({ width: "274px" });
        $(selector).each(function () {
            $("#" + $(this).attr("id") + "-menu").width(280);
        });
        $("#<%= ddlCountry.ClientID %>-button .ui-selectmenu-icon").click(function () {
            $("#<%= ddlCountry.ClientID %>-menu").css({ "zIndex": 100 });
        });

        $("#<%= ddlLocation.ClientID %>-button .ui-selectmenu-icon").click(function () {
            $("#<%= ddlLocation.ClientID %>-menu").css({ "zIndex": 100 });
        });

        selector = "#<%= ddlGender.ClientID %>, #<%= ddlSmoke.ClientID %>, #<%= ddlDrink.ClientID %>";
        $(selector).selectmenu({ width: "130px" });
        $(selector).each(function () {
            $("#" + $(this).attr("id") + "-menu").width(136);
        });

        selector = "#<%= ddlFromAge.ClientID %>, #<%= ddlToAge.ClientID %>";
        $(selector).selectmenu({ width: "59px" });
        $(selector).each(function () {
            $("#" + $(this).attr("id") + "-menu").width(65);
        });

        $(".profile-search select").next(".ui-selectmenu").addClass("select");
        $(".profile-search select").next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");

        $(".dialog").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            width: 245, height: 100
        });
    });

    function openLoginConfirm() {
        $("#confirmBox").dialog("open");
        return false;
    }
</script>

<div class="side-part profile-search portlet">
    <h2>Tìm kiếm</h2>
    <ul class="ui-form ui-widget">
        <li class="head">
            <p style="margin-top:0">Tên:</p>
            <asp:TextBox ID="txtName" runat="server" />
        </li>
        <li>
            <p style="margin-top:0">
                <span>Giới tính:</span>
                <span style="margin-left:88px">Tuổi từ:</span>
                <span style="margin-left:20px"> Đến:</span>
            </p>
            <asp:DropDownList ID="ddlGender" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ddlFromAge" runat="server" />
            <asp:DropDownList ID="ddlToAge" runat="server" />
        </li>
        <li>
            <p style="margin-top:0">Hình đại diện:</p>
            <asp:DropDownList ID="ddlAvatarAvailable" runat="server">                
            </asp:DropDownList>
        </li>
        <li>
            <p style="margin-top:0">Tình trạng hôn nhân:</p>
            <asp:DropDownList ID="ddlMaritalStatus" runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <p style="margin-top:0">Học vấn:</p>
            <asp:DropDownList ID="ddlEducation" runat="server">                
            </asp:DropDownList>
        </li>
        <li>
            <p style="margin-top:0">Tôn giáo:</p>
            <asp:DropDownList ID="ddlReligion" runat="server">
            </asp:DropDownList>
        </li>
        <li>
            <p style="margin-top:0">
                <span>Hút thuốc:</span>
                <span style="margin-left:80px">Uống rượu:</span>
            </p>
            <asp:DropDownList ID="ddlSmoke" runat="server">                
            </asp:DropDownList>
            <asp:DropDownList ID="ddlDrink" runat="server">                
            </asp:DropDownList>
        </li>
        
        <li>
            <p style="margin-top:0">Quốc gia:</p>
            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlCountry_SelectedIndexChanged">                
            </asp:DropDownList>
        </li>
        <li>
            <p style="margin-top:0">Tỉnh/Thành phố:</p>
            <asp:DropDownList ID="ddlLocation" runat="server">
                <asp:ListItem>Tất cả</asp:ListItem>
            </asp:DropDownList>
        </li>
        <li class="commands">
            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                    <div id="confirmBox" class="dialog" title="Bạn chưa đăng nhập">
                        <br />
                        <a href='<%= HostName+ "tai-khoan/dang-nhap.aspx" %>' class="button-login">Đăng nhập</a>
                        <a href='<%= HostName+ "tai-khoan/dang-ky.aspx" %>' class="button-register" style="margin-left:4px">Đăng ký</a>
                    </div>
                    <asp:LinkButton ID="LinkButton1" Text="Hồ sơ của tôi" CssClass="button left" runat="server"
                        OnClientClick="return openLoginConfirm()" />
                </AnonymousTemplate>
                <RoleGroups>
                    <asp:RoleGroup Roles="Guest">
                        <ContentTemplate>
                            <asp:HyperLink ID="HyperLink3" Text="Hồ sơ của tôi" NavigateUrl="#" CssClass="button left" runat="server" />
                        </ContentTemplate>                        
                    </asp:RoleGroup>
                </RoleGroups>
            </asp:LoginView>
            <asp:LinkButton ID="btnSearch" Text="Tìm" CssClass="button-search right" 
                style="margin-right:-2px;" runat="server"
                onclick="btnSearch_Click" />
            <div class="clear"></div>
        </li>
    </ul>
</div>