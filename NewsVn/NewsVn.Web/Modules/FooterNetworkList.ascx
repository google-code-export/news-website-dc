<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterNetworkList.ascx.cs" Inherits="NewsVn.Web.Modules.FooterNetworkList" %>

<div class="section link-network">
	<h2>Mạng lưới</h2>
	<ul class="item-list">
		<li class="head">
			<img src="<%= Page.ResolveUrl("~/images/icons/facebook.png") %>" alt="Facebook" />
			<a href="http://www.facebook.com" target="_blank" rel="nofollow">								
				NewsVN trên Facebook
			</a>
		</li>
		<li>
			<img src="<%= Page.ResolveUrl("~/images/icons/twitter.png") %>" alt="Twitter" />
			<a href="http://www.twitter.com" target="_blank" rel="nofollow">								
				NewsVN trên Twitter
			</a>
		</li>
		<li>
			<img src="<%= Page.ResolveUrl("~/images/icons/youtube.png") %>" alt="Youtube" />
			<a href="http://www.youtube.com" target="_blank" rel="nofollow">								
				NewsVN trên Youtube
			</a>
		</li>
	</ul>
</div>