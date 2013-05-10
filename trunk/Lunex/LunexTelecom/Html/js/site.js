$(function() {
	ui.layout.setupPageScroll(600);
});

var ui = {
	layout: {
		setupPageScroll: function(speed) {
			var PageOffset = function(page) {
				this.start = $("#" + page).offset().top - 1;
				this.end = this.start + $("#" + page).outerHeight();
			};
			// Set extra padding to current section
			var setExtraPadding = function(target) {
				if ("#" + $(".page.current").attr("id") != target) {
					$(".page").removeClass("current");
					$(target).addClass("current");
				}
			};
			// At page load
			var menuBar = $("#pageMenuBar");
			var scrolltBtn = $("#scrollTopButton");
			var defaultTarget = window.location.hash;
			if (defaultTarget) {
				setExtraPadding(defaultTarget);
				menuBar.find(".menu[href^=" + defaultTarget + "]").addClass("selected");	
			}
			// Smooth link scroll
			menuBar.find(".menu[href^=#]").add("#home .menu[href^=#]").add(scrolltBtn).click(function(e) {
				e.preventDefault();
				var target = this.hash,
				$target = $(target);
				setExtraPadding(target);
				$("html, body").stop().animate({
					"scrollTop": $target.offset().top
				}, speed, "swing", function () {
					window.location.hash = target;
				});
				console.log('smooth!');
			});
			// Show/hide menu bar
			var toggleMenuBar = function() {
				if (menuBar.offset().top < $("#products").offset().top) {
					menuBar.fadeOut("fast");
				} else {
					menuBar.slideDown("fast").animate(
						{ opacity: .8 },
						{ queue: false, duration: "slow" }
					);
				}
			};
			// Set selected menu
			var selectPageMenu = function() {
				var menuBarOffet = menuBar.offset().top;				
				$(".page").each(function() {
                    var page = $(this).attr("id");
					if (page != "home") {
						var pageObjOffset = new PageOffset(page);
						if (menuBarOffet >= pageObjOffset.start && menuBarOffet < pageObjOffset.end) {
							var currentPage = $("#pageMenuBar .menu[href^=#" + page + "]");
							if (!currentPage.hasClass("selected")) {
								$("#pageMenuBar .menu[href^=#]").removeClass("selected");
								currentPage.addClass("selected").hide().fadeIn(200);
							}
						}	
					}
                });
			};
			// Position scrollTop button
			var posScrollTopButton = function() {
				// TODO: Code here
			};
			toggleMenuBar();
			posScrollTopButton();
			$(window).scroll(function() {
                toggleMenuBar();
				selectPageMenu();
				posScrollTopButton();			
            });
		}
	}
};