<%@ Control Language="C#" ClassName="FooterIntro" %>

<div class="section intro left">
	<h2>Thông tin tòa soạn</h2>
	<p>
		Cơ quan chủ quản: Bộ Khoa học Công nghệ.<br/>
		Giấy phép: Số 511/GP - BVHTT ngày 25/11/2002.<br/>
		Tổng biên tập: Thang Đức Thắng
	</p>
	<p>
		Tòa soạn: Tầng 4 Tòa nhà Hà Thành Plaza 102 Thái Thịnh, Quận Đống Đa, Hà Nội.<br/>
		Đường dây nóng: 0123 888 0123<br/>
		Điện thoại: 04 7300 8899 - máy lẻ 4500<br/>
		Fax: 04 822 3155<br/>
		Liên hệ quảng cáo: 09 0436 1114
	</p>
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