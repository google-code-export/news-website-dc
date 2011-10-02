<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResultProfilesearchResult.ascx.cs" Inherits="NewsVn.Web.Modules.ResultProfilesearchResult" %>

<div class="portlet">
    <h2>
        <%--<%= string.Format("{0:N0}", 205) %>--%>
        Kết quả tìm kiếm
        <%--<span>'dep trai'</span>--%>
    </h2>
    <ul class="post-item-list">        
		<asp:ListView ID="lvResultProfiles" runat="server"
            OnDataBound="lvResultProfiles_DataBound"
            OnPagePropertiesChanged="lvResultProfiles_PagePropertiesChanged">
			<LayoutTemplate>
				<asp:Panel ID="itemPlaceHolder" runat="server" />
			</LayoutTemplate>
			<ItemTemplate>
				<li>
					<asp:Image ID="Image1" ImageUrl='<%#Eval("Avatar")%>' AlternateText="Nickname" CssClass="left" Width="135px" Height="135px" runat="server" />
					<div class="right" style="width:500px;">
                        <span class="post-comment">'<%#Eval("profileCommentCount")%>'</span>
                        <b>Tên:</b>'<%#Eval("Name")%>'<br />
                        <b>Biệt danh:</b> '<%#Eval("Nickname")%>'<br />
                        <b>Giới tính/Tuổi:</b> '<%#Eval("Gender")%>'/'<%#Eval("Age")%>'<br />
                        <b>Chỗ ở:</b> '<%#Eval("Location")%>'<br/>
						<b>Chi tiết:</b> <a href="../tinh-yeu-gia-dinh/tim-ban/ho-so/<%#Eval("Account")%>.aspx">Xem hồ sơ</a>
                        <p>
                            <b>Muốn tìm:</b>
                            '<%#Eval("Expectation")%>'
                        </p>
                    </div>
					<div class="clear"></div>
				</li>
			</ItemTemplate>
		</asp:ListView>
    </ul>
    <asp:Panel ID="pagerResultProfilesContainer" CssClass="data-pager" style="margin-top:10px;" runat="server">
        Trang:
        <asp:DataPager ID="pagerResultProfiles" PagedControlID="lvResultProfiles" PageSize="10" QueryStringField="page" runat="server">
            <Fields>
                <asp:NumericPagerField ButtonCount="15" ButtonType="Link" PreviousPageText="&laquo;" NextPageText="&raquo;" />
            </Fields>
        </asp:DataPager>
    </asp:Panel>
</div>