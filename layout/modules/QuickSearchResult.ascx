<%@ Control Language="C#" ClassName="QuickSearchResult" %>

<script runat="server">
	protected void Page_Load(object sender, EventArgs args)
	{
        if (!IsPostBack)
        {
            this.LoadResultPosts();
        }
	}

    protected void lvResultPosts_DataBound(object sender, EventArgs e)
    {
        pagerResultPostsContainer.Visible = pagerResultPosts.PageSize < pagerResultPosts.TotalRowCount;
    }

    protected void lvResultPosts_PagePropertiesChanged(object sender, EventArgs e)
    {
        this.LoadResultPosts();
    }

    private void LoadResultPosts()
	{
		//Sample List used only for building layout
		//Replace with real data list
        var sampleList = new ArrayList();
        for (int i = 0; i < 1234; i++) sampleList.Add(i.ToString());

        lvResultPosts.DataSource = sampleList;
        lvResultPosts.DataBind();
	}
</script>

<div class="portlet">
    <h2>
        <%= string.Format("{0:N0}", 1234) %>
        Kết quả cho từ khóa
        <span>'abc'</span>
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
                    <asp:Image ImageUrl="~/resources/posts/t510695.jpg" AlternateText="Tiêu đề 1" ToolTip="Tiêu đề 1" CssClass="post-avatar left" Width="130px" runat="server" />
                    <div class="post-item right">
                        <span class="post-comment">29</span>
                        <div class="wrap">
                            <a href="#" class="post-title inline">Tiêu đề 1</a> -
                            <span class="post-info"><%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %></span>
                        </div>            
                        <p>Newsvn là tờ báo điện tử. mục đích đăng tải những thông tin mới về các vấn đề xã hội, giáo dục, thể thao, kinh tế đang diễn ra xung quanh ta đến với các độc giả. Là 1 trong những tờ báo điện tử của Việt Nam. Nên bố cục màu sắc của newsvn mang đậm màu sắc dân tộc. được thiết kế với những nền tảng công nghệ mới nhất</p>
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