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
    <ul class="side-part-list">
        <li><a href="#" title="Quảng cáo 1" target="_blank" rel="nofollow">
            <img src="http://doanhnhansaigon.vn/files/articles/2010/1040959/advertising-creative-large.jpg"
                alt="Quảng cáo 1" />
        </a></li>
        <li>
            <iframe title="Adam Lambert Interview" width="280" height="200" src="http://www.youtube.com/embed/0a3mV57i2QA"
                frameborder="0" allowfullscreen></iframe>
        </li>
    </ul>
    <h2>
        Quảng cáo</h2>
    <div runat="server" id="divContentAds">
       
    </div>
</div>
