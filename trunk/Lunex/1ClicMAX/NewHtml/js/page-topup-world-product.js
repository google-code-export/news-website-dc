$(function() {
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTvAds();
	ui.jWidget.setupTooltips();
	form.mask.setupMaskMany([
		{ form: "topupForm" },
		{ form: "creditCardForm" }
	]);
	form.validation.setupMany([
		{ form: "topupForm", option: { binded: false } },
		{ form: "creditCardForm", option: { promptPosition: "topLeft", scroll: false } }
	]);

	pages.topUpWorld.topupForm.setupFormEvents();
	pages.topUpWorld.slidePrintDropDown();
	pages.topUpWorld.runLogosSlider();
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	topUpWorld: {
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
				// Country
				
				// Credit Card
				$("#topupForm").submit(function(e) {
                    var payment = $(this).find(":radio[name=payment]:checked").val();
					if (payment == "credit" && form.validation.validate("topupForm")) {
						ui.jWidget.showDialog("creditCardDialog", {
							width: 600,
							buttons: [
								{
									text: "Submit",
									click: function() {
										form.validation.hide("creditCardForm");
										if (form.validation.validate("creditCardForm")) {
											ui.jWidget.closeDialog("creditCardDialog");
										}
									}
								}
							],
							open: function() {
								var ccExtra = $(this).find(".cc-extra");
								var ccForm = $(this).find(".cc-form");
								ccForm.next(".cc-terms").appendTo($(this).next(".ui-dialog-buttonpane"));
								ccExtra.find(".action :radio").unbind("change").change(function() {
									if ($(this).val() == "new") {
										ccForm.find(".cc-list").slideUp(100, function() {
											ccForm.find(".cc-number").removeAttr("readonly").removeClass("read-only");
											$(".cc-save").show();
											form.validation.hide("creditCardForm");
										});
									} else {
										ccForm.find(".cc-list").slideDown(100, function() {
											ccForm.find(".cc-number").attr("readonly", "readonly").addClass("read-only");
											$(".cc-save").hide();
											form.validation.hide("creditCardForm");
										});
									}
								});
								ccExtra.find(".action span.default :radio").attr("checked", "checked").change();
							}
						});
						return false; // TODO: Remove and apply code
					}
                });
			}	
		},
		slidePrintDropDown: function() {
			$("#topupWorldProductPage .print-feature").hover(function() {
				$(this).find(".dropdown").not(":visible").slideDown("fast");
			},
			function() {
				$(this).find(".dropdown").slideUp("fast");	
			});
		},
		runLogosSlider: function() {
			var slides = $("#topupWorldProductPage .topup-logos li");
			var counter = 1;
			var runner = function() {
				slides.hide().removeClass("active");
				slides.eq(counter).fadeIn(800, function() {
					$(this).addClass("active");	
				})
				if (counter == slides.size() - 1) {
					counter = 0;	
				} else {
					counter++;	
				}
			};
			var itv = window.setInterval(function() {
				runner();
			}, 5000);
		}
	}	
});