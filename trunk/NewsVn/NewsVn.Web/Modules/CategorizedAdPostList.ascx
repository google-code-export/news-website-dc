<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategorizedAdPostList.ascx.cs" Inherits="NewsVn.Web.Modules.CategorizedAdPostList" %>

<script type="text/javascript">
    $(document).ready(function () {
        $("#h2Title a").click(function () {
            var objContainer = $("#tlbAdsList");
            var isSearchByDate = $("#<%=hidD.ClientID %>").val() == "" ? false : true;
            var pIndex = $("#<%=hidP.ClientID %>").val() == "" ? "0" : $("#<%=hidP.ClientID %>").val();
            loadAdsList($("#<%=hidCt.ClientID %>").val(), pIndex, isSearchByDate, $("#<%=hidD.ClientID %>").val(), $(this).index() - 1, objContainer);
        });
    });

    function loadAdsList(ct, pIndex, isSearchDate, dtime, Location,obj) {
        var dataObj = { AdsCatName: ct, pageindex: pIndex, isSearchByDate: isSearchDate, searchDate: dtime, locationID: Location };
        $.ajax({
            url: serviceUrl + "load_pletAdsList",
            data: Sys.Serialization.JavaScriptSerializer.serialize(dataObj),
            success: function (result) {
                //alert(result.d);
                 obj.html(result.d);
            }
        });
    }
</script>

<div class="portlet categorized-adposts">
    <h2 id="h2Title">
        <a class="cate-title" href='<%=HostName+"rao-nhanh/"+Request.QueryString["ct"]+".aspx" %>'><%=CateTitle%></a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)" >Toàn quốc</a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)" >Hà Nội</a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)" >TP HCM</a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)">Các tỉnh miền Bắc</a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)">Các tỉnh miền Nam</a>
    </h2>
    <table class="ui-table" border="0" cellpadding="0" cellspacing="0" id="tlbAdsList">
        <asp:Repeater runat="server" ID="rptAdsList" 
            onitemdatabound="rptAdsList_ItemDataBound">
            <HeaderTemplate>
                <tr>
                    <th style="text-align:left;">Tin rao vặt</th>
                    <th style="text-align:left;">Ngày đăng</th>
                    <th style="text-align:left;">Phạm vi</th>
                </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><asp:HyperLink runat="server" ID="hplnk" /></td>
                    <td ><%#string.Format("{0:dd/MM/yyyy}", Eval("CreatedOn"))%></td>
                    <td style="width:100px;"><%#NewsVn.Web.Utils.clsCommon.getLocationName(int.Parse(Eval("Location").ToString()))%></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <tr>
                    <td><div style="text-align:center; padding-top:6px;"><asp:Label runat="server" ID="lblEmpty" Visible="false" Text="Không tìm thấy bài viết"></asp:Label></div></td>
                    <td style="width:100px;">
                    </td>
                </tr>
            </FooterTemplate>
        </asp:Repeater>
    </table>
</div>
<div style="margin-top:20px;">
    <div class="left">
        <asp:LinkButton runat="server" ID="lnkbtnPrevious" CssClass="button" 
            onclick="lnkbtnPrevious_Click" >&laquo; Tin mới hơn</asp:LinkButton>
        <asp:LinkButton runat="server" ID="lnkbtnNext" CssClass="button" 
            onclick="lnkbtnNext_Click" >Tin cũ hơn &raquo;</asp:LinkButton>
    </div>
    <asp:Button runat="server" ID="btnView" CssClass="button right"  
        style="margin:0.5px 0 0 5px;" Text="Xem" onclick="btnView_Click" />&nbsp;
    <div class="textbox-icon right">
        <asp:TextBox ID="txtGoldDate" CssClass="datepicker" style="width:100px" runat="server" />
    </div>
    <div class="clear"></div>
</div>
<asp:HiddenField runat="server" ID="hidCt" Value="" />
<asp:HiddenField runat="server" ID="hidP" Value="0" />
<asp:HiddenField runat="server" ID="hidD" Value="" />