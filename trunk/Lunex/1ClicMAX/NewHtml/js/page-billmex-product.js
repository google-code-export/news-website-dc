$(function() {
	ui.jWidget.setupDialogs();
	form.mask.setupMaskMany([
		{ form: "inputForm" }
	]);
	form.validation.setupMany([
		{ form: "inputForm", option: { binded: false } }
	]);

	pages.billMex.inputForm.setupFormEvents();
	pages.billMex.refineBillAmount();
	pages.billMex.slidePrintDropDown();
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	billMex: {
		inputForm: {
			setupFormEvents: function() {
				// Phone type
				var resetPhoneType = function() {
					$("#custInfo .child-options").hide();
					$("#custInfo :radio[name=phonetype]").removeAttr("checked").attr("disabled", "disabled");					
				};
				resetPhoneType();
				$("#custInfo :radio[name=phonetype]").change(function() {
					if ($(this).val() == "cell") {
						$("#custInfo .child-options").slideDown("fast");
					} else {
						$("#custInfo .child-options").slideUp("fast");
					}
				});
				// US Phone
				$("#usPhoneNo").keyup(function() {
					if ($(this).val().length == 12) {
						$("#custInfo :radio").removeAttr("disabled");
						$("#custInfo :radio[value=cell]").attr("checked", "checked").change();
						$("#sideBanner").addClass("hidden");
						$("#sideContent").removeClass("hidden");
						$("#custInfo2, #billComSection, #recipientInfoSection, #inputForm .xform-cmd").slideDown(200, function() {
							ui.layout.dockFooter();	
						});
					} else {
						resetPhoneType();
						$("#sideBanner").removeClass("hidden");
						$("#sideContent").addClass("hidden");
						$("#custInfo2, #billComSection, #recipientInfoSection, #inputForm .xform-cmd").hide();
						ui.layout.dockFooter();
					}
                });
				// Bill Company
				$("#company").change(function() {
					var comInfoInputs = $("#billCom li.sub input");
					var comInfoBullets = $("#billCom li.sub .bullet");
					var comInfoDesc = $("#billCom li.sub .field-des");
					var defWidth = 138;
					comInfoInputs.val("");
                    if ($(this).val() == "") {
						comInfoInputs.attr("disabled", "disabled");						
						comInfoBullets.removeClass(ui.clazz.active);
						comInfoDesc.addClass("hidden");
						comInfoInputs.filter(".acc-number").removeAttr("maxlength").css({ width: defWidth + "px" });
						// Hide Bill Sample
						$("#billSample h3 ul li:eq(1)").hide();
					} else {
						comInfoInputs.removeAttr("disabled");
						comInfoBullets.addClass(ui.clazz.active);
						comInfoDesc.removeClass("hidden");
						// Set length
						var digits = $(this).find(":selected").attr("data-digits");
						comInfoInputs.filter(".acc-number")
							.attr("maxlength", digits)
							.css({ width: (digits * 13.1) + 20 + "px" });
						// Set description
						var message = $(this).find(":selected").attr("data-desc");
						if (!message) {
							message = digits + " Digits";
						}
						comInfoDesc.filter(".acc-des").text(message);
						// Show Bill Sample
						$("#billSample h3 ul li:eq(1)").show();
						$("#billSample h3").text($(this).find(":selected").text());
						$("#billSample img").attr("src", "res/billmex/"
							+ $(this).find(":selected").attr("data-bill") + ".jpg");
						// Focus on first textbox
						comInfoInputs.eq(0).focus();
					}
                });
			}
		},
		refineBillAmount: function() {
			var minWidth = 0;
			var prices = $("#billMexProductPage .bill-amount .data");			
			prices.each(function() {
                if ($(this).width() > minWidth) {
					minWidth = $(this).width();	
				}
            });
			prices.css({ "min-width": minWidth + "px" });
		},
		slidePrintDropDown: function() {
			$("#billMexProductPage .print-feature").hover(function() {
				$(this).find(".dropdown").not(":visible").slideDown("fast");
			},
			function() {
				$(this).find(".dropdown").slideUp("fast");	
			});
		}
	}	
});