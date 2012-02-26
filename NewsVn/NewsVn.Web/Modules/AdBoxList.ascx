<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdBoxList.ascx.cs" EnableViewState="false"
    Inherits="NewsVn.Web.Modules.AdBoxList" %>
<%--<%@ OutputCache Duration="10080" VaryByParam="None" Shared="true" %>--%>
<script type="text/javascript">
    $(function () {
        $(".side-part .side-part-list li:last-child").addClass("tail");
        $(".side-part-list img").lazyload({
            threshold: 150,
            effect: "fadeIn",
            placeholder: "http://lh5.ggpht.com/_XrWO8mEpDy0/TEdXIqjrAUI/AAAAAAAAAkU/3lwqSFT8IRQ/grey.gif"
        });
    });
</script>

<div class="side-part portlet">
    <h2> Quảng cáo</h2>
    <div runat="server" id="divContentAds"></div>
	
</div>
<%--<div style="padding:10px 5px 10px 5px !important; width:300px;" class="side-part portlet">
 <h2>Quảng cáo liên kết</h2>
    <!-- Begin VietAd -->
<script language="javascript" type="text/javascript">
    var vietad_zoneId = 'va_FCD03E3283ADA54F';
    var vietad_titleColor = '000000';
    var vietad_desColor = '000000';
    var vietad_linkColor = '000000';
    var vietad_bgColor = '000000';
    var vietad_borderColor = '000000';
    var vietad_width = '300';
    var vietad_height = '600';
    var vietad_sizeId = '23';
    var vietad_typeId = '4';  
</script> <script type="text/javascript" src="http://embed.vietad.vn/MagicBanner.js"></script> 
<!-- End: VietAd -->
 <div id="VietAd" ></div>

</div>
--%>

