<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterCategoryList.ascx.cs"
   EnableViewState="false" Inherits="NewsVn.Web.Modules.FooterCategoryList" %>

<div class="section cate-list left">
	<h2>Danh mục chủ đề</h2>
	<ul class="item-list">
        <li class="head">
			<a href='<%= HostName + "trang-chu.aspx" %>'>Trang chủ</a>						
		</li>
        <asp:Repeater ID="rptFooterCate" runat="server">
            <ItemTemplate>
                <li>
			        <a href='<%#Eval("SeoUrl") %>'><%# Eval("Name") %></a>					
		        </li>
            </ItemTemplate>
        </asp:Repeater>
	</ul>
</div>