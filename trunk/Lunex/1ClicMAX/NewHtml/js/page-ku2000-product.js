$(function() {	
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTooltips();
	form.mask.setupMaskMany([
		{ form: "phoneInputForm" },
		{ form: "newAccountForm" }
	]);
	form.validation.setupMany([
		{ form: "phoneInputForm", option: { binded: false } },
		{ form: "newAccountForm", option: { binded: false } }
	]);
		
	pages.ku2000.slidePrintDropDown();
	pages.ku2000.newAccountForm.setupPaymentMethod();
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	ku2000: {
		slidePrintDropDown: function() {
			$("#ku2000ProductPage .print-feature").hover(function() {
				$(this).find(".dropdown").not(":visible").slideDown("fast");
			},
			function() {
				$(this).find(".dropdown").slideUp("fast");	
			});
		},
		newAccountForm: {
			setupPaymentMethod: function() {
				var payments = $("#paymentMethod :radio[name=payment]");
				var creditForm = $("#creditCard");
				var checkPayments = function(autoScroll) {
					var chosenPayment = payments.filter(":checked").val();
					if (chosenPayment == "credit") {
						creditForm.slideDown("fast", function() {
							if (autoScroll) {
								$("#creditCard select:first").focus();
								$(window).scrollTop(creditForm.position().top);		
							}
						});
					} else {
						creditForm.slideUp("fast");
					}
				};
				checkPayments();
				payments.click(function() {
                    checkPayments(true);
                });
			}	
		}
	}
});