<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentBox.ascx.cs" Inherits="NewsVn.Web.Modules.CommentBox" %>

<script type="text/javascript">
    $(function () {
        showCommentDialog();
        showCommentList(1, false);

        $("#<%= ddlOrder.ClientID %>").change(function () {
            showCommentList(1, $(this).val());
        });

        $("#<%= btnSend.ClientID %>").click(function () {
            alert("Send!");
        });
    });

    function showCommentDialog() {
        $.ajax({
            url: serviceUrl + "GetCommentDialogTitle",
            data: "{'postID':<%= PostID %>}",
            success: function (result) {
                $("#comment_box").attr("title", result.d);
                $("#comment_box").dialog({
                    autoOpen: false,
                    resizable: false,
                    modal: true,
                    width: 900
                });
                $("#comment_box .comment-list li:first-child").addClass("head");
                $("#comment_box .comment-list ul").height($(window).height() - 150);
                $(".comment-button, .comment-link").click(function () {
                    $("#comment_box").dialog("open");
                });
            }
        });
    }

    function showCommentList(pageIndex, oldestOnTop) {
        $.ajax({
            url: serviceUrl + "LoadCommentList",
            data: "{'postID':<%= PostID %>,'pageIndex':" + pageIndex + ",'pageSize':<%= ListPageSize %>,'oldestOnTop':" + oldestOnTop + "}",
            success: function (result) {
                $("#comment_box_list").html(result.d);
                showCommentPager(pageIndex);
            }
        });
    }

    function showCommentPager(pageIndex) {
        $.ajax({
            url: serviceUrl + "GeneratePagerContent",
            data: "{'postID':<%= PostID %>,'pageIndex':" + pageIndex + ",'pageSize':<%= ListPageSize %>}",
            success: function (result) {
                $("#comment_box_pager").html(result.d);
                $("#comment_box_pager a").each(function () {
                    $(this).click(function () {
                        showCommentList($(this).text(), $("#<%= ddlOrder.ClientID %>").val());
                    });
                });
            }
        });
    }

    function showSimpleCaptcha(current) {
        $.ajax({
            url: serviceUrl + "GenerateFormCaptcha",
            data: "{'omitKey':" + current + "}",
            success: function (result) {

            }
        });
    }

</script>

<script type="text/javascript">
    $(function () {        
        var selectorID = "#<%= ddlOrder.ClientID %>";
        var linkSelector = $(selectorID);
        linkSelector.selectmenu({ width: "84px" });
        linkSelector.next(".ui-selectmenu").addClass("select");
        linkSelector.next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $(selectorID + "-menu").width(90);
    });
</script>

<div id="comment_box">        
    <ul class="ui-form ui-widget left">
        <li>
            <b>Bình luận của bạn:</b>
        </li>
        <li>
            <asp:Label AssociatedControlID="txtName" Text="Họ tên:" runat="server" />
            <asp:TextBox ID="txtName" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtEmail" Text="Email" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" runat="server" />
            <asp:TextBox ID="txtTitle" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtComment" Text="Nội dung:" CssClass="forarea" runat="server" />
            <asp:TextBox ID="txtComment" TextMode="MultiLine" Rows="8" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="lblCaptcha" Text="Captcha:" runat="server" />
            <asp:Label ID="lblCaptcha" runat="server" />
            <asp:Button ID="btnReCaptcha" Text="Khác" CssClass="button right" runat="server" />
            <div class="clear"></div>
        </li>
        <li>
            <asp:Label AssociatedControlID="txtCaptchaAnswer" Text="Trả lời:" runat="server" />
            <asp:TextBox ID="txtCaptchaAnswer" runat="server" />
        </li>
        <li class="command">
            <asp:Button ID="btnSend" Text="Gởi bình luận" CssClass="button right" runat="server" />
            <div class="clear"></div>
        </li>
    </ul>
    <div class="comment-list right">
        <div class="list-command">
            <div id="comment_box_pager" class="data-pager left"></div>
            <div class="right">
                Sắp xếp theo:
                <asp:DropDownList ID="ddlOrder" runat="server">
                    <asp:ListItem Value="false" Text="Mới nhất" />
                    <asp:ListItem Value="true" Text="Cũ nhất" />
                </asp:DropDownList>
            </div>
            <div class="clear"></div>
        </div>
        <ul id="comment_box_list"></ul>
    </div>
    <div class="clear"></div>
</div>