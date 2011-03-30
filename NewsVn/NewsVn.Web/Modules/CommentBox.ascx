<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommentBox.ascx.cs" Inherits="NewsVn.Web.Modules.CommentBox" %>

<script type="text/javascript">
    $(function () {
        $("#comment_box").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            width: 900
        });
        $("#comment_box .comment-list li:first-child").addClass("head");
        var selectorID = "#<%= ddlOrder.ClientID %>";
        var linkSelector = $(selectorID);
        linkSelector.selectmenu({ width: "84px" });
        linkSelector.next(".ui-selectmenu").addClass("select");
        linkSelector.next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $(selectorID + "-menu").width(90);
    });
</script>

<script type="text/javascript">
    $(function () {
        showCommentList(15, 1);
        showCommentPager(15);
    });

    function showTestString() {
        $.ajax({
            url: serviceUrl + "HelloWorld",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{}",
            success: function (result) {
                alert(result.d);
            }
        });
    }

    function showCommentList(postID, pageIndex) {
        $.ajax({
            url: serviceUrl + "LoadCommentList",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{'postID':" + postID + ",'pageIndex':" + pageIndex + ",'pageSize':1}",
            success: function (result) {
                $("#comment_box_list").html(result.d);                
            }
        });
    }

    function showCommentPager(postID) {
        $.ajax({
            url: serviceUrl + "GeneratePagerContent",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{'postID':" + postID + ",'pageSize':1}",
            success: function (result) {
                $("#comment_box_pager").html(result.d);
                $("#comment_box_pager a").each(function () {
                    $(this).click(function () {
                        showCommentList(15, $(this).text());
                    });
                });
            }
        });        
    }

</script>

<div id="comment_box" title="Bình luận: Hot girl “siêu hot” đến từ Hàn Quốc bên xế khủng (47)">        
    <ul class="ui-form ui-widget left">
        <li>
            <b>Bình luận của bạn:</b>
        </li>
        <li>
            <asp:Label ID="Label1" AssociatedControlID="txtName" Text="Họ tên:" runat="server" />
            <asp:TextBox ID="txtName" runat="server" />
        </li>
        <li>
            <asp:Label ID="Label2" AssociatedControlID="txtEmail" Text="Email" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" />
        </li>
        <li>
            <asp:Label ID="Label3" AssociatedControlID="txtTitle" Text="Tiêu đề:" runat="server" />
            <asp:TextBox ID="txtTitle" runat="server" />
        </li>
        <li>
            <asp:Label ID="Label4" AssociatedControlID="txtComment" Text="Nội dung:" CssClass="forarea" runat="server" />
            <asp:TextBox ID="txtComment" TextMode="MultiLine" Rows="8" runat="server" />
        </li>
        <li class="command">
            <input type="button" onclick="showTestString();" value="Goi" />
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
                    <asp:ListItem Value="desc" Text="Mới nhất" />
                    <asp:ListItem Value="asc" Text="Cũ nhất" />
                </asp:DropDownList>
            </div>
            <div class="clear"></div>
        </div>
        <ul id="comment_box_list">
            
        </ul>
    </div>
    <div class="clear"></div>
</div>