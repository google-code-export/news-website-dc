<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserProfileList.ascx.cs" Inherits="NewsVn.Web.Modules.UserProfileList" %>

<script runat="server">
	
</script>

<div class="portlet">
    <h2>Danh sách tìm bạn</h2>
    <ul class="post-item-list">        
		<asp:ListView ID="lvProfiles" runat="server"
            OnDataBound="lvProfiles_DataBound"
            OnPagePropertiesChanged="lvProfiles_PagePropertiesChanged">
			<LayoutTemplate>
				<asp:Panel ID="itemPlaceHolder" runat="server" />
			</LayoutTemplate>
			<ItemTemplate>
				<li>
					<asp:Image ID="Image1" ImageUrl='<%#Eval("Avatar") %>' AlternateText='<%#Eval("Nickname") %>' CssClass="left" Width="135px" Height="135px" runat="server" />
					<div class="right" style="width:500px;">
                        <span class="post-comment">29</span>
                        <b>Tên:</b><%#Eval("Name") %><br />
                        <b>Biệt danh:</b> <%#Eval("Nickname") %><br />
                        <b>Giới tính/Tuổi:</b> <%#Eval("Gender") %>/<%#Eval("Age") %><br />
                        <b>Chỗ ở:</b> <%#Eval("Location") %>, <%#Eval("Country") %><br/>
						<b>Chi tiết:</b> <a href="../profile.aspx?acc=<%#Eval("Account") %>">Xem hồ sơ</a>
                        <p>
                            <b>Muốn tìm:</b>
                            <%#Eval("Expectation") %>
                        </p>
                    </div>
					<div class="clear"></div>
				</li>
			</ItemTemplate>
		</asp:ListView>
    </ul>
    <asp:Panel ID="pagerProfilesContainer" CssClass="data-pager" style="margin-top:10px;" runat="server">
        Trang:
        <asp:DataPager ID="pagerProfiles" PagedControlID="lvProfiles" PageSize="10" QueryStringField="page" runat="server">
            <Fields>
                <asp:NumericPagerField ButtonCount="15" ButtonType="Link" PreviousPageText="&laquo;" NextPageText="&raquo;" />
            </Fields>
        </asp:DataPager>
    </asp:Panel>
</div>