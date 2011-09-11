<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterIntro.ascx.cs" Inherits="NewsVn.Web.Modules.FooterIntro" %>

<div class="section intro left">
	<div id="NewsVnInfo" runat="server"></div>
	<div class="intro-button short right">
		<img src="<%= Page.ResolveUrl("~/images/icons/feed.png") %>" />
		<a href="#">Tin RSS</a>
	</div>
	<div class="intro-button long right">
		<img src="<%= Page.ResolveUrl("~/images/icons/home.png") %>" />
		<a href="#">Đặt làm trang chủ</a>
	</div>
	<div class="clear"></div>
	<div class="intro-button short right">
		<img src="<%= Page.ResolveUrl("~/images/icons/user.png") %>" />
		<a href="#">Tuyển dụng</a>
	</div>
	<div class="intro-button long right">
		<img src="<%= Page.ResolveUrl("~/images/icons/mail.png") %>" />
		<a href="#">Gởi email liên hệ</a>
	</div>				
	<div class="clear"></div>
</div>