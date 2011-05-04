<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteAdmin_UpdatePost.ascx.cs" Inherits="NewsVn.Web.Modules.SiteAdmin_UpdatePost" %>

<ul class="ui-form ui-widget">
    <li>
        <asp:Label AssociatedControlID="txtTitle" Text="Tiêu đề:" runat="server" />
        <asp:TextBox ID="txtTitle" runat="server" />
    </li>
    <li>
        <asp:Label AssociatedControlID="txtCategoryName" Text="Danh mục:" runat="server" />
        <asp:TextBox ID="txtCategoryName" runat="server" />
    </li>
    <li>
        <nsn:RadEditor runat="server" ID="editorContent" SkinID="DefaultSetOfTools"
            Height="600px" Width="100%" EnableResize="false"
            ToolsFile="~/Resources/Xml/Editor/FullSetOfTools.xml">
            <ImageManager ViewPaths="~/resources/posts" UploadPaths="~/resources/posts" DeletePaths="~/resources/posts" />
        </nsn:RadEditor>
    </li>
    <li class="commands">
        <div class="right">
            <asp:LinkButton Text="Thực hiện" CssClass="button-ok" runat="server" />
            <asp:HyperLink Text="Hủy bỏ" CssClass="button-cancel" runat="server" />
        </div>
        <div class="clear"></div>
    </li>
</ul>