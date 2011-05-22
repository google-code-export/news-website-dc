<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeBehind="Common.aspx.cs" Inherits="NewsVn.Web.Exceptions.Common" %>

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
        <h2>Cảnh báo lỗi</h2>
        <ul class="ui-form ui-widget">
            <asp:Literal ID="ltrError" runat="server" />
        </ul>
    </div>
</asp:Content>
