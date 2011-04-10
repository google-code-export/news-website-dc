<%@ Control Language="C#" ClassName="AdPostsPortlet" %>

<script runat="server">
    public string Title { get; set; }
    public string CssClass { get; set; }
    public bool ClearLayout { get; set; }
    public object DataSource { get; set; }

    protected override void OnLoad(EventArgs e)
    {
        if (!string.IsNullOrEmpty(CssClass))
        {
            container.CssClass += " " + CssClass;
        }

        if (ClearLayout)
        {
            var clearDiv = new HtmlGenericControl("div");
            clearDiv.Attributes.Add("class", "clear");
            this.Controls.Add(clearDiv);
        }
    }

    protected override void OnDataBinding(EventArgs e)
    {

    }
</script>

<asp:Panel ID="container" CssClass="cate-adposts portlet" Width="465" runat="server">
    <script type="text/javascript">
    
    </script>
     <h2>
        <a class="cate-title" href="adcategory.aspx"><%= Title %></a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)">Mua</a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)">Bán</a>
    </h2>
    <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style="width:220px;"><a href="#"><b>Tin nổi bật</b></a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Toàn quốc</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#"><b>Tin nổi bật</b></a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hồ Chí Minh</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#"><b>Tin nổi bật</b></a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
        <tr>
            <td style="width:220px;"><a href="#">Tin nổi bật</a></td>
            <td><%= string.Format("{0:dd/MM/yyyy}", DateTime.Now) %></td>
            <td style="width:120px;">Hà Nội</td>
        </tr>
    </table>
    <p>
        <a class="right" href="../adsubcategory.aspx">&raquo; Các tin khác</a>
    </p>
</asp:Panel>