$(function() {
	ui.jWidget.setupPopup();
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTvAds();
	form.validation.setupMany([
		{ form: "createPromoDialog form", option: { promptPosition: "topLeft", binded: false } }
	]);
	
	pages.homep.handleProductsHover();
	pages.homep.setupSlider();
	pages.homep.setupMsgRoller();
	//pages.homep.showPromoPopup();
	pages.homep.allowCreatePromoCode();
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
						$("#homePage .product-desc").eq(i).fadeIn("fast", function() {
							var img = $(this).find("img");
							img.attr("src", img.attr("data-src"));
							img.removeAttr("data-src");
						});
						ui.layout.dockFooter();
					},
					out: function() {
						ui.layout.dockFooter();
					},
					interval: 200	
				});
			});
		},
		setupSlider: function() {
			$("#mainContent .nivoSlider").nivoSlider({
				pauseTime: 5000,
				afterLoad: function() {				
					ui.layout.dockFooter();
				}
			});
		},
		setupMsgRoller: function() {
			$("#mainContent .feeds").setScroller({
				velocity: 80
			});
			$("#viewAllMsgs").click(function() {
                ui.jWidget.showDialog("msgListDialog", {
					open: function() {
						// TODO: AJAX here
					}	
				});
            });
			$("#mainContent .feeds a, #msgListDialog article a").click(function() {
                ui.jWidget.showDialog("msgDetailsDialog", {
					open: function() {
						// TODO: AJAX here
						$(this).dialog("option", { title: "Sample Message Title" }); // Got this from AJAX result	
					}	
				});
            });
		},
		showPromoPopup: function() {			
			ui.jWidget.showPopup($("#startupPopupContent").html(), null,
				function() { console.log("Open!") }, function() { console.log('Close!') })
		},
		allowCreatePromoCode: function() {			
			$("#createPromoLink").click(function() {
				ui.jWidget.showDialog("createPromoDialog", {
					width: 600,
					buttons: [
						{
							text: "Cancel",
							class: "sub-button",
							click: function() {
								ui.jWidget.closeDialog("createPromoDialog");
							}
						},
						{
							text: "Create",
							click: function() {
								if (form.validation.validate("createPromoDialog form")) {
									ui.jWidget.showPopup($("#promoCodePopupContent").html());
									ui.jWidget.closeDialog("createPromoDialog");	
								}								
							}
						}
					],
					close: function() {
						form.validation.hide("createPromoDialog form")
					}
				});
			});
		}
	}	
});