$(function() {
	ui.layout.setupPageScroll(600);
});

var ui = {
	layout: {
		setupPageScroll: function(speed) {
			// Set extra padding to current section
			var setExtraPadding = function(target) {
				if ("#" + $(".page.current").attr("id") != target) {
					$(".page").removeClass("current");
					$(target).addClass("current");
				}
			};
			// At page load
			var menuBar = $("#pageMenuBar");
			var defaultTarget = window.location.hash;
			if (defaultTarget) {
				setExtraPadding(defaultTarget);
				menuBar.find(".menu[href^=" + defaultTarget + "]").addClass("selected");	
			}
			// Smooth link scroll
			menuBar.find(".menu[href^=#]").click(function(e) {
				e.preventDefault();
				var target = this.hash,
				$target = $(target);
				setExtraPadding(target);
				$("html, body").stop().animate({
					"scrollTop": $target.offset().top
				}, speed, "swing", function () {
					window.location.hash = target;
				});
			});
			// Show/hide menu bar
			var toggleMenuBar = function() {
				if (menuBar.offset().top < $("#products").offset().top) {
					menuBar.fadeOut("fast");
				} else {
					menuBar.slideDown("fast").animate(
						{ opacity: .9 },
						{ queue: false, duration: "slow" }
					);
				}	
			};
			// Set selected menu
			var selectMenu = function() {
				if (menuBar.offset().top == $(".page").offset().top) {
					//$("#pageMenuBar .menu[href*=#]").removeClass("selected");
					//$menu.addClass("selected").hide().fadeIn(200);
					console.log("ring!!!!");
				}
			};
			toggleMenuBar();
			$(window).scroll(function() {
                toggleMenuBar();
				selectMenu();				
            });
		}
	}
};