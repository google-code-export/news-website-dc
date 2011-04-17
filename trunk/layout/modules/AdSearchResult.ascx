<%@ Control Language="C#" ClassName="AdSearchResult" %>

<script runat="server">
	protected void Page_Load(object sender, EventArgs args)
	{
        if (!IsPostBack)
        {
            this.LoadResultAdPosts();
        }
	}

    protected void lvResultAdPosts_DataBound(object sender, EventArgs e)
    {
        pagerResultAdPostsContainer.Visible = pagerResultAdPosts.PageSize < pagerResultAdPosts.TotalRowCount;
    }

    protected void lvResultAdPosts_PagePropertiesChanged(object sender, EventArgs e)
    {
        this.LoadResultAdPosts();
    }

    private void LoadResultAdPosts()
	{
		//Sample List used only for building layout
		//Replace with real data list
        var sampleList = new ArrayList();
        for (int i = 0; i < 205; i++) sampleList.Add(i.ToString());

        lvResultAdPosts.DataSource = sampleList;
        lvResultAdPosts.DataBind();
	}
</script>

<div class="portlet">
    <h2>
        <%= string.Format("{0:N0}", 205) %>
        Kết quả cho từ khóa
        <span>'rao vat'</span>
    </h2>
    <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th style="text-align:left;">Tin rao vặt</th>
            <th style="text-align:left;">Khu vực</th>
            <th style="text-align:left;">Ngày đăng</th>
        </tr>        
        <asp:ListView ID="lvResultAdPosts" runat="server"
            OnDataBound="lvResultAdPosts_DataBound"
            OnPagePropertiesChanged="lvResultAdPosts_PagePropertiesChanged">
		    <LayoutTemplate>
			    <asp:Panel ID="itemPlaceHolder" runat="server" />
		    </LayoutTemplate>
		    <ItemTemplate>
                <tr>
                    <td><a href="../adpost.aspx">Tin tìm kiếm</a></td>
                    <td style="width:120px;">Các tỉnh miền Nam</td>
                    <td style="width:80px;"><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
                </tr>
            </ItemTemplate>           
        </asp:ListView>
    </table>
    <asp:Panel ID="pagerResultAdPostsContainer" CssClass="data-pager" style="margin-top:10px;" runat="server">
        Trang:
        <asp:DataPager ID="pagerResultAdPosts" PagedControlID="lvResultAdPosts" PageSize="45" QueryStringField="page" runat="server">
            <Fields>
                <asp:NumericPagerField ButtonCount="15" ButtonType="Link" PreviousPageText="&laquo;" NextPageText="&raquo;" />
            </Fields>
        </asp:DataPager>
    </asp:Panel>
</div>