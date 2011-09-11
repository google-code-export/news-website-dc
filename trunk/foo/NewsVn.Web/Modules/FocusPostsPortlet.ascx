<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FocusPostsPortlet.ascx.cs" Inherits="NewsVn.Web.Modules.FocusPostsPortlet" %>

<script runat="server">

</script>

<div class="side-part focus-posts portlet">
    <h2>Tiêu điểm</h2>
    <ul>
        <asp:Repeater runat="server" ID="rptFocusPost">
            <ItemTemplate>
                <li>
                    <img src='<%#Eval("Avatar") %>' alt='<%#Eval("Title") %>' title='<%#Eval("Title") %>' class="post-avatar" />
                    <a href='<%# HostName+Eval("SeoUrl") %>' class="post-title inline"><%#Eval("Title") %></a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>