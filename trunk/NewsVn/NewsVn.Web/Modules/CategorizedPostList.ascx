<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategorizedPostList.ascx.cs" Inherits="NewsVn.Web.Modules.CategorizedPostList" %>

<script type="text/javascript">

    $(function () {
        $("#categorizedPosts li:first-child").addClass("head");
    });
</script>

<div id="categorizedPosts" class="portlet categorized-posts">
    <ul class="post-item-list">
       <asp:Repeater runat="server" ID="rptCatePostList" 
            onitemdatabound="rptCatePostList_ItemDataBound">
        <ItemTemplate>
            <li>
                <img src='<%#Eval("Avatar") %>' alt='<%#Eval("Title") %>' title='<%#Eval("Title") %>' class="post-avatar left" width="130px" />
                <div class="post-item right">
                    <span class="post-comment"><%#Eval("Comments") %></span>
                    <div class="wrap">
                        <a href="#" class="post-title inline"><%#Eval("Title") %></a> -
                        <span class="post-info"><%#string.Format("{0:dddd, dd/MM/yyyy}",Eval("ApprovedOn")) %></span>
                    </div>            
                    <p><%#Eval("Description") %></p>
                </div>
                <div class="clear"></div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            <div style="text-align:center; padding-top:6px;"><asp:Label runat="server" ID="lblEmpty" Visible="false" Text="Không tìm thấy bài viết"></asp:Label></div>
        </FooterTemplate>
       </asp:Repeater>
    </ul>
</div>
<div style="margin-top:20px;">
    <div class="left">
        <a href="#" class="button">&laquo; Bài cũ hơn</a>
        <a href="#" class="button">Bài mới hơn &raquo;</a>
    </div>
    <input class="button right" type="button" value="Xem" style="margin:0.5px 0 0 5px;" />&nbsp;
    <div class="textbox-icon right">
        <asp:TextBox ID="txtGoldDate" CssClass="datepicker" style="width:150px" runat="server" />
    </div>
    <div class="clear"></div>
</div>