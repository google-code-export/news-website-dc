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

 <div id="comment_box"  title='Bình luận: <%= PostTitle %> <%= string.Format("({0})",CommentNumbers.ToString()) %>'> 
    
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
                <asp:Button ID="Button1" Text="Gởi bình luận" CssClass="button right" 
                    runat="server" onclick="Button1_Click" />
                <div class="clear"></div>
            </li>
        </ul>
        <asp:UpdatePanel runat="server" ID="updatePanel1" ChildrenAsTriggers="true">
    <ContentTemplate>
        <div class="comment-list right">
            <div class="list-command">
                <div class="data-pager left">
                    <asp:Label runat="server" ID="lblTrang" Text="Trang" />
                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lsvComment" PageSize="2">
                        <Fields>
                           <asp:NumericPagerField ButtonType="Link" ButtonCount="10"/>
                        </Fields>
                    </asp:DataPager>
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
            <ul>
            <asp:ListView runat="server" ID="lsvComment"  GroupItemCount="1" ondatabound="lsvComment_DataBound" 
                    onpagepropertieschanged="lsvComment_PagePropertiesChanged">
                <LayoutTemplate>
                  <li>
                     <asp:PlaceHolder runat="server" ID="groupPlaceholder"></asp:PlaceHolder>
                  </li>
               </LayoutTemplate>
               <GroupTemplate>
                     <li>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>       
                    </li>
                </GroupTemplate>
               <ItemTemplate>
                    <b><asp:Label runat="server" ID="lblTitleComment" Text='<%#Eval("Title") %>'/> </b>
                    <p>
                        <asp:Literal runat="server" ID="ltrBodyComment" Text='<%#Eval("Content") %>' />
                    </p>
                    <i>(<asp:Label runat="server" ID="lblNameCreated" Text='<%#Eval("CreatedBy") %>'/>)</i>
               </ItemTemplate>
               <EmptyDataTemplate>
                    <b>
                        <span>Chưa có bình luận nào cho bài viết này</span>
                    </b>
                </EmptyDataTemplate>
            </asp:ListView>
            </ul>
        </div>
            </ContentTemplate>
</asp:UpdatePanel>
        <div class="clear"></div>

    </div>
