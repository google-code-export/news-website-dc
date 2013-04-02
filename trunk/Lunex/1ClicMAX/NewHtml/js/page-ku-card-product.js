$(function() {
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTvAds();
	ui.jWidget.setupTooltips();
	form.mask.setupMaskMany([
		{ form: "kuCardForm" },
		{ form: "creditCardForm" }
	]);
	form.validation.setupMany([
		{ form: "kuCardForm", option: { binded: false } },
		{ form: "creditCardForm", option: { promptPosition: "topLeft", scroll: false } }
	]);

	pages.kuCard.kuCardForm.setupFormEvents();
	pages.kuCard.kuCardForm.calculateTotalPrice();
	pages.kuCard.slidePrintDropDown();
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	kuCard: {
		kuCardForm: {
			setupFormEvents: function() {
				// Credit Card
				$("#kuCardForm").submit(function(e) {
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
			},
			calculateTotalPrice: function() {
				var calc = function() {
					var result = parseInt($("#amount").val()) * parseInt($("#quantity").val());
					$("#price").text("$" + result);
				};
				calc();
				$("#amount, #quantity").change(function() {
					calc();
				});
			}
		},
		slidePrintDropDown: function() {
			$("#kuCardProductPage .print-feature").hover(function() {
				$(this).find(".dropdown").not(":visible").slideDown("fast");
			},
			function() {
				$(this).find(".dropdown").slideUp("fast");	
			});
		}	
	}
});