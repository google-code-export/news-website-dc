<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdGuideBox.ascx.cs" Inherits="NewsVn.Web.Modules.AdGuideBox" %>
<script type="text/javascript">
    $(function () {
        $(".dialog").dialog({
            autoOpen: false,
            resizable: false,
            modal: true,
            width: 500
        });

        $(".guide-box a:eq(0)").click(function () {
            $("#guideBox").dialog("open");
        });
        $(".guide-box a:eq(1)").click(function () {
            $("#paymentBox").dialog("open");
        });
//        $(".guide-box a:eq(2)").click(function () {
//            $("#howtoBox").dialog("open");
//        });
        $(".guide-box a:eq(2)").click(function () {
            $("#contactBox").dialog("open");
        });
    });
</script>

<div class="portlet guide-box">        
    <a class="button left" href="javascript:void(0)">Hướng dẫn</a>
    <a class="button left" href="javascript:void(0)">Thanh toán</a>
    <%--<a class="button left" href="javascript:void(0)">Đăng rao vặt nổi bật</a>--%>
    <a class="button right" href="javascript:void(0)">Thông tin liên hệ</a>    
    <div class="clear"></div>
</div>

<div id="guideBox" class="dialog" title="Hướng dẫn chung">
    <p>
        
			<!-- Qui dinh dang tin -->
			<p class="pHelp" style="margin: 15px 0pt 7px;">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17); text-transform: uppercase; text-decoration: underline;">Quy định đăng tin</font>
			</p>
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);">- Người đăng tin sẽ phải chịu trách nhiệm về tính xác thực và mọi tranh chấp xảy ra liên quan đến tin của mình đăng; không sử dụng thông tin cá nhân của người khác để đăng tin, mang tính bêu xấu, quấy rối. </font>
			</p>
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);">- Các tin sẽ bị từ chối đăng nếu vi phạm một trong các quy định sau:</font>
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial"><b>1.</b> Tin đăng gây rối trật tự xã hội, phá hoại an ninh quốc gia, làm tổn hại thuần phong mỹ tục hay kinh doanh bất hợp pháp.</font> 
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial"><b>2.</b> Tiêu đề tin vượt quá 50 ký tự (tính cả khoảng trống) và viết hoa toàn bộ.</font> 
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial"><b>3.</b> Tin viết bằng tiếng nước ngoài (ngoại trừ tên riêng), không dấu, viết hoa, sai lỗi chính tả, không viết bằng font Unicode.</font> 
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial"><b>4.</b> Tin đăng sai mục.</font> 
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial"><b>5.</b> Tin đăng có file ảnh không đúng quy định (phải là file .jpg hoặc .gif, dung lượng không quá 1M mỗi ảnh).</font> 
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial"><b>6.</b> Tin đăng giống nhau nhiều lần.</font> 
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial"><b>7.</b> Thiếu thông tin liên lạc (địa chỉ, số điện thoại, người liên lạc) hoặc đưa các thông tin liên lạc không đúng.</font> 
			</p>
			
			<!-- Hinh thuc hien thi -->
			<p class="pHelp" style="margin: 15px 0pt 7px;">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17); text-transform: uppercase; text-decoration: underline;">Hình thức hiển thị</font>
			</p>
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);"> 1. Tin NỔI BẬT:</font>
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial">Là tin lớn nhất trên trang, nằm ở vị trí đầu tiên của chuyên mục Rao vặt. Tối đa 10 tin, mỗi tin hiển thị trong vòng 5 giây, luân phiên và chia sẻ.</font> 
			</p>
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);"> 2. Tin VIP thuộc các mục:</font>
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial">Là tin ở vị trí cao nhất mỗi mục (Nhà đất, Ôtô xe máy, Làm đẹp, Điện thoại di động…). Tối đa 10 tin, mỗi tin hiển thị trong vòng 5 giây, luân phiên và chia sẻ.</font> 
			</p>
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);"> 3. Tin đậm thuộc các mục:</font>
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial">Là tin hiển thị tại vị trí bên dưới, ngay sau tin VIP thuộc các mục (Nhà đất, Ôtô xe máy, Làm đẹp, Điện thoại di động….). Tối đa 10 tin.</font> 
			</p>			
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);"> 4. Tin thu phí qua SMS (áp dụng với 4 mục Nhà đất, Ôtô Xe máy, Điện thoại di động và Máy tính):</font>
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial">Là tin hiển thị dạng thường, tin mới xuất hiện trên tin cũ, không in đậm, trong 4 mục <b>Nhà đất, Ôtô Xe máy, Điện thoại di động và Máy tính</b>.</font> 
			</p>
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);"> 5. Tin miễn phí (trừ 4 mục Nhà đất, Ôtô Xe máy, Điện thoại di động và Máy tính):</font>
			</p>
			<p class="pHelp" style="margin-left: 15px;">
				<font style="font-size: 9pt;" face="Arial">Là những tin còn lại ở các mục, hiển thị dạng thường, không in đậm, tin mới xuất hiện trên tin cũ.</font> 
			</p>
			
			<!-- Huong dan dang tin -->
			<p class="pHelp" style="margin: 15px 0pt 7px;">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17); text-transform: uppercase; text-decoration: underline;">Hướng dẫn đăng tin</font>
			</p>
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);">1. &nbsp;Đối với tin thu phí</font>
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt; color: rgb(123, 17, 17);" face="Arial">&nbsp;&nbsp;•	Qua SMS với hai mục Nhà đất và Ôtô Xe máy (tin thường)</font>
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt;" face="Arial">&nbsp;&nbsp;- Khách hàng sau khi điền đầy đủ thông tin vào form đăng ký trên trang Rao vặt, ấn Cập nhật sẽ nhận được một thông báo: “<b><i>Tin của bạn đã được lưu trong hệ thống. Để được đăng, bạn hãy soạn tin: “DTA (khoảng cách) Mã số tin” gửi đến <span style="color: red;">8700</span> (với các tin Nhà đất và Ôtô Xe máy - Chi phí 15.000 VNĐ/tin) hoặc <span style="color: red;">8600</span> (với các tin Điện thoại di động và Máy tính - Chi phí 10.000 VNĐ/tin)</i></b>”.</font> 
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt;" face="Arial">&nbsp;&nbsp;- Nếu tin được đăng, sẽ có thông báo gửi về điện thoại di động, kèm theo đường dẫn.</font> 
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt;" face="Arial">&nbsp;&nbsp;- Nếu tin không được đăng (vẫn sẽ bị trừ tiền) sẽ có thông báo kèm lý do (tài khoản di động không đủ tiền, do vi phạm nội quy đăng….).</font> 
			</p>
			<p class="Help">
				<font style="font-size: 9pt;" face="Arial">&nbsp;&nbsp;- Trong trường hợp muốn cập nhật nội dung, khách hàng chọn "Sửa tin" để nhận mã số mới và nhắn tin theo cú pháp <i><b>"DTM (khoảng cách) Mã số tin mới" gửi đến <span style="color: red;">8700</span> (với các tin Nhà đất và Ôtô Xe máy - Chi phí 15.000 VNĐ/tin) hoặc <span style="color: red;">8600</span> (với các tin Điện thoại di động và Máy tính - Chi phí 10.000 VNĐ/tin)</b></i>”. Lưu ý, số điện thoại để cập nhật phải trùng với số điện thoại đã đăng tin. 
			</font></p>
<font style="font-size: 9pt;" face="Arial">			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt;" face="Arial">&nbsp;&nbsp;- Tin sẽ lên trang tự động trong thời gian từ 7h30 đến 19h30 (từ thứ 2 đến thứ 6), và từ 7h30 đến 12h (thứ bảy)</font>
			</font></p><font style="font-size: 9pt;" face="Arial">			
			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt; color: rgb(123, 17, 17);" face="Arial">&nbsp;&nbsp;•	Qua các hình thức khác</font>
			</font></p><font style="font-size: 9pt;" face="Arial">			
			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt;" face="Arial">&nbsp;&nbsp;- Khách hàng điền đầy đủ thông tin vào form đăng ký trên trang Rao vặt, chọn hình thức đăng Tính phí.
			</font> </font></p>
<font style="font-size: 9pt;" face="Arial">			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt;" face="Arial">&nbsp;&nbsp;- Chọn hình thức thanh toán (trực tiếp tại tòa soạn hoặc chuyển khoản)
			</font> </font></p>
<font style="font-size: 9pt;" face="Arial">			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt;" face="Arial">&nbsp;&nbsp;- Ấn Cập nhật sẽ nhận được hướng dẫn để thực hiện việc thanh toán
			</font> </font></p>
<font style="font-size: 9pt;" face="Arial">			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt;" face="Arial">&nbsp;&nbsp;- Khi thanh toán hoàn tất, tin sẽ được đăng trên Rao vặt.
			</font> </font></p>
<font style="font-size: 9pt;" face="Arial">			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);">2. &nbsp;Đối với tin miễn phí:</font> 
			</font></p>
<font style="font-size: 9pt;" face="Arial">			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt;" face="Arial">&nbsp;•	Khách hàng sau khi điền đầy đủ thông tin vào form đăng ký trên trang Rao vặt, ấn Cập nhật.</font>
			</font></p>
<font style="font-size: 9pt;" face="Arial">			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt;" face="Arial">&nbsp;•	Yêu cầu khẳng định sẽ tự động gửi đến hộp thư riêng của khách hàng</font>
			</font></p>
<font style="font-size: 9pt;" face="Arial">			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt;" face="Arial">&nbsp;•	Click vào “Khẳng định" để xác nhận thông tin. </font>
			</font></p>
<font style="font-size: 9pt;" face="Arial">			</font><p class="pHelp">
<font style="font-size: 9pt;" face="Arial">				<font style="font-size: 9pt;" face="Arial">&nbsp;•	Khi hoàn tất các bước trên, tin Rao vặt sẽ được gửi tới Ban biên tập và lên trang trong 24h theo thứ tự. </font>
			</font></p>
<font style="font-size: 9pt;" face="Arial">		</font>
    </p>
</div>

<div id="paymentBox" class="dialog" title="Hình thức thanh toán">
    <p>
        
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);">Với các hình thức đăng tin Nổi bật, tin VIP, tin in đậm</font>
			</p>
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);">1.&nbsp;&nbsp;<span style="text-decoration: underline;">Thanh toán trực tiếp tại địa chỉ:</span></font>
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt; font-weight: bold;" face="Arial">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tại Hà Nội</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Chi nhánh tại Hà Nội - Công ty CP dịch vụ trực tuyến FPT</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Tầng 4, Hà Thành Plaza, 102 Thái Thịnh, Đống Đa, Hà Nội.</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">ĐT: 84-4-73008899(máy lẻ 4561, 4562)</font> 
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt; font-weight: bold;" face="Arial">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tại TP.HCM</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Công ty CP dịch vụ trực tuyến FPT</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Tầng 6, Tòa nhà FPT Online, 408 Điện Biên Phủ, P.11, Q.10, TP.HCM</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">ĐT: 84-8-73008899(máy lẻ 8561)</font> 
			</p>
			
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);">2.&nbsp;&nbsp;&nbsp;<span style="text-decoration: underline;">Thanh toán bằng chuyển khoản:</span></font>
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt; font-weight: bold;" face="Arial">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tại Hà Nội</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Tài khoản chuyển khoản: 045 100 1915900 - Ngân Hàng Ngoại Thương Việt Nam – CN Thành Công</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Người hưởng lợi: Chi nhánh tại Hà Nội – Công ty CP dịch vụ trực tuyến FPT - Tầng 3-4, Hà Thành Plaza, 102 Thái Thịnh, Đống Đa, Hà Nội.</font> 
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt; font-weight: bold;" face="Arial">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tại TP.HCM</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Tài khoản chuyển khoản: 007 100 3950999 - Ngân hàng Ngoại thương Việt Nam – CN Hồ Chí Minh</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Người hưởng lợi: Công ty CP dịch vụ trực tuyến FPT - 408 Điện Biên Phủ, P.11, Q.10, TP.HCM.</font> 
			</p>
			<br>
			<p class="pHelp">
				<font style="font-size: 12px; color: rgb(123, 17, 17);" face="Arial"><b>Với các hình thức đăng tin SMS (ở 2 mục Nhà đất và Ôtô Xe máy)</b>:</font><font style="color: rgb(0, 0, 0);"> Nhắn tin theo cú pháp hướng dẫn sau khi ấn cập nhật tin. Chi phí là 15.000 VND/tin.</font> 
			</p>
		
    </p>
</div>

<div id="howtoBox" class="dialog" title="Hướng dẫn đăng rao vặt nổi bật">
    <p></p>
</div>

<div id="contactBox" class="dialog" title="Liên hệ đăng rao vặt">
    <p>
        <p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);">Với các hình thức đăng tin Nổi bật, tin VIP, tin in đậm trên NewsVN</font>
			</p>
			<p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);"><span style="text-decoration: underline;">Liên hệ trực tiếp tại địa chỉ:</span></font>
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt; font-weight: bold;" face="Arial">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tại Hà Nội</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Chi nhánh tại Hà Nội - Công ty TNHH VietStream Software Solution</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Tầng 4, Hà Thành Plaza, 102 Thái Thịnh, Đống Đa, Hà Nội.</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">ĐT: 84-4-73008899(máy lẻ 4561, 4562)</font> 
			</p>
			<p class="pHelp">
				<font style="font-size: 9pt; font-weight: bold;" face="Arial">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tại TP.HCM</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Công ty TNHH VietStream Software Solution</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">Tầng 1, Tòa nhà PAT, 27 Hồ Bá Kiện, P.11, Q.10, TP.HCM</font> 
			</p>
			<p class="pHelp" style="padding-left: 30px;">
				<font style="font-size: 9pt;" face="Arial">ĐT: 84-8-73008899(máy lẻ 8561)</font> 
			</p>
            <p class="pHelp">
				<font style="font: bold 12px Arial; color: rgb(123, 17, 17);"><span style="text-decoration: underline;">Liên hệ qua Email:</span></font>
			</p>
			<p>
				<font style="font-size: 9pt; font-weight: bold;" face="Arial">- Ads@newsvn.vn</font> 
			</p>
            <p>
                <font style="font-size: 9pt; font-weight: bold;" face="Arial">- Ads@vss.vn</font> 
            </p>
			
    </p>
</div>