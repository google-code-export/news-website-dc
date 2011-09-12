<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="Special_Target_Management.ascx.cs" Inherits="NewsVn.Web.Modules.Special_Target_Management" %>

<script type="text/javascript">
    function confirmDelete(ID) {
        if (confirm('Bạn có muốn xóa tin này ra khỏi danh sách tin sự kiện nổi bật không?')) {
            document.getElementById('<%=hidID.ClientID %>').value = ID;
            return true;
        } else return false;
    }
    $(function () {
        $("#TitleRegion").css('cursor', 'pointer');

        $("#TitleRegion").click(function () {
            $("#ContentRegion").toggle('slow');
        });

    });
</script>
<style type="text/css">
.ui-table-remove-padding
{
    margin-top:5px !important;
}
.remove-fixed
{
    position:inherit;
}
</style>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
<div id="postHelpBox" class="dialog" title="Trợ giúp">
        Hint
</div>
    <div class="ui-table-toolbar remove-fixed">
        <span class="left" style="margin-top:4px">Lọc theo:</span>
        <asp:DropDownList ID="ddlFilterColumn" CssClass="dropdown left" runat="server">
            <asp:ListItem Text="Tiêu đề" />
            <asp:ListItem Text="Danh mục" />
            <asp:ListItem Text="Người tạo" />
            <asp:ListItem Text="Người sửa" />
            <asp:ListItem Text="Người duyệt" />
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" CssClass="left" Width="150" runat="server" />
        <asp:HyperLink ID="HyperLink2" NavigateUrl="#" Text="Lọc danh sách" CssClass="button-filter left" runat="server" />
        <asp:HyperLink ID="HyperLink3" Text="Lọc nâng cao" CssClass="button-filter left dialog-trigger[advancedFilterBox]" runat="server" />
        
        <div class="right">
            Trang:
            <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" runat="server" Width="50"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged" />
            &nbsp;Số dòng/Trang:
            <asp:DropDownList ID="ddlPageSize" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged">
                <asp:ListItem Value="50" Text="50" />
                <asp:ListItem Value="100" Text="100" />
                <asp:ListItem Value="200" Text="200" />
                <asp:ListItem Value="500" Text="500" />
                <asp:ListItem Value="1000" Text="1000" />
            </asp:DropDownList>
        </div>
        <div class="clear"></div>
        <hr />
        <div id="TitleRegion">
            <h3>Danh sách tin Sự kiện nổi bật</h3>
        </div>
        <div id="ContentRegion">
            <asp:GridView runat="server" ID="grvShow" AutoGenerateColumns="false" CssClass="ui-table ui-table-remove-padding" 
    onrowdatabound="grvShow_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <span><%#Container.DataItemIndex+1 %></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="ID" DataField="ID" />
        <asp:BoundField HeaderText="Tiêu đề" DataField="Title" />
        <asp:BoundField HeaderText="Danh mục" DataField="CateName" />
        <asp:BoundField HeaderText="Người duyệt" DataField="ApprovedBy" />
        <asp:BoundField HeaderText="Ngày duyệt" DataField="ApprovedOn" />
        
        <asp:TemplateField>
            <ItemTemplate> 
                <asp:LinkButton runat="server" ID="lnkbtnDel" onclick="lnkbtnDel_Click"><img src="/Images/ui/delete.gif" /></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
        </div>
        <div class="clear"></div>
        <hr />
         <asp:Button ID="btnAddHot" Text="Chọn làm tin Hot" runat="server" CssClass="button-add left" onclick="btnAddHot_Click"/>
        <div class="clear"></div>
    </div>    
        
    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false"  CssClass="ui-table ui-table-remove-padding">
    <Columns>
    <asp:TemplateField>
        <HeaderTemplate>
            <asp:CheckBox runat="server" ID="chkAll" />
        </HeaderTemplate>
        <ItemTemplate>
            <asp:CheckBox runat="server" ID="chkItem" CssClass="chkItem" />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="ID" DataField="ID" />
        <asp:BoundField HeaderText="Tiêu đề" DataField="Title" ControlStyle-Font-Names="Arial" />
        <asp:BoundField HeaderText="Danh mục" DataField="CategoryName" />
        <asp:BoundField HeaderText="Người duyệt" DataField="ApprovedBy" />
        <asp:BoundField HeaderText="Ngày duyệt" DataField="ApprovedOn" DataFormatString="{0:dd/MM/yyyy H:MM}" />
        <asp:BoundField HeaderText="Avatar" DataField="Avatar" />
        <asp:BoundField HeaderText="SeoUrl" DataField="SeoUrl"/>
        <asp:BoundField HeaderText="Description" DataField="Description" />
    </Columns>
</asp:GridView>

<asp:HiddenField runat="server" ID="hidID" Value="0" />
<%--</ContentTemplate>
</asp:UpdatePanel>--%>