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
        $(".guide-box a:eq(2)").click(function () {
            $("#howtoBox").dialog("open");
        });
        $(".guide-box a:eq(3)").click(function () {
            $("#contactBox").dialog("open");
        });
    });
</script>

<div class="portlet guide-box">        
    <a class="button left" href="javascript:void(0)">Hướng dẫn</a>
    <a class="button left" href="javascript:void(0)">Thanh toán</a>
    <a class="button left" href="javascript:void(0)">Đăng rao vặt nổi bật</a>
    <a class="button right" href="javascript:void(0)">Thông tin liên hệ</a>    
    <div class="clear"></div>
</div>

<div id="guideBox" class="dialog" title="Hướng dẫn chung">
    <p></p>
</div>

<div id="paymentBox" class="dialog" title="Hình thức thanh toán">
    <p></p>
</div>

<div id="howtoBox" class="dialog" title="Hướng dẫn đăng rao vặt nổi bật">
    <p></p>
</div>

<div id="contactBox" class="dialog" title="Liên hệ đăng rao vặt">
    <p></p>
</div>