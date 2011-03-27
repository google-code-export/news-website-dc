<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdBoxList.ascx.cs" Inherits="NewsVn.Web.Modules.AdBoxList" %>

<script type="text/javascript">
    $(function () {
        $(".side-part .side-part-list li:last-child").addClass("tail");
    });
</script>

<div class="side-part portlet">	
	<br />
    <ul class="side-part-list">
		<li>
			<a href="#" title="Quảng cáo 1" target="_blank" rel="nofollow">
				<img src="http://doanhnhansaigon.vn/files/articles/2010/1040959/advertising-creative-large.jpg" alt="Quảng cáo 1" />
			</a>
		</li>
		<li>
			<iframe title="Adam Lambert Interview" width="280" height="200" src="http://www.youtube.com/embed/0a3mV57i2QA" frameborder="0" allowfullscreen></iframe>
		</li>
        <li>
               <%-- <param name="movie" value="http://static.mp3.zing.vn/skins/mp3_main/flash/mp3playlist.swf?xmlURL=http://mp3.zing.vn/xml/playlist/LmJHyZnNVNWvVmcyLFJyDnZn?autoplay=false&wmode=transparent" />
                <param name="quality" value="high" />
                <param name="wmode" value="transparent" />--%>
                <embed width="280" height="380" src="http://static.mp3.zing.vn/skins/mp3_main/flash/mp3playlist.swf?xmlURL=http://mp3.zing.vn/xml/playlist/LmJHyZnNVNWvVmcyLFJyDnZn?autoplay=false&wmode=transparent" quality="high" wmode="transparent" type="application/x-shockwave-flash"></embed>
        </li>
    </ul>
    <h2>Quảng cáo</h2>
    <ul class="side-part-list">
		<li>
			<a href="#" title="Quảng cáo 2" target="_blank" rel="nofollow">
				<img src="http://images01.trafficz.com/cache/h3w4/500_1191365659_10057984.jpg" alt="Quảng cáo 2" />
			</a>
		</li>        
        <li>
			<a href="#" title="Quảng cáo 3" target="_blank" rel="nofollow">
				<img src="http://www.tapchimarketing.vn/wp-content/uploads/2011/03/advertising_.jpg" alt="Quảng cáo 3" />
			</a>
		</li>
		<li>
			<a href="#" title="Quảng cáo 4" target="_blank" rel="nofollow">
				<img src="http://www.smashingapps.com/wp-content/uploads/2009/06/advertising-design-showcase.jpg" alt="Quảng cáo 4" />
			</a>
		</li>
		<li>
			<a href="#" title="Quảng cáo 5" target="_blank" rel="nofollow">
				<img src="http://farm2.anhso.net/pic/l/110466/410201011813935/Advertising-180.jpg" alt="Quảng cáo 5" />
			</a>
		</li>
		<li>
			<a href="#" title="Quảng cáo 6" target="_blank" rel="nofollow">
				<img src="http://farm1.anhso.net/pic/l/105353/197201022596645/Advertising-119.jpg" alt="Quảng cáo 6" />
			</a>
		</li>
		<li>
			<a href="#" title="Quảng cáo 7" target="_blank" rel="nofollow">
				<img src="http://www.dressregistry.com/images/advertising.jpg" alt="Quảng cáo 7" />
			</a>
		</li>
	</ul>
</div>