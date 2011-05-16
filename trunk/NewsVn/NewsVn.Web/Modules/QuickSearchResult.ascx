<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuickSearchResult.ascx.cs" Inherits="NewsVn.Web.Modules.QuickSearchResult" %>

<div class="portlet">
    <h2>
        <%= string.Format("{0:N0}", ItemFounded)%>
        Kết quả cho từ khóa
        <span><i>'<%=keySearch%>'</i></span>
    </h2>
    <ul class="post-item-list">
        <asp:ListView ID="lvResultPosts" runat="server"
            OnDataBound="lvResultPosts_DataBound"
            OnPagePropertiesChanged="lvResultPosts_PagePropertiesChanged">
			<LayoutTemplate>
				<asp:Panel ID="itemPlaceHolder" runat="server" />
			</LayoutTemplate>
			<ItemTemplate>
                <li>
                    <asp:Image ID="Image1" ImageUrl='<%#Eval("Avatar") %>' AlternateText='<%#Eval("Title") %>' ToolTip='<%#Eval("Title") %>' CssClass="post-avatar left" Width="130px" runat="server" />
                    <div class="post-item right">
                        <span class="post-comment"><%#Eval("Comments") %></span>
                        <div class="wrap">
                            <a href='<%#Eval("SeoUrl") %>' class="post-title inline"><%#Eval("Title") %></a><br />
                            <span class="post-info"><%# string.Format("{0:dddd, dd/MM/yyyy HH:mm}", Eval("ApprovedOn")) %></span>
                        </div>            
                        <p><%#Eval("Description") %></p>
                    </div>
                    <div class="clear"></div>
                </li>
            </ItemTemplate>           
        </asp:ListView>
    </ul>
    <asp:Panel ID="pagerResultPostsContainer" CssClass="data-pager" style="margin-top:10px;" runat="server">
        Trang:
        <asp:DataPager ID="pagerResultPosts" PagedControlID="lvResultPosts" PageSize="15" QueryStringField="page" runat="server">
            <Fields>
                <asp:NumericPagerField ButtonCount="15" ButtonType="Link" PreviousPageText="&laquo;" NextPageText="&raquo;" />
            </Fields>
        </asp:DataPager>
    </asp:Panel>
</div>