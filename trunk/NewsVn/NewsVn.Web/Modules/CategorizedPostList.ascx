﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategorizedPostList.ascx.cs" Inherits="NewsVn.Web.Modules.CategorizedPostList" %>

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
                   <% if (NoComments){ %> <span class="post-comment"><%#Eval("Comments") %></span><% } %>
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
        <asp:LinkButton runat="server" ID="lnkbtnPrevious" CssClass="button" 
            onclick="lnkbtnPrevious_Click">&laquo; Bài cũ hơn</asp:LinkButton>
        <asp:LinkButton runat="server" ID="lnkbtnNext" CssClass="button" 
            onclick="lnkbtnNext_Click">Bài mới hơn &raquo;</asp:LinkButton>
        <%--<a href="#" class="button">&laquo; Bài cũ hơn</a>
        <a href="#" class="button">Bài mới hơn &raquo;</a>--%>
    </div>
    <asp:Button runat="server" ID="btnView" CssClass="button right"  
        style="margin:0.5px 0 0 5px;" Text="Xem" onclick="btnView_Click" />&nbsp;
    <div class="textbox-icon right">
        <asp:TextBox ID="txtGoldDate" CssClass="datepicker" style="width:150px" runat="server" />
    </div>
    <div class="clear"></div>
</div>