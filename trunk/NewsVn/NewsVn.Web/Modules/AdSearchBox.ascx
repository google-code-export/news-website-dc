<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdSearchBox.ascx.cs"
    Inherits="NewsVn.Web.Modules.AdSearchBox" %>
<script type="text/javascript">
    $(function () {
        $("#divInforBar").attr("style", "display:none !important;");
        var initText = "Tìm rao vặt...";
        var searchInput = $("#<%= txtSearch.ClientID %>");
        initSearchInput(initText, searchInput);
        searchInput.focus(function () {
            if (searchInput.val() == initText) {
                searchInput.val("");
                searchInput.css({ "font-style": "normal" });
            }
        });
        searchInput.blur(function () {
            if ($.trim(searchInput.val()) == "") {
                initSearchInput(initText, searchInput);
            }
        });
        setGuiUIDropdownlist("#<%= ddlLocation.ClientID %>");
        setGuiUIDropdownlist("#<%= ddlFollowday.ClientID %>");


        $(".side-part .datepicker").datepicker("option", "dateFormat", "dd/mm/yy");
        var btnSearch = $("#<%= lnkbtnSearchAd.ClientID %>");
        btnSearch.click(function () {
            if (searchInput.val() == initText) {

                $("#divInforBar").attr("style", "padding: 0 .7em;");
                $("#spanInfoBar").text("Vui lòng nhập chuỗi tìm kiếm");
                return false;
            }
            else { $("#divInforBar").attr("style", "display:none !important;"); }
        })
    });
    function setGuiUIDropdownlist(controlID) {
        var selectorID =controlID;
        var linkSelector = $(selectorID);
        linkSelector.selectmenu({ width: "274px" });
        linkSelector.next(".ui-selectmenu").addClass("select");
        linkSelector.next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $(selectorID + "-menu").width(280);
    }
    function initSearchInput(initText, searchInput) {
        searchInput.val(initText);
        searchInput.css({ "font-style": "italic" });
    }
</script>
<div class="side-part adpost-search portlet">
    <h2>
        Tìm kiếm</h2>
    <asp:Panel ID="Panel1" DefaultButton="lnkbtnSearchAd" runat="server">
        <ul class="ui-form ui-widget">
            <li class="head">
                <asp:TextBox ID="txtSearch" CssClass="search-input" runat="server" />
            </li>
            <li>
                <asp:DropDownList ID="ddlLocation" runat="server">
                    <asp:ListItem Text="Toàn quốc" />
                    <asp:ListItem Text="Hà Nội" />
                    <asp:ListItem Text="Hồ Chí Minh" />
                    <asp:ListItem Text="Các tỉnh miền Bắc" />
                    <asp:ListItem Text="Các tỉnh miền Nam" />
                </asp:DropDownList>
            </li>
            <li>
                <p style="margin-top: 0">
                    Tìm trong khoảng thời gian:</p>
               <asp:DropDownList ID="ddlFollowday" runat="server">
                    <asp:ListItem Text="Hôm nay" Value="1" />
                    <asp:ListItem Text="3 ngày trước" Value="3"/>
                    <asp:ListItem Text="5 ngày trước" Value="5"/>
                    <asp:ListItem Text="7 tuần trước" Value="7"/>
                    <asp:ListItem Text="1 tháng trước" Value="30"/>
                    <asp:ListItem Text="3 tháng trước" Value="90"/>
                    <asp:ListItem Text="1 năm trước" Value="365"/>
                </asp:DropDownList>
            </li>
            <li>
            <asp:Label ID="ltrError" EnableViewState="false" runat="server" />
             
            </li>
            <li class="command"><a href='<%=HostName +"rao-nhanh-dang-ky.aspx" %>' class="button left">
                Đăng mới</a>
                <asp:LinkButton ID="lnkbtnSearchAd" Text="Tìm" CssClass="button-search right" Style="margin-right: 0;"
                    runat="server" OnClick="lnkbtnSearchAd_Click" />
                <div class="clear">
                </div>
            </li>
        </ul>
    </asp:Panel>
</div>
