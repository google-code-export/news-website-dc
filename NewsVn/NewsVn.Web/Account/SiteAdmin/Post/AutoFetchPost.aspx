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
    </style>
    <script type="text/javascript">
        $(function () {
            adjustPostItemWidth();
            $(window).resize(function () {
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
        function adjustPostItemWidth() {
            $(".post-item-list .post-item").each(function () {
                $(this).css({"width": $(".portlet").width() - $(this).next("img").width() - 70 + "px" })
            });
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div id="postHelpBox" class="dialog" title="Trợ giúp">
        
    </div>
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
        </div>
        <div class="clear"></div>
    </div>
    <hr />
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
    <ul>
        <asp:Literal ID="ltrInfo" EnableViewState="false" runat="server" />
    </ul>
</asp:Content>