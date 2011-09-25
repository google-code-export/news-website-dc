<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategorizedVideoList.ascx.cs" Inherits="NewsVn.Web.Modules.CategorizedVideoList" %>

<div class="portlet">
    <h2>Danh mục: <%= CategoryName %></h2>
    <asp:Repeater ID="rptVideoList" runat="server">
        <ItemTemplate>
            <div class="left">
                <asp:HyperLink CssClass="post-title inline" NavigateUrl='<%# HostName + Eval("SeoUrl") %>' Text='<%# Eval("Title") %>' runat="server">
                    <asp:Image ImageUrl="<%# Eval("Avatar") %>" runat="server" />
                </asp:HyperLink>
                <center><asp:HyperLink CssClass="post-title inline" NavigateUrl='<%# HostName + Eval("SeoUrl") %>' Text='<%# Eval("Title") %>' runat="server"/></center>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            <div class="clear"></div>
        </FooterTemplate>
    </asp:Repeater>
</div>
