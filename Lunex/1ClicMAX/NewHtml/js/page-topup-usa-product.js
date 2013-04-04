$(function() {
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTvAds();
	form.mask.setupMaskMany([
		{ form: "topupForm" }
	]);
	form.validation.setupMany([
		{ form: "topupForm", option: { binded: false } }
	]);

	pages.topUpUsa.topupForm.setupFormEvents();
	pages.topUpUsa.refineTopUpAmount();
	pages.topUpUsa.slidePrintDropDown();
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	topUpUsa: {
		topupForm: {
			setupFormEvents: function() {
				// Phone type
				var resetPhoneType = function() {
					$("#senderInfo .child-options").hide();
					$("#senderInfo :radio[name=phonetype]").removeAttr("checked").attr("disabled", "disabled");					
				};
				resetPhoneType();
				$("#senderInfo :radio[name=phonetype]").change(function() {
					if ($(this).val() == "cell") {
						$("#senderInfo .child-options").slideDown("fast");
					} else {
						$("#senderInfo .child-options").slideUp("fast");
					}
				});
				// US Phone
				$("#usPhoneNo").keypress(function() {
					var unmaskedVal = $(this).val().replace(/[-]/g, "");
                    if (unmaskedVal == "") {
						resetPhoneType();	
					}
                });
				// Else
				
			}
		},
		refineTopUpAmount: function() {
			var minWidth = 0;
			var prices = $("#topupUsaProductPage .topup-amount .data");
			prices.each(function() {
                if ($(this).width() > minWidth) {
					minWidth = $(this).width();	
				}
            });
			prices.css({ "min-width": minWidth + "px" });
		},
		slidePrintDropDown: function() {
			$("#topupUsaProductPage .print-feature").hover(function() {
				$(this).find(".dropdown").not(":visible").slideDown("fast");
			},
			function() {
				$(this).find(".dropdown").slideUp("fast");	
			});
		}
	}	
});