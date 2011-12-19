<%@ Page Title="" Language="C#" MasterPageFile="~/Account/SiteAdmin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AutoFetchPost.aspx.cs" Inherits="NewsVn.Web.Account.SiteAdmin.Post.AutoFetchPost" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .portlet
        {
            background: none;
            margin-top: 20px;    
        }
        
        .portlet a
        {
            color: #104687;
        }

        .portlet .post-title
        {
            font-weight: bold;
            display: block;
            text-align: justify;
        }
        
        .portlet .post-title.inline
        {
            display: inline;
        }
        
        .portlet .post-info
        {
            font-size: 10px;
            font-style: italic;
        }
        
        .post-item-list li
        {
            padding: 7px 0;
            border-bottom: 1px dotted #333;
            position: relative;
        }

        .post-item-list li.head
        {
            padding: 0 0 7px;
        }

        .post-item-list .post-avatar
        {
            width: 130px;
            height: 110px;
            margin-right: 20px;
        }

        .post-item-list .post-item
        {
            width: 65%;
        }
    </style>
    <script src="<%= Page.ResolveUrl("~/scripts/newsvn.tool-postfetch.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="sideContent" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <asp:DropDownList ID="ddlFetchSite" CssClass="dropdown" runat="server" 
        AutoPostBack="true" OnSelectedIndexChanged="ddlFetchSite_SelectedIndexChanged" />
    <asp:DropDownList ID="ddlFetchCategory" CssClass="dropdown" runat="server" />
    <asp:LinkButton ID="btnGetPostList" Text="Lấy tin" CssClass="button" 
        runat="server" OnClick="btnGetPostList_Click" />
    <asp:LinkButton ID="btnAddPostItems" Text="Cập nhật" CssClass="button" 
        runat="server" OnClick="btnAddPostItems_Click" />
    <asp:Repeater ID="rptPostList" runat="server" OnItemDataBound="rptPostList_ItemDataBound">
    <HeaderTemplate>
        <div class="portlet">
            <ul class="post-item-list">
    </HeaderTemplate>
    <ItemTemplate>
        <li>                    
            <div class="left">
                <asp:CheckBox EnableViewState="false" runat="server" />
            </div>
            <div class="post-item right">                       
                <div class="wrap">
                    <a href='<%#Eval("Url") %>' class="post-title inline"><%#Eval("Title") %></a>
                    <span class="post-info"><%#string.Format("{0:dddd, dd/MM/yyyy HH:MM}",Eval("PubDate")) %></span>
                </div>            
                <p><%#Eval("Description") %></p>
                <br />
                <i>Danh mục:</i> <asp:DropDownList ID="ddlTargetCategory" CssClass="dropdown" runat="server" />
            </div>
            <asp:Image ID="imgAvatar" ImageUrl='<%# Eval("Avatar") %>'
                AlternateText='<%#Eval("Title") %>' ToolTip='<%#Eval("Title") %>'
                CssClass="post-avatar right" Width="130" Height="110" runat="server" />
            <div class="clear"></div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
            </ul>
        </div>
    </FooterTemplate>
    </asp:Repeater>        
</asp:Content>