$(function() {
	ui.jWidget.setupNotifs();
	ui.jWidget.setupDialogs();
	form.validation.setupOne("loginForm");
	
	pages.login.setupSlider();
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	login: {
		setupSlider: function() {
			var activeCls = "active";
			var sliders = $("#loginPage .advertise .slider-wrapper .slider li");
			//var trackers = $("#loginPage .advertise .slider-wrapper .slider-trackers a");
			var contents = $("#loginPage .advertise .slider-content");
			var tmo = null;
			var gotoSlide = function(index) {
				tmo = window.clearTimeout(tmo);
				sliders.hide().removeClass(activeCls);
				contents.hide().removeClass(activeCls);
				//trackers.removeClass(activeCls);
				sliders.eq(index).fadeIn(500, function() {
					sliders.eq(index).addClass(activeCls);
				});
				contents.eq(index).fadeIn(500, function() {
					contents.eq(index).addClass(activeCls);
				});
				//trackers.eq(index).addClass(activeCls);
			};
			var goNext = function() {
				sliders.each(function(index) {
					if ($(this).hasClass(activeCls)) {
						var nextIndex = index + 1;
						if (nextIndex > sliders.size() - 1) {
							nextIndex = 0;
						}
						gotoSlide(nextIndex);
					}
				});
			};
			var autoRun = function() {
				tmo = window.setTimeout(function() {
					goNext();
					autoRun();
				}, 10000);
			};
			/*trackers.each(function(index) {
				$(this).click(function() {
					gotoSlide(index);
					autoRun();
					return false;
				});
			});*/
			autoRun();
		}
	}	
});