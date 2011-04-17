<%@ Control Language="C#" ClassName="UserProfileList" %>

<script runat="server">
	protected void Page_Load(object sender, EventArgs args)
	{
        if (!IsPostBack)
        {
            this.LoadUserProfiles();
        }
	}

    protected void lvProfiles_DataBound(object sender, EventArgs e)
    {
        pagerProfilesContainer.Visible = pagerProfiles.PageSize < pagerProfiles.TotalRowCount;
    }

    protected void lvProfiles_PagePropertiesChanged(object sender, EventArgs e)
    {
        this.LoadUserProfiles();
    }
	
	private void LoadUserProfiles()
	{
		//Sample List used only for building layout
		//Replace with real data list
        var sampleList = new ArrayList();
        for (int i = 0; i < 205; i++) sampleList.Add(i.ToString());
		
		lvProfiles.DataSource = sampleList;
		lvProfiles.DataBind();
	}
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
					<asp:Image ImageUrl="~/resources/profiles/no_photo.gif" AlternateText="Nickname" CssClass="left" Width="135px" Height="135px" runat="server" />
					<div class="right" style="width:500px;">
                        <span class="post-comment">29</span>
                        <b>Tên:</b> Họ và tên<br />
                        <b>Biệt danh:</b> nickname<br />
                        <b>Giới tính/Tuổi:</b> Nam/30<br />
                        <b>Chỗ ở:</b> Long An, Việt Nam<br/>
						<b>Chi tiết:</b> <a href="../profile.aspx">Xem hồ sơ</a>
                        <p>
                            <b>Muốn tìm:</b>
                            Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta.
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