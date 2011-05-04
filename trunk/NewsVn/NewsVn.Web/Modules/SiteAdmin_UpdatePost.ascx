<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdmin_UpdatePost.ascx.cs" Inherits="NewsVn.Web.Modules.SiteAdmin_UpdatePost" %>

<ul class="ui-form ui-widget">
    <li>
        <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" runat="server" />
        <asp:TextBox ID="txtTitle" Width="450" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="ddlCategory" Text="Danh mục:" runat="server" />
        <asp:DropDownList ID="ddlCategory" CssClass="dropdown" Width="456" runat="server">
            <asp:ListItem Text="[Chọn danh mục]" />
        </asp:DropDownList>
    </li>
    <li>
        <p><asp:Label AssociatedControlID="editorContent" Text="Nội dung:" runat="server" /></p>
        <nsn:RadEditor runat="server" ID="editorContent" Height="600px" Width="100%" EnableResize="false"
            ToolsFile="~/Resources/Xml/Editor/CustomTools.xml">
            <ImageManager ViewPaths="~/Resources/Images" UploadPaths="~/Resources/Images" DeletePaths="~/Resources/Images" MaxUploadFileSize="2097152" />
            <FlashManager ViewPaths="~/Resources/Flash" UploadPaths="~/Resources/Flash" DeletePaths="~/Resources/Flash" MaxUploadFileSize="4194304" />
            <MediaManager ViewPaths="~/Resources/Media" UploadPaths="~/Resources/Media" DeletePaths="~/Resources/Media" MaxUploadFileSize="10485760" /> 
            <DocumentManager ViewPaths="~/Resources/Documents" UploadPaths="~/Resources/Documents" DeletePaths="~/Resources/Documents" MaxUploadFileSize="10485760" /> 
        </nsn:RadEditor>
    </li>
    <li class="commands">
        <div class="right">
            <asp:HyperLink NavigateUrl="~/Account/SiteAdmin/Post/ViewPost.aspx" Text="Quay lại" CssClass="button-back" runat="server" />
            <asp:LinkButton Text="Thực hiện" CssClass="button-ok" runat="server" />
        </div>
        <div class="clear"></div>
    </li>
</ul>