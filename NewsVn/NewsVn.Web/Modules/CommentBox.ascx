<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentBox.ascx.cs" Inherits="NewsVn.Web.Modules.CommentBox" %>

<%--<link href="<%= Page.ResolveUrl("~/styles/validation.css") %>" rel="stylesheet" type="text/css" />
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine.js") %>" type="text/javascript"></script>
<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.validationEngine-vi.js") %>" type="text/javascript"></script>--%>

<script type="text/javascript">
    $(function () {
        showCommentDialog();
        showCommentList(1, false);
        showSimpleCaptcha();

        $("#<%= ddlOrder.ClientID %>").change(function () {
            showCommentList(1, $(this).val());
        });

        $("#<%= btnReCaptcha.ClientID %>").click(function () {
            showSimpleCaptcha();
        });

        $("#<%= btnSend.ClientID %>").click(function () {
            sendComment(
                $("#<%= txtName.ClientID %>").val(),
                $("#<%= txtTitle.ClientID %>").val(),
                    $("#<%= txtEmail.ClientID %>").val(),
                $("#<%= txtComment.ClientID %>").val(),
                <%= PostID %>,
                $("#comment_box_captchaKey").val(),
                $("#<%= txtCaptchaAnswer.ClientID %>").val()
            );
        });
    });

    function showCommentDialog() {        
        var dataObj = { postID: <%= PostID %> }        
        $.ajax({
            url: serviceUrl + "GetCommentDialogTitle",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
            success: function (result) {
                $("#comment_box").attr("title", result.d);                
            }, complete: function() {
                $("#comment_box").dialog({
                    autoOpen: false,
                    resizable: false,
                    modal: true,
                    width: 900
                });                
                $("#comment_box .comment-list ul").height($(window).height() - 150);
                $(".comment-button, .comment-link").click(function () {
                    $("#comment_box").dialog("open");
                });
            }
        });
    }

    function showCommentList(pageIndex, oldestOnTop) {        
        var dataObj = {
            postID: <%= PostID %>,
            pageIndex: pageIndex,
            pageSize: <%= ListPageSize %>,
            oldestOnTop: oldestOnTop
        };        
        $.ajax({
            url: serviceUrl + "LoadCommentList",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
            success: function (result) {
                $("#comment_box_list").html(result.d);
                $("#comment_box .comment-list li:first-child").addClass("head");
                showCommentPager(pageIndex);
            }
        });
    }

    function showCommentPager(pageIndex) {        
        var dataObj = {
            postID: <%= PostID %>,
            pageIndex: pageIndex,
            pageSize: <%= ListPageSize %>
        };
        $.ajax({
            url: serviceUrl + "GeneratePagerContent",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
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

    function showSimpleCaptcha() {
        var key = $("#comment_box_captchaKey").val();
        if(key == undefined) key = "";

        var dataObj = { omitKey: key };
        
        $.ajax({
            url: serviceUrl + "GenerateFormCaptcha",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
            success: function (result) {                
                $("#comment_box_captcha").html(result.d);
            }
        });
    }

    function sendComment(updatedBy, title, email, content, postID, captchaKey, captchaAnswer) {
        var dataObj = {
            comment: {
                UpdatedBy: updatedBy,
                Title: title,
                Email: email,
                Content: content
            },
            postID: postID,
            captchaKey: captchaKey,
            captchaAnswer: captchaAnswer
        }
        $.ajax({
            url: serviceUrl + "InsertComment",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
            success: function (result) {                
                if (result.d == "OK") {
                    $("#comment_box").dialog("close");
                } else {
                    $("#comment_box > ul").append("<li>" + result.d + "</li>");
                }
            },
            complete: function() {
                showSimpleCaptcha();
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
        $("#<%= txtComment.ClientID %>").maxlength({ maxCharacters: 1000, status: false, showAlert: true });
    });    
</script>
<div id="comment_box" style="display: none">
    <ul class="ui-form ui-widget left">
        <li><b>Bình luận của bạn:</b> </li>
        <li>
            <asp:Label AssociatedControlID="txtName" Text="Họ tên:" runat="server" />
            <asp:TextBox ID="txtName" CssClass="validate[required]" MaxLength="50" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtEmail" Text="Email" runat="server" />
            <asp:TextBox ID="txtEmail" CssClass="validate[required,custom[email]]" MaxLength="100"
                runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" runat="server" />
            <asp:TextBox ID="txtTitle" CssClass="validate[required]" MaxLength="50" runat="server" />
        </li>
        <li>
            <asp:Label AssociatedControlID="txtComment" Text="Nội dung:" CssClass="forarea" runat="server" />
            <asp:TextBox ID="txtComment" CssClass="validate[required]" TextMode="MultiLine" Rows="8" runat="server" />
        </li>
        <li>
            <label for="comment_box_captcha" class="left">
                Captcha:</label>
            <div id="comment_box_captcha" class="left">
            </div>
            <asp:Button ID="btnReCaptcha" Text="Khác" CssClass="button right" runat="server" />
            <div class="clear"></div>
        </li>
        <li>
            <asp:Label AssociatedControlID="txtCaptchaAnswer" Text="Trả lời:" runat="server" />
            <asp:TextBox ID="txtCaptchaAnswer" CssClass="validate[required]" MaxLength="20" runat="server" />
        </li>
        <li class="command">
            <asp:HyperLink ID="btnSend" Text="Gởi bình luận" CssClass="button right" runat="server" />
            <div class="clear"></div>
        </li>
    </ul>
    <div class="comment-list right">
        <div class="list-command">
            <div id="comment_box_pager" class="data-pager left">
            </div>
            <div class="right">
                Sắp xếp theo:
                <asp:DropDownList ID="ddlOrder" runat="server">
                    <asp:ListItem Value="false" Text="Mới nhất" />
                    <asp:ListItem Value="true" Text="Cũ nhất" />
                </asp:DropDownList>
            </div>
            <div class="clear"></div>
        </div>
        <ul id="comment_box_list">
        </ul>
    </div>
    <div class="clear"></div>
</div>
