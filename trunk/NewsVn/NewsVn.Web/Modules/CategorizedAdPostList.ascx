<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategorizedAdPostList.ascx.cs" Inherits="NewsVn.Web.Modules.CategorizedAdPostList" %>

<script type="text/javascript">
</script>

<div class="portlet categorized-adposts">
    <h2>
        <a class="cate-title" href="#"><%=CateTitle%></a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)">Toàn quốc</a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)">Hà Nội</a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)">TP HCM</a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)">Các tỉnh miền Bắc</a>
        &raquo; <a style="text-transform:none;" href="javascript:void(0)">Các tỉnh miền Nam</a>
    </h2>
    <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th style="text-align:left;">Tin rao vặt</th>
            <th style="text-align:left;">Ngày đăng</th>
        </tr>
        <asp:Repeater runat="server" ID="rptAdsList" 
            onitemdatabound="rptAdsList_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <td><asp:HyperLink runat="server" ID="hplnk" /></td>
                    <td style="width:80px;"><%#string.Format("{0:dd/MM/yyyy}",Eval("CreatedOn")) %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
<div style="margin-top:20px;">
    <div class="left">
        <a href="#" class="button">&laquo; Tin cũ hơn</a>
        <a href="#" class="button">Tin mới hơn &raquo;</a>
    </div>
    <input class="button right" type="button" value="Xem" style="margin:0.5px 0 0 5px;" />&nbsp;
    <div class="textbox-icon right">
        <asp:TextBox ID="txtGoldDate" CssClass="datepicker" style="width:100px" runat="server" />
    </div>
    <div class="clear"></div>
</div>