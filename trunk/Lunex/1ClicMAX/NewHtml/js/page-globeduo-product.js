$(function() {	
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTooltips();
	ui.jWidget.setupOpenClose();
	form.mask.setupMaskMany([
		{ form: "phoneInputForm" },
		{ form: "newAccountForm" },
		{ form: "customerInfoForm" },
		{ form: "paymentMethodForm" }
	]);
	form.validation.setupMany([
		{ form: "phoneInputForm", option: { binded: false } },
		{ form: "newAccountForm", option: { binded: false } },
		{ form: "customerInfoForm" },
		{ form: "paymentMethodForm" },
		{ form: "securityForm", option: { scroll: false } }
	]);
		
	pages.globeDuo.slidePrintDropDown();
	pages.globeDuo.newAccountForm.setupPaymentMethod();
	
	pages.globeDuo.myAccount.changeCustomerInfoMode();
	pages.globeDuo.myAccount.changePaymentMethodMode();
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	globeDuo: {
		slidePrintDropDown: function() {
			$("#globeDuoProductPage .print-feature").hover(function() {
				$(this).find(".dropdown").not(":visible").slideDown("fast");
			},
			function() {
				$(this).find(".dropdown").slideUp("fast");	
			});
		},
		_setupPaymentMethod: function(payments, creditForm) {
			var checkPayments = function(autoScroll) {
				var chosenPayment = payments.filter(":checked").val();
				if (chosenPayment == "credit") {
					creditForm.slideDown("fast", function() {
						if (autoScroll) {
							creditForm.find("select:first").focus();
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
			payments.unbind("change").change(function() {
				checkPayments(true);
			});
		},
		newAccountForm: {
			setupPaymentMethod: function() {
				pages.globeDuo._setupPaymentMethod(
					$("#newAccountForm #paymentMethod :radio[name=payment]"),
					$("#newAccountForm #creditCard")
				);
			}	
		},
		myAccount: {
			changeCustomerInfoMode: function() {
				var formElem = $("#customerInfoForm");
				$("#customerInfoForm .cmd .edit-button").click(function() {
					// TODO: Add your code here                 
					pages.globeDuo.myAccount._switchMode(formElem, true);
                });				
				$("#customerInfoForm .cmd .save-button").click(function() {
					// TODO: Add your code here
					if (formElem.validationEngine("validate")) {
						pages.globeDuo.myAccount._switchMode(formElem);	
					}					
                });
				$("#customerInfoForm .cmd .cancel-button").click(function() {
					// TODO: Add your code here                
					pages.globeDuo.myAccount._switchMode(formElem);
                });
			},
			changePaymentMethodMode: function() {
				var formElem = $("#paymentMethodForm");
				$("#paymentMethodForm .cmd .edit-button").click(function() {
					// TODO: Add your code here                 
					pages.globeDuo.myAccount._switchMode(formElem, true, function() {
						pages.globeDuo.myAccount.setupPaymentMethod();
						$("#paymentMethod").show();
						$("#paymentLabel, #paymentCcLabel").hide();
					});					
                });		
				$("#paymentMethodForm .cmd .update-button").click(function() {
					// TODO: Add your code here
					pages.globeDuo.myAccount._switchMode(formElem, true, function() {
						pages.globeDuo.myAccount.setupPaymentMethod();
						$("#paymentMethod").hide();
						$("#paymentLabel, #paymentCcLabel").show();
					});					
                });			
				$("#paymentMethodForm .cmd .save-button").click(function() {
					// TODO: Add your code here                    
					if (formElem.validationEngine("validate")) {
						pages.globeDuo.myAccount._switchMode(formElem);
						$("#paymentLabel, #paymentCcLabel").show();
					}
                });
				$("#paymentMethodForm .cmd .cancel-button").click(function() {
					// TODO: Add your code here                
					pages.globeDuo.myAccount._switchMode(formElem);
					$("#paymentLabel, #paymentCcLabel").show();
                });
			},
			setupPaymentMethod: function() {
				pages.globeDuo._setupPaymentMethod(
					$("#paymentMethodForm #paymentMethod :radio[name=payment]"),
					$("#paymentMethodForm #creditCard")
				);
			},
			_switchMode: function(formElem, secured, callback) {
				var switchFormMode = function() {
					var panel = formElem.parents(".product-panel");
					if (panel.hasClass(ui.clazz.collapsed)) {
						panel.find(".content").slideDown("fast", function() {
							panel.removeClass(ui.clazz.collapsed);
							formElem.find(".mode1, .mode2").toggle();
							formElem.find("input[type=tel], select").focus();
							ui.layout.dockFooter();
						});
					} else {
						formElem.find(".mode1, .mode2").toggle();
						formElem.find("input[type=tel], select").first().focus();
						ui.layout.dockFooter();
					}
					formElem.validationEngine('hideAll');
					formElem.toggleClass("edit-mode");
				};
				if (secured) {
					ui.jWidget.showDialog("securityDialog", {
						width: 560,
						buttons: [
							{
								text: "Resend Security Code to Customer",
								title: "Send text message with security code to customer",
								class: "sub-button",
								click: function() {								
									ui.jWidget.alert("Security code sent successfully", "Attention");
								}
							},
							{
								text: "Unlock",
								click: function() {
									if (form.validation.validate("securityForm")) {
										switchFormMode();										
										ui.jWidget.closeDialog("securityDialog");
										if (callback) { callback(); }
									}
								}
							}						
						],
						open: function() {
							$(this).find(":text:first").val("");
						}
					});
				}
				else {
					switchFormMode();
				}		
			}
		}
	}
});