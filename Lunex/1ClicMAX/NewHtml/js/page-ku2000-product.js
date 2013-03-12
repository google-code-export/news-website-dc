$(function() {	
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTooltips();
	ui.jWidget.setupOpenClose();
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
	
	pages.ku2000.myAccount.changeCustomerInfoMode();
	pages.ku2000.myAccount.changeSmartNumbersMode();
	pages.ku2000.myAccount.changePaymentMethodMode();
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
							ui.layout.dockFooter();
						});
					} else {
						creditForm.slideUp("fast", function() {
							ui.layout.dockFooter();
						});
					}
					ui.layout.dockFooter();
				};
				checkPayments();
				payments.click(function() {
                    checkPayments(true);
                });
			}	
		},
		myAccount: {
			changeCustomerInfoMode: function() {
				var form = $("#customerInfoForm");
				$("#customerInfoForm .cmd .edit-button").click(function() {
					// TODO: Add your code here                 
					pages.ku2000.myAccount._switchMode(form);
                });				
				$("#customerInfoForm .cmd .save-button").click(function() {
					// TODO: Add your code here                    
					pages.ku2000.myAccount._switchMode(form);
                });
				$("#customerInfoForm .cmd .cancel-button").click(function() {
					// TODO: Add your code here                
					pages.ku2000.myAccount._switchMode(form);
                });
			},
			changeSmartNumbersMode: function() {
				var form = $("#smartNumbersForm");
				$("#smartNumbersForm .cmd .edit-button").click(function() {
					// TODO: Add your code here                 
					pages.ku2000.myAccount._switchMode(form);
                });				
				$("#smartNumbersForm .cmd .save-button").click(function() {
					// TODO: Add your code here                    
					pages.ku2000.myAccount._switchMode(form);
                });
				$("#smartNumbersForm .cmd .cancel-button").click(function() {
					// TODO: Add your code here                
					pages.ku2000.myAccount._switchMode(form);
                });
			},
			changePaymentMethodMode: function() {
				var form = $("#paymentMethodForm");
				$("#paymentMethodForm .cmd .edit-button").click(function() {
					// TODO: Add your code here                 
					pages.ku2000.myAccount._switchMode(form);
                });				
				$("#paymentMethodForm .cmd .save-button").click(function() {
					// TODO: Add your code here                    
					pages.ku2000.myAccount._switchMode(form);
                });
				$("#paymentMethodForm .cmd .cancel-button").click(function() {
					// TODO: Add your code here                
					pages.ku2000.myAccount._switchMode(form);
                });
			},
			_switchMode: function(form) {				
				var panel = form.parents(".product-panel");
				if (panel.hasClass(ui.clazz.collapsed)) {
					panel.find(".content").slideDown("fast", function() {
						panel.removeClass(ui.clazz.collapsed);
						form.find(".mode1, .mode2").toggle();
						form.first("input, select").focus();
						ui.layout.dockFooter();
					});
				} else {
					form.find(".mode1, .mode2").toggle();
					form.first("input, select").focus();
					ui.layout.dockFooter();
				}
				form.toggleClass("edit-mode");
			}
		}
	}
});