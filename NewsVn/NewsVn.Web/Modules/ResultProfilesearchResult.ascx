<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResultProfilesearchResult.ascx.cs" Inherits="NewsVn.Web.Modules.ResultProfilesearchResult" %>

<script runat="server">
	protected void Page_Load(object sender, EventArgs args)
	{
        if (!IsPostBack)
        {
            this.LoadResultProfiles();
        }
	}

    protected void lvResultProfiles_DataBound(object sender, EventArgs e)
    {
        pagerResultProfilesContainer.Visible = pagerResultProfiles.PageSize < pagerResultProfiles.TotalRowCount;
    }

    protected void lvResultProfiles_PagePropertiesChanged(object sender, EventArgs e)
    {
        this.LoadResultProfiles();
    }
	
	private void LoadResultProfiles()
	{
		//Sample List used only for building layout
		//Replace with real data list
        var sampleList = new ArrayList();
        for (int i = 0; i < 205; i++) sampleList.Add(i.ToString());
		
		lvResultProfiles.DataSource = sampleList;
		lvResultProfiles.DataBind();
	}
</script>

<div class="portlet">
    <h2>
        <%= string.Format("{0:N0}", 205) %>
        Kết quả cho từ khóa
        <span>'dep trai'</span>
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
					<asp:Image ID="Image1" ImageUrl="~/resources/Profiles/no_photo.gif" AlternateText="Nickname" CssClass="left" Width="135px" Height="135px" runat="server" />
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
    <asp:Panel ID="pagerResultProfilesContainer" CssClass="data-pager" style="margin-top:10px;" runat="server">
        Trang:
        <asp:DataPager ID="pagerResultProfiles" PagedControlID="lvResultProfiles" PageSize="10" QueryStringField="page" runat="server">
            <Fields>
                <asp:NumericPagerField ButtonCount="15" ButtonType="Link" PreviousPageText="&laquo;" NextPageText="&raquo;" />
            </Fields>
        </asp:DataPager>
    </asp:Panel>
</div>