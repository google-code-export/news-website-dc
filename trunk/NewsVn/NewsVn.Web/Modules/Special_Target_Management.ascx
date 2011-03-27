<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Special_Target_Management.ascx.cs" Inherits="NewsVn.Web.Modules.Special_Target_Management" %>

<div>
<asp:DropDownList ID="drpCateoryType" runat="server" AutoPostBack="True" 
        onselectedindexchanged="drpCateoryType_SelectedIndexChanged">
    <asp:ListItem Text="Sự kiện nổi bật" Value="Special"></asp:ListItem>
    <asp:ListItem Text="Tiêu điểm" Value="Target"></asp:ListItem>
</asp:DropDownList>
</div>
<div>
Danh mục: <asp:DropDownList runat="server" ID="drpCat">
          </asp:DropDownList>
</div>
<div>
Tiêu đề: <asp:TextBox  runat="server" ID="txtTitle"></asp:TextBox> <asp:Button runat="server" ID="btnFind" Text="[OK]" /><br />
Avatar: <asp:Image runat="server" ID="imgAvatar" AlternateText="" /><br />
SeoUrl: <asp:Label runat="server" ID="lblSeoUrl" Text=""></asp:Label><br />
Mô tả: <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescription"></asp:TextBox>
</div>
<div>
<asp:GridView runat="server" ID="grvShow" AutoGenerateColumns="false">
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
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkbtnEdit">Sửa</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkbtnDel">Xóa</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Tiêu đề" DataField="Title" />
        <asp:BoundField HeaderText="SeoUrl" DataField="SeoUrl" />
        <asp:BoundField HeaderText="Mô tả" DataField="ApprovedOn" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lnkbtnF">First</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkbtnU">Up</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkbtnD">Down</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lnkbtnL">Last</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</div>
<asp:HiddenField runat="server" ID="postID" Value="" />