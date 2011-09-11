<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdSearchResult.ascx.cs" Inherits="NewsVn.Web.Modules.AdSearchResult" %>
<script runat="server" >
</script>
<div class="portlet">
    <h2> Kết quả tìm kiếm rao vặt</h2>
    <ul class="post-item-list">
    <asp:ListView ID="lvAdResult" runat="server" EnableModelValidation="True" 
        ondatabound="lvAdResult_DataBound" 
        onpagepropertieschanged="lvAdResult_PagePropertiesChanged">
        <LayoutTemplate>
				<asp:Panel ID="itemPlaceHolder" runat="server" />
		</LayoutTemplate>
        <ItemTemplate>
        <li>
            <asp:Image ImageUrl='<%#Eval("Avatar")%>' AlternateText='<%#Eval("Title") %>' CssClass="left" Width="135px" Height="135px" runat="server" />
                <div class="post-item left">
                    <a href='<%#Eval("SeoUrl") %>' class="post-title"><%#Eval("Title") %></a>
                    <p>
                        <%#NewsVn.Web.Utils.clsCommon.hintDesc(Eval("Content").ToString(),300)%>
                    </p>
                    <span class="post-info">
                        <%# Eval("CreatedOn", "{0:dddd, dd/MM/yyyy, HH:mm})" ) %> |
                        Khu vực: <b><%#NewsVn.Web.Utils.clsCommon.getLocationName(int.Parse(Eval("Location").ToString()))%></b> |
                        Đăng bởi: <b><%#Eval("CreatedBy")%></b>
                    </span>
                </div>
                <div class="clear"></div>
                </li>
		</ItemTemplate>
    </asp:ListView>
    </ul>
       
    <asp:Panel ID="pnPagerAdContainer" runat="server" CssClass="data-pager" style="margin-top:10px;">
    Trang: 
    <asp:DataPager ID="dpAdResult" PagedControlID="lvAdResult" PageSize="10" QueryStringField="page" runat="server">
            <Fields>
                <asp:NumericPagerField ButtonCount="15" ButtonType="Link" PreviousPageText="&laquo;" NextPageText="&raquo;" />
            </Fields>
    </asp:DataPager>
    </asp:Panel>
</div>



