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
    <h2>
        Quảng cáo</h2>
    <div runat="server" id="divContentAds">
    </div>
</div>
