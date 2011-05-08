<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdmin_UpdatePost.ascx.cs" Inherits="NewsVn.Web.Modules.SiteAdmin_UpdatePost" %>

<div id="updatePostHelpBox" class="dialog" title="Trợ giúp">
</div>
<ul class="ui-form ui-widget">
    <li>
        <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" runat="server" />
        <asp:TextBox ID="txtTitle" Width="450" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="txtAvatar" Text="Hình đại diện:" runat="server" />
        <asp:TextBox ID="txtAvatar" Width="450" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="ddlCategory" Text="Danh mục:" runat="server" />
        <asp:DropDownList ID="ddlCategory" CssClass="dropdown" Width="456" runat="server">
            <asp:ListItem Text="[Chọn danh mục]" />
        </asp:DropDownList>        
    </li>
    <li>
        <label></label>
        <asp:Label AssociatedControlID="chkActived" Text="Cho phép hiển thị:" CssClass="checkbox-label" runat="server" />
        <asp:CheckBox ID="chkActived" Checked="true" runat="server" />
        &nbsp;|&nbsp;
        <asp:Label AssociatedControlID="chkAllowComments" Text="Cho phép bình luận:" CssClass="checkbox-label" runat="server" />
        <asp:CheckBox ID="chkAllowComments" Checked="true" runat="server" />
        &nbsp;|&nbsp;
        <asp:Label AssociatedControlID="chkCheckPageView" Text="Theo dõi lượt truy cập:" CssClass="checkbox-label" runat="server" />
        <asp:CheckBox ID="chkCheckPageView" Checked="true" runat="server" />
        <asp:CheckBox ID="chkApproved" Checked="true" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="txtDescription" Text="Mô tả:" runat="server" />
        <asp:TextBox ID="txtDescription" TextMode="MultiLine" Columns="5" Rows="8" Width="650" runat="server" />
    </li>
    <li>
        <p><asp:Label AssociatedControlID="editorContent" Text="Nội dung:" runat="server" /></p>
       <%-- <nsn:RadEditor runat="server" ID="editorContent" Height="600px" Width="100%" EnableResize="false"
            ToolsFile="~/Resources/Xml/Editor/CustomTools.xml">
            <ImageManager ViewPaths="~/Resources/Images" UploadPaths="~/Resources/Images" DeletePaths="~/Resources/Images" MaxUploadFileSize="2097152" />
            <FlashManager ViewPaths="~/Resources/Flash" UploadPaths="~/Resources/Flash" DeletePaths="~/Resources/Flash" MaxUploadFileSize="4194304" />
            <MediaManager ViewPaths="~/Resources/Media" UploadPaths="~/Resources/Media" DeletePaths="~/Resources/Media" MaxUploadFileSize="10485760" /> 
            <DocumentManager ViewPaths="~/Resources/Documents" UploadPaths="~/Resources/Documents" DeletePaths="~/Resources/Documents" MaxUploadFileSize="10485760" /> 
        </nsn:RadEditor>--%>
        <nsn:Editor ID="editorContent" runat="server" AutoConfigure="Default" 
            Height="550px" Width="100%" ContextMenuMode="Default" ShowDecreaseButton="False" 
            ShowEnlargeButton="False" ShowGroupMenuImage="False" FilesPath="" Text="">
        </nsn:Editor>
    </li>
    <li class="commands">
        <div class="right">
            <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ViewPost.aspx" Text="Quay lại" CssClass="button-back" runat="server" />
            <asp:HyperLink Text="Trợ giúp" CssClass="button-help dialog-trigger[updatePostHelpBox]" runat="server" />
            <asp:LinkButton ID="btnUpdate" Text="Lưu" CssClass="button-ok" runat="server"
                OnClick="btnUpdate_Click" />
        </div>
        <div class="clear"></div>
    </li>
</ul>