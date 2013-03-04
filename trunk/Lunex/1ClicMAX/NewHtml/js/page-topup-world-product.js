$(function() {
	ui.jWidget.setupDialogs();
	form.mask.setupMaskMany([
		{ form: "topupForm" }
	]);
	form.validation.setupMany([
		{ form: "topupForm" }
	]);

	pages.topUpWorld.topupForm.setupFormEvents();
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
				$("#senderInfo :radio[name=phonetype]").click(function() {
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
				
			}	
		},
		runLogosSlider: function() {
			var slides = $("#content .topup-logos li");
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