<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AutoFetchPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.AutoFetchPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .portlet {background:none;margin-top:20px}
        .portlet a {color:#104687}
        .portlet .post-title {display:block;font-weight:700;text-align:justify}
        .portlet .post-title.inline {display:inline}
        .portlet .post-info {font-size:10px;font-style:italic}
        .post-item-list li {border-bottom:1px dotted #333;padding:7px 0;position:relative}
        .post-item-list li.head {padding:0 0 7px}
        .post-item-list .post-avatar {height:110px;margin-right:20px;width:130px}
        .msg-bar li { margin-bottom:5px }
        #postHelpBox a { color:#104687 !important }
        #topContent { position:fixed;background:#fff;z-index:1000;padding-top:10px;top:0 }
        #bottomContent { margin-top:50px }
    </style>
    <script type="text/javascript">
        $(function () {
            adjustTopBottomContent();
            adjustPostItemWidth();
            $(window).resize(function () {
                adjustTopBottomContent();
                adjustPostItemWidth();
            });
            $(".post-item-list li:last").css({ "border": "none" });
            bindCheckBoxEvts();
        });
        function bindCheckBoxEvts() {
            $(":checkbox").removeAttr("checked");
            var allCheckbox = $(":checkbox[id$=chkAll]");
            var childCheckboxes = $(":checkbox[id$=chkAccept]");
            allCheckbox.change(function () {
                var checked = $(this).attr("checked");
                if (checked) {
                    childCheckboxes.attr("checked", true);
                }
                else {
                    childCheckboxes.removeAttr("checked");
                }
            });
            childCheckboxes.change(function () {
                var count = childCheckboxes.size();
                var checkedCount = childCheckboxes.filter(":checked").size();
                if (checkedCount == count) {
                    allCheckbox.attr("checked", true);
                }
                else {
                    allCheckbox.removeAttr("checked");
                }
            });
        }
        function adjustTopBottomContent() {
            $("#topContent").css({ "width": ($(window).width() - $("#side_content").width() - 30) + "px" });
            $("#bottomContent").css({ "margin-top": $("#topContent").height() + 5 + "px" });
        }
        function adjustPostItemWidth() {
            $(".post-item-list .post-item").each(function () {
                $(this).css({"width": $(".portlet").width() - $(this).next("img").width() - 70 + "px" })
            });
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div id="postHelpBox" class="dialog" title="Trợ giúp">
        Chọn website và danh mục từ danh sách, chọn <b>Lấy tin</b><br />
        Check các checkbox để chọn tin cần cập nhật<br />
        Nhấn nút <b>Cập nhật</b> để thêm vào <b><asp:HyperLink NavigateUrl="~/account/siteadmin/post/viewpost.aspx" Text="Quản lý tin tức" runat="server" /></b><br />        
        Chuyển qua phần <b><asp:HyperLink NavigateUrl="~/account/siteadmin/post/viewpost.aspx" Text="Quản lý tin tức" runat="server" /></b>, sẽ thấy các tin vừa thêm ở dạng chưa duyệt<br />
        Chọn và duyệt các tin này để Publish ra bên ngoài<br />
        <b>Đối với lấy tin tự động:</b><br />
        Chọn <b>Bật</b> để mở chế độ tự động lấy tin tức<br />
        Chọn <b>Tắt</b> để tắt chế độ lấy tin tự động<br />
        <b>Thời gian lấy tin tự động:</b><br />
        Mặc định: 6h/lần<br />
        Đang thiết lập: <asp:Label runat="server" ID="lblCurrentSetting" Text="" />h/lần
    </div>
    <div id="topContent">
        <div>
            <div class="right">
                <asp:DropDownList ID="ddlFetchSite" CssClass="dropdown" runat="server" 
                    AutoPostBack="true" OnSelectedIndexChanged="ddlFetchSite_SelectedIndexChanged" />
                <asp:DropDownList ID="ddlFetchCategory" CssClass="dropdown" runat="server" 
                    AutoPostBack="true" OnSelectedIndexChanged="ddlFetchCategory_SelectedIndexChanged" />
                <asp:LinkButton ID="btnGetPostList" Text="Lấy tin" CssClass="button" 
                    runat="server" OnClick="btnGetPostList_Click" />
            </div>
            <div class="left">
                <asp:LinkButton ID="btnAddPostItems" Text="Cập nhật" CssClass="button" 
                    runat="server" OnClick="btnAddPostItems_Click" />
                <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[postHelpBox]" runat="server" />
                <span>Lấy tin tự động: </span>
                 <asp:LinkButton ID="lnkbtnAutoMode" Text="Bật" Visible="false" CssClass="button" 
                    runat="server" onclick="lnkbtnAutoMode_Click" />
                    <asp:LinkButton ID="lnkbtnOffAutoMode" Visible="false" Text="Tắt" CssClass="button" 
                    runat="server" onclick="lnkbtnOffAutoMode_Click" />
            </div>
            <div class="clear"></div>
        </div>
        <hr />
        <ul class="msg-bar">
            <asp:Literal ID="ltrError" EnableViewState="false" runat="server" />
            <asp:Literal ID="ltrInfo" EnableViewState="false" runat="server" />
        </ul>
    </div>
    <div id="bottomContent">        
        <asp:Repeater ID="rptPostList" runat="server" OnItemDataBound="rptPostList_ItemDataBound">
        <HeaderTemplate>
            <div class="ui-widget-header" style="padding:5px 15px">
                <asp:CheckBox ID="chkAll" EnableViewState="false" runat="server" style="margin-right:25px" />
                <asp:Literal ID="ltrListName" runat="server" />
            </div>
            <div class="portlet" style="margin-top:0;border-top:0;padding-top:10px">            
                <ul class="post-item-list">
        </HeaderTemplate>
        <ItemTemplate>
            <li>                    
                <div class="left">
                    <asp:CheckBox ID="chkAccept" EnableViewState="false" runat="server" />
                    <asp:HiddenField ID="hidGetUrl" Value='<%#Eval("Url") %>' runat="server" />
                    <asp:HiddenField ID="hidAvatar" Value='<%# Eval("Avatar") %>' runat="server" />
                </div>
                <div class="post-item right">                       
                    <div class="wrap">
                        <a href='<%#Eval("Url") %>' class="post-title inline"><%#Eval("Title") %></a>
                        <span class="post-info"><%#string.Format("{0:dddd, dd/MM/yyyy HH:MM}",Eval("PubDate")) %></span>
                    </div>            
                    <p><%#Eval("Description") %></p>
                    <br />
                    <i>Danh mục:</i> <asp:DropDownList ID="ddlTargetCategory" CssClass="dropdown" runat="server" />
                </div>
                <asp:Image ID="imgAvatar" ImageUrl='<%# Eval("Avatar") %>'
                    AlternateText='<%#Eval("Title") %>' ToolTip='<%#Eval("Title") %>'
                    CssClass="post-avatar right" Width="130" Height="110" runat="server" />
                <div class="clear"></div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
                </ul>
            </div>
        </FooterTemplate>
        </asp:Repeater>
    </div>    
</asp:Content>