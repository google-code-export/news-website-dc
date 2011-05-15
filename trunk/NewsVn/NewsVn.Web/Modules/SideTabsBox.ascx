<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideTabsBox.ascx.cs" Inherits="NewsVn.Web.Modules.SideTabsBox" %>

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

    $(function () {
        showWeather();
        $("#<%=regionSelector.ClientID %>").change(function () {
            showWeather();
        });
    });

    function showWeather() {
        var WOEID = $("#<%=regionSelector.ClientID %>").val();
        $.ajax({
            url: serviceUrl + "GetWeather",
            data: "{'Zipcode':'" + WOEID + "'}",
            success: function (result) {
                $("#weatherWidget").html(result.d);
            }
        });
    }
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
            <script language='javascript' type='text/javascript' src='http://vnexpress.net/Service/Gold_Content.js'></script>
                <script language='javascript' type='text/javascript'>
                document.writeln('<tr><td><b>Vàng SBJ</b></td><td>', vGoldSbjBuy, '</td>', '<td>', vGoldSbjSell, '</td>');
                document.writeln('<tr><td><b>Vàng SJC</b></td><td>', vGoldSjcBuy, '</td>', '<td>', vGoldSjcSell, '</td>');
                </script>
        </table>
        <span class="credit">Nguồn: VnExpress.net | ĐV: VNĐ</span>
    </div>
    <div id="currency">
        <asp:Repeater ID="rptCurrency" runat="server">
            <HeaderTemplate>
                <table class="ui-table" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <th>Loại</th>
                        <th>Mua vào</th>
                        <th>Bán ra</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><b><%#Eval("CurrencyCode") %></b></td><td><%#Eval("Buy")%></td><td><%#Eval("Sell")%></td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                   <td><b><%#Eval("CurrencyCode") %></b></td><td><%#Eval("Buy")%></td><td><%#Eval("Sell")%></td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                 </table>
            </FooterTemplate>
        </asp:Repeater>
     <span class="credit">Nguồn: vietcombank.com.vn | ĐV: VNĐ</span>
    </div>
    <div id="weather">
        <asp:DropDownList ID="regionSelector" runat="server">
        </asp:DropDownList>
        <div id="weatherWidget"></div>
    </div>
</div>
