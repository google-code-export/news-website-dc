<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Special_Target_Management.ascx.cs"
    Inherits="NewsVn.Web.Modules.Special_Target_Management" %>

<script type="text/javascript">
    function confirmDelete(ID) {
        if (confirm('Bạn có muốn xóa tin này ra khỏi danh sách tin sự kiện nổi bật không?')) {
            document.getElementById('<%=hidID.ClientID %>').value = ID;
            return true;
        } else return false;
    }
    $(function () {
        $("#TitleRegion h3").css({ 'cursor': 'pointer', 'color': '#BD0D0D' });
        $("#TitleRegion").click(function () {
            $("#ContentRegion").toggle('slow');
        });
    });
</script>
<style type="text/css">
    .ui-table-remove-padding
    {
        margin-top: 5px !important;
    }
    .remove-fixed
    {
        position: inherit;
    }
</style>

<div class="ui-table-toolbar remove-fixed" style="padding-top:0">
    <div id="TitleRegion">
        <h3>Danh sách tin sự kiện nổi bật</h3>
    </div>
    <div id="ContentRegion">
        <asp:GridView runat="server" ID="grvShow" AutoGenerateColumns="false" CssClass="ui-table ui-table-remove-padding"
            OnRowDataBound="grvShow_RowDataBound" GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <span><%# Container.DataItemIndex+1 %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Tiêu đề" DataField="Title" />
                <asp:BoundField HeaderText="Danh mục" DataField="CateName" />
                <asp:BoundField HeaderText="Người duyệt" DataField="ApprovedBy" />
                <asp:BoundField HeaderText="Ngày duyệt" DataField="ApprovedOn" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkbtnDel" OnClick="lnkbtnDel_Click"><img src="/Images/ui/delete.gif" /></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div style="padding-top:10px">
        <div class="left">
            <asp:Button ID="btnAddHot" Text="Chọn làm tin Hot" runat="server" CssClass="button-add"
                OnClick="btnAddHot_Click" />
            <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[postHelpBox]" runat="server" />
        </div>
        <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh right" runat="server" />
        <div class="clear"></div>
    </div>
    <hr />
    <div id="postHelpBox" class="dialog" title="Trợ giúp">
        Hint
    </div>    
    <div class="left">
        Sắp xếp theo:
        <asp:DropDownList ID="ddlSortColumn" CssClass="dropdown" Width="120px" runat="server"
            AutoPostBack="true">
            <asp:ListItem Value="Title" Text="Tiêu đề" />
            <asp:ListItem Value="Category.Name" Text="Danh mục" />
            <asp:ListItem Value="ApprovedOn" Text="Ngày duyệt" />
            <asp:ListItem Value="ApprovedBy" Text="Người duyệt" />
        </asp:DropDownList>
        <asp:DropDownList ID="ddlSortDirection" CssClass="dropdown" Width="70px" runat="server"
            AutoPostBack="true">
            <asp:ListItem Value="ASC" Text="A -> Z" />
            <asp:ListItem Value="DESC" Text="Z -> A" />
        </asp:DropDownList>
        <asp:LinkButton ID="btnClearSort" CssClass="button-clear" Text="Bỏ sắp xếp" Visible="false" runat="server" />
        <asp:HyperLink ID="lnkFilter" Text="Lọc tin tức" CssClass="button-filter dialog-trigger[filterBox]" runat="server" />
        <asp:LinkButton ID="btnClearFilter" CssClass="button-clear" Text="Bỏ lọc" Visible="false" runat="server" />
    </div>
    <div class="right">
        Trang:
        <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" runat="server" Width="50"
            AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged" />
        &nbsp;Số dòng/Trang:
        <asp:DropDownList ID="ddlPageSize" CssClass="dropdown" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="Pager_SelectedIndexChanged">
            <asp:ListItem Value="50" Text="50" />
            <asp:ListItem Value="100" Text="100" />
            <asp:ListItem Value="200" Text="200" />
            <asp:ListItem Value="500" Text="500" />
            <asp:ListItem Value="1000" Text="1000" />
        </asp:DropDownList>
    </div>
    <div class="clear"></div>
</div>
<asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" CssClass="ui-table ui-table-remove-padding"
    GridLines="None">
    <Columns>
        <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox runat="server" ID="chkAll" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="chkItem" CssClass="chkItem" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="ID" DataField="ID" Visible="false" />
        <asp:HyperLinkField HeaderText="Tiêu đề" DataTextField="Title" DataNavigateUrlFields="SeoUrl"
            DataNavigateUrlFormatString="~/{0}" Target="_blank" />
        <asp:BoundField HeaderText="Danh mục" DataField="CategoryName" />
        <asp:BoundField HeaderText="Người duyệt" DataField="ApprovedBy" />
        <asp:BoundField HeaderText="Ngày duyệt" DataField="ApprovedOn" DataFormatString="{0:dd/mm/yyyy HH:MM}" />
        <asp:BoundField HeaderText="Avatar" DataField="Avatar" Visible="false" />
        <asp:BoundField HeaderText="SeoUrl" DataField="SeoUrl" Visible="false" />
        <asp:BoundField HeaderText="Description" DataField="Description" Visible="false" />
    </Columns>
</asp:GridView>
<asp:HiddenField runat="server" ID="hidID" Value="0" />
