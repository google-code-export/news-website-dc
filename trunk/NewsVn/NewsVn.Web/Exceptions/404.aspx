<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="NewsVn.Web.Exceptions._404" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #content
        {
            min-height: 0;
            padding-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server">    
    <div class="portlet" style="margin:0">
        <h2>Không tìm thấy trang</h2>
        <ul class="ui-form ui-widget">
            <asp:Literal ID="ltrError" runat="server" />
        </ul>
    </div>
</asp:Content>
