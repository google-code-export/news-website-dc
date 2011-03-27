<%@ Control Language="C#" ClassName="SideTabsBox" %>

<script src="<%= Page.ResolveUrl("~/scripts/plugins/jquery.idTabs.min.js") %>" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        var selectorID = "#<%= regionSelector.ClientID %>";
        var linkSelector = $(selectorID);
        linkSelector.selectmenu({ width: "274px" });
        linkSelector.next(".ui-selectmenu").addClass("select");
        linkSelector.next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
        $(selectorID + "-menu").width(280);
        $(".side-part .datepicker").datepicker("option", "dateFormat", "DD, d MM, yy");
    });
</script>

<div class="side-part portlet">
	<h2>
        <ul class="idTabs"> 
          <li><a href="#gold">Giá vàng</a> |</li>
          <li><a href="#currency">Ngoại tệ</a> |</li> 
          <li><a href="#weather">Thời tiết</a></li>
        </ul>
    </h2>
    <div id="gold">
        <table class="ui-table" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <th>Loại</th>
                <th>Mua vào</th>
                <th>Bán ra</th>
            </tr>
            <tr>
                <td><b>Vàng SBJ</b></td><td><b>3.705.000</b></td><td><b>3.715.000</b></td>
            </tr>
            <tr>
                <td><b>Vàng SJC</b></td><td><b>3.704.000</b></td><td><b>3.718.000</b></td>
            </tr>
            <tr>
                <td>Vàng 24K</td><td>3.687.000</td><td>3.718.000</td>
            </tr>
            <tr>
                <td>Vàng 95%</td><td>3.496.000</td><td>&nbsp;</td>
            </tr>
            <tr>
                <td>Vàng 75%</td><td>2.707.000</td><td>2.804.000</td>
            </tr>
            <tr>
                <td>Vàng 58.3%</td><td>2.116.000</td><td>2.194.000</td>
            </tr>
            <tr>
                <td>Vàng 41.7%</td><td>1.497.000</td><td>1.575.000</td>
            </tr>
        </table>
        <span class="credit">Nguồn: VnExpress.net | ĐV: VNĐ</span>
    </div>
    <div id="currency">
        <table class="ui-table" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <th>Loại</th>
                <th>Mua vào</th>
                <th>Bán ra</th>
            </tr>
            <tr>
			    <td>AUD</td><td>20.476,95</td><td>21.499,23</td>
		    </tr>
            <tr>
			    <td>EUR</td><td>29.103,77</td><td>30.403,91</td>
		    </tr>
            <tr>
			    <td>GBP</td><td>33.300,75</td><td>34.928,52</td>
		    </tr>
            <tr>
			    <td>JPY</td><td>251,57</td><td>266,26</td>
		    </tr>
            <tr>
			    <td>USD</td><td>20.865,00</td><td>20.870,00</td>
		    </tr>
        </table>
        <span class="credit">Nguồn: Ngoisao.net | ĐV: VNĐ</span>
    </div>
    <div id="weather">
        <asp:DropDownList ID="regionSelector" runat="server">
            <asp:ListItem Value="1">Sơn La</asp:ListItem>
			<asp:ListItem Value="2">Việt Trì</asp:ListItem>
			<asp:ListItem Value="3">Hải Phòng</asp:ListItem>
			<asp:ListItem Value="4">Hà Nội</asp:ListItem>
			<asp:ListItem Value="5">Vinh</asp:ListItem>
			<asp:ListItem Value="6">Đà Nẵng</asp:ListItem>
			<asp:ListItem Value="7">Nha Trang</asp:ListItem>
			<asp:ListItem Value="8">Pleiku</asp:ListItem>
			<asp:ListItem Selected="True" Value="9">TP HCM</asp:ListItem>
        </asp:DropDownList>
        <table class="ui-table align-left" style="margin:10px 0;" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td colspan="2">
                    <b>Mây thay đổi</b>
                </td>                
            </tr>
            <tr>
                <td>Nhiệt độ</td>
                <td>20<sup>o</sup>C</td>
            </tr>
            <tr>
                <td>Độ ẩm</td>
                <td>82%</td>
            </tr>
            <tr>
                <td>Gió đông tốc độ</td>
                <td>7 m/s</td>
            </tr>
        </table>
        <span class="credit">Nguồn: Thanhnien.vn</span>
    </div>
</div>