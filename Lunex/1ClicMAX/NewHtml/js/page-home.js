﻿$(function() {
	ui.jWidget.setupPopup();
	
	pages.homep.handleProductsHover();
	pages.homep.setupSlider();
	pages.homep.showPromoPopup();
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};
}
pages = $.extend(pages, {
	homep: {
		handleProductsHover: function() {
			$("#productsNav").hover($.noop, function() {
				$("#homePage .product-desc").hide();
				$("#mainContent").fadeIn("fast");	
			});
			$("#productsNav li a").each(function(i) {
				// Use hover intent to avoid accidental hover on product items
				$(this).hoverIntent({
					over: function() {
						$("#homePage .product-desc").hide();
						$("#mainContent").hide();
						$("#homePage .product-desc").eq(i).fadeIn("fast");
					},
					out: $.noop,
					interval: 200	
				});
			});
		},
		setupSlider: function() {
			$("#homeSlider a.open-youtube").click(function() {
				ui.jWidget.showPopup($("#youtubePopupContent").html());				
            });
			$("#homeSlider .nivoSlider").nivoSlider({ pauseTime: 5000 });
		},
		showPromoPopup: function() {			
			ui.jWidget.showPopup($("#startupPopupContent").html(), null,
				function() { console.log("Open!") }, function() { console.log('Close!') })
		}
	}	
});