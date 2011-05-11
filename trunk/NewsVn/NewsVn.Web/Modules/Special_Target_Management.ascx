<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="Special_Target_Management.ascx.cs" Inherits="NewsVn.Web.Modules.Special_Target_Management" %>

<asp:GridView runat="server" ID="grvShow" AutoGenerateColumns="false" 
    onrowdatabound="grvShow_RowDataBound">
    <Columns>
    <asp:TemplateField>
        <HeaderTemplate>
            <asp:CheckBox runat="server" ID="chkAll" />
        </HeaderTemplate>
        <ItemTemplate>
            <asp:CheckBox runat="server" ID="chkItem" />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT">
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
            <asp:LinkButton runat="server" ID="lnkbtnDel">Xóa</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkbtnF">First</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkbtnU">Up</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkbtnD">Down</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkbtnL">Last</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<div id="postHelpBox" class="dialog" title="Trợ giúp">
        Hint
    </div>
    <div class="ui-table-toolbar">
        <asp:HyperLink ID="btnAdd" Text="Thêm" CssClass="button-add left" runat="server"
            NavigateUrl="~/Account/SiteAdmin/Post/AddPost.aspx" />
        <asp:HyperLink ID="btnEdit" Text="Sửa" CssClass="button-edit left" runat="server"
            NavigateUrl="~/Account/SiteAdmin/Post/EditPost.aspx" />
        <asp:LinkButton ID="btnDelete" Text="Xóa" CssClass="button-delete left" runat="server"
            OnClientClick="return confirmDelete()" />
        <asp:HyperLink ID="HyperLink1" Text="Trợ giúp" CssClass="button-help left dialog-trigger[postHelpBox]" runat="server" />
        <asp:LinkButton ID="btnRefresh" Text="Nạp lại" CssClass="button-refresh right" runat="server" />
        <div class="clear"></div>
        <hr />
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
            <asp:DropDownList ID="ddlPageIndex" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged" />
            &nbsp;Số dòng/Trang:
            <asp:DropDownList ID="ddlPageSize" CssClass="dropdown" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="Pager_SelectedIndexChanged">
                <asp:ListItem Value="15" Text="15" />
                <asp:ListItem Value="25" Text="25" />
                <asp:ListItem Value="35" Text="35" />
                <asp:ListItem Value="45" Text="45" />
                <asp:ListItem Value="55" Text="55" />
            </asp:DropDownList>
        </div>
        <div class="clear"></div>
    </div>    
    <div>
        <asp:Button ID="btnAddHot" Text="Chọn làm tin Hot" runat="server" 
            onclick="btnAddHot_Click" />
    </div>
    <asp:Repeater ID="rptPostList" runat="server">
        <HeaderTemplate>
            <table class="ui-table" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th><asp:CheckBox ID="CheckBox1" EnableViewState="false" runat="server" /></th>
                    <th>Tiêu đề</th>
                    <th>Danh mục</th>
                    <th>Đã duyệt</th>
                    <th>Duyệt lúc</th>
                    <th>Duyệt bởi</th>
                    <th>Hiển thị</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><asp:CheckBox ID="CheckBox2" EnableViewState="false" runat="server" /></td>
                <td>
                    <a href='<%= HostName + "account/siteadmin/post/editpost.aspx?pid=" %><%# Eval("ID") %>'>
                        <%# Eval("Title") %>
                    </a>
                </td>
                <td>
                        <%# Eval("CategoryName") %>
                </td>
                <td align="center"><asp:CheckBox ID="CheckBox3" Checked='<%# Eval("Approved") %>' Enabled="false" runat="server" /></td>
                <td><%# Eval("ApprovedOn", "{0:dd/MM/yy HH:ss}")%></td>
                <td><%# Eval("ApprovedBy") %></td>
                <td align="center"><asp:CheckBox ID="CheckBox4" Checked='<%# Eval("Actived") %>' Enabled="false" runat="server" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" >
    <Columns>
    <asp:TemplateField>
        <HeaderTemplate>
            <asp:CheckBox runat="server" ID="chkAll" />
        </HeaderTemplate>
        <ItemTemplate>
            <asp:CheckBox runat="server" ID="chkItem" />
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STT">
            <ItemTemplate>
                <span><%#Container.DataItemIndex+1 %></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Tiêu đề" DataField="Title" ControlStyle-Font-Names="Arial" />
        <asp:BoundField HeaderText="Danh mục" DataField="CategoryName" />
        <asp:BoundField HeaderText="Người duyệt" DataField="ApprovedBy" />
        <asp:BoundField HeaderText="Ngày duyệt" DataField="ApprovedOn" DataFormatString="{0:dd/mm/yyyy HH:MM}" />
        <asp:BoundField HeaderText="Avatar" DataField="Avatar" />
        <asp:BoundField HeaderText="SeoUrl" DataField="SeoUrl"/>
        <asp:BoundField HeaderText="ID" DataField="ID" />
        <asp:BoundField HeaderText="Description" DataField="Description" />
    </Columns>
</asp:GridView>
