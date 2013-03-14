$(function() {	
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTooltips();
	ui.jWidget.setupOpenClose();
	form.mask.setupMaskMany([
		{ form: "phoneInputForm" },
		{ form: "newAccountForm" },
		{ form: "customerInfoForm" },
		{ form: "smartNumbersForm" },
		{ form: "paymentMethodForm" }
	]);
	form.validation.setupMany([
		{ form: "phoneInputForm", option: { binded: false } },
		{ form: "newAccountForm", option: { binded: false } },
		{ form: "customerInfoForm" },
		{ form: "smartNumbersForm" },
		{ form: "paymentMethodForm" },
		{ form: "securityForm", option: { scroll: false } }
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
				pages.ku2000._setupPaymentMethod(
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
					pages.ku2000.myAccount._switchMode(formElem, true);
                });				
				$("#customerInfoForm .cmd .save-button").click(function() {
					// TODO: Add your code here
					if (formElem.validationEngine("validate")) {
						pages.ku2000.myAccount._switchMode(formElem);	
					}					
                });
				$("#customerInfoForm .cmd .cancel-button").click(function() {
					// TODO: Add your code here                
					pages.ku2000.myAccount._switchMode(formElem);
                });
			},
			changeSmartNumbersMode: function() {
				var formElem = $("#smartNumbersForm");
				$("#smartNumbersForm .cmd .edit-button").click(function() {
					// TODO: Add your code here                 
					pages.ku2000.myAccount._switchMode(formElem, true);
                });				
				$("#smartNumbersForm .cmd .save-button").click(function() {
					// TODO: Add your code here                    
					if (formElem.validationEngine("validate")) {
						pages.ku2000.myAccount._switchMode(formElem);	
					}
                });
				$("#smartNumbersForm .cmd .cancel-button").click(function() {
					// TODO: Add your code here                
					pages.ku2000.myAccount._switchMode(formElem);
                });
			},
			changePaymentMethodMode: function() {
				var formElem = $("#paymentMethodForm");
				$("#paymentMethodForm .cmd .edit-button").click(function() {
					// TODO: Add your code here                 
					pages.ku2000.myAccount._switchMode(formElem, true, function() {
						pages.ku2000.myAccount.setupPaymentMethod();
						$("#paymentMethod").show();
						$("#paymentLabel").hide();
					});					
                });		
				$("#paymentMethodForm .cmd .update-button").click(function() {
					// TODO: Add your code here
					pages.ku2000.myAccount._switchMode(formElem, true, function() {
						$("#paymentMethod").hide();
						$("#paymentLabel").show();
					});					
                });			
				$("#paymentMethodForm .cmd .save-button").click(function() {
					// TODO: Add your code here                    
					if (formElem.validationEngine("validate")) {
						pages.ku2000.myAccount._switchMode(formElem);
						$("#paymentLabel").show();
					}
                });
				$("#paymentMethodForm .cmd .cancel-button").click(function() {
					// TODO: Add your code here                
					pages.ku2000.myAccount._switchMode(formElem);
					$("#paymentLabel").show();
                });
			},
			setupPaymentMethod: function() {
				pages.ku2000._setupPaymentMethod(
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