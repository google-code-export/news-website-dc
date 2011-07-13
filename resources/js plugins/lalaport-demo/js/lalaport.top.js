/*!
 * Lalaport Top Banner Plugin
 * http://toyosu.lalaport.jp/
 *
 * Copyright (c) 2011 Global CyberSoft (Vietnam)
 * http://www.globalcybersoft.com/
 *
 * Date: 2009-07-11 (Mon, 11 Jul 2011)
 */
(function($) {	
	$.fn.extend({
		topBanner: function(options) {
			// Set default options
			var defaults = {
				xmlPath: "top.xml",
				mainBannerClass: "main-banner",
				thumbnailContainerId: "thumbBanners",
				thumbnailClass: "thumb-banner",
				thumbnailMargin: 6,
				pointerId: "pointer",
				navigationPrevId: "navPrev",
				navigationNextId: "navNext",
				startIndex: 0,
				nextText: "Next",
				prevText: "Previous"
			};			
			var options = $.extend(defaults, options);
			
			return this.each(function() {
				// Redefine current options
				var opts = options;
				// Redefine current element
				var elem = $(this);
				// Define working elements
				// Define elements as functions so that they can return new instances
				var mainBannerElem = function() {
					return $("<img class='" + opts.mainBannerClass +"' border='0' />");
				};
				var thumbnailContainerElem = function() {
					return $("<div id='" + opts.thumbnailContainerId +"'>");
				};
				var thumbnailElem = function() {
					return $("<img class='" + opts.thumbnailClass + "' />");
				};
				var pointerElem = function() {
					return $("<div id='" + opts.pointerId +"'>");
				};
				var navigationPrevElem = function() {
					return $("<a id='" + opts.navigationPrevId
						+ "' href='javascript:void(0)' title='"
						+ opts.prevText + "'>" + opts.prevText + "</a>");
				};
				var navigationNextElem = function() {
					return $("<a id='" + opts.navigationNextId
						+ "' href='javascript:void(0)' title='"
						+ opts.nextText + "'>" + opts.nextText + "</a>");
				};
				// Get resource details from xml file
				$.ajax({
					type: "GET",
					url: opts.xmlPath,
					dataType: "xml",
					success: function(xml) {
						// Create sub elements
						var _thumbnailContainerElem = thumbnailContainerElem();
						var _pointerElem = pointerElem();
						var _navigationPrevElem = navigationPrevElem();
						var _navigationNextElem = navigationNextElem();
						// Browser all items within xml file
						$("item", xml).each(function(i) {
							var bannerItem = $.fn.topBanner.bannerItem(this);
							if (bannerItem.visible) {
								// Create main figure elements
								var _mainBannerElem = mainBannerElem();								
								_mainBannerElem.attr("src", bannerItem.mainPath);
								_mainBannerElem.attr("alt", bannerItem.title);
								_mainBannerElem.attr("match", "item" + i);
								// Wrap main figure elements into appropriate links if the url is NOT blank
								if (bannerItem.url != "") {
									var _mainBannerLinkElem = $("<a href='" + bannerItem.url + "' title='"
										+ bannerItem.title + "' target='" + bannerItem.target + "' />");								
									elem.append(_mainBannerLinkElem);
									_mainBannerLinkElem.append(_mainBannerElem);
								} else {
									elem.append(_mainBannerElem);
								}
								// Create and append thumbnail elements
								var _thumbnailElem = thumbnailElem();
								_thumbnailElem.attr("src", bannerItem.thumbnailPath);
								_thumbnailElem.attr("alt", bannerItem.title);
								_thumbnailElem.attr("match", "item" + i);
								_thumbnailElem.attr("itv", bannerItem.time * 1000);
								_thumbnailContainerElem.append(_thumbnailElem);
							}
						});
						// Append sub elements
						elem.append(_thumbnailContainerElem);
						elem.append(_pointerElem);
						elem.append(_navigationPrevElem);
						elem.append(_navigationNextElem);
						// Apply animation events and effects to the banner
						$.fn.topBanner.animateBanner(elem, opts);
					}, error: function(ex) {
						elem.append("<p style='color:#ff0000;text-align:center'><b>Error getting xml document!</b></p>");
					}
				});
			});
		}
	});
	$.fn.topBanner.settings = {
		fadeInSpeed: 200,
		slideSpeed: 500,
		hoverOpacity: 0.7
	};
	// Get banner object
	$.fn.topBanner.bannerItem = function(item) {
		var obj = {
			mainPath: $.trim($("main_path", item).text()),
			thumbnailPath: $.trim($("thumbnail_path", item).text()),
			url: $.trim($("url", item).text()),
			target: $.trim($("target", item).text()),
			time: $.trim($("time", item).text()),
			title: $.trim($("title", item).text()),
			start: $.trim($("start", item).text()),
			end: $.trim($("end", item).text()),
			visible: $.trim($("visible", item).text())
		};
		// Remove leading slash '/'
		if (obj.mainPath.substring(0,1) == "/") {
			obj.mainPath = obj.mainPath.substring(1, obj.mainPath.length);
		}
		if (obj.thumbnailPath.substring(0,1) == "/") {
			obj.thumbnailPath = obj.thumbnailPath.substring(1, obj.thumbnailPath.length);
		}
		if (obj.url.substring(0,1) == "/") {
			obj.url = obj.url.substring(1, obj.url.length);
		}
		return obj;
	};
	// Apply animation events and effects to the banner
	$.fn.topBanner.animateBanner = function(element, options) {
		// Redefine ref element and options
		var elem = element;
		var opts = options;
		// Refine current settings
		var stts = $.fn.topBanner.settings;
		// Define main banners and thumbnails
		var mainBanners = $("img." + opts.mainBannerClass, elem);
		var thumbnails = $("img." + opts.thumbnailClass, elem);
		var thumbnailContainer = $("#" + opts.thumbnailContainerId);
		// Add hover effect to main banner items
		mainBanners.hover(function() {
			$(this).css({ "opacity": stts.hoverOpacity });
		}, function() {
			$(this).css({ "opacity": 1 });
		});				
		// Position the thumbnails
		//thumbnails.each(function(i) {
			//$(this).css({ "left": (($(this).width() + opts.thumbnailMargin) * i) + "px" });
		//});
		// Add events to each thumbnail
		thumbnails.click(function() {
			// Hide all main banners
			mainBanners.hide();
			// Remove all 'active' class on all thumbnails and add again to itself
			thumbnails.removeClass("active");
			$(this).addClass("active");
			// Fade in and add 'active' class to the main banner that match with this thumbnail
			// stts.fadeInSpeed + stts.slideSpeed: plus to slide speed so that the main banner can
			// show out at the same time the sliding effect finish
			$("img." + opts.mainBannerClass + "[match=" + $(this).attr("match") + "]:eq(0)", elem)
				.fadeIn(stts.fadeInSpeed + stts.slideSpeed, function() {
					mainBanners.removeClass("active");
					$(this).addClass("active");
				});
			// Add hover effect to thumbnail items
			thumbnails.hover(function() {
				$(this).css({ "opacity": stts.hoverOpacity });
				if ($(this).hasClass("active")) {
					$("#" + opts.pointerId).css({ "opacity": stts.hoverOpacity });
				}
			}, function() {
				$(this).css({ "opacity": 1 });
				$("#" + opts.pointerId).css({ "opacity": 1 });
			});				
		});
		// Define slide to index function
		var slideTo = function(index) {
			// Make the slide to event run in cycle
			index = index < 0 ? thumbnails.size() - 1 : index;
			index = index > thumbnails.size() - 1 ? 0 : index;
			// Go to the index
			thumbnails.eq(index).click();
		};		
		// Flag to check if user choose to view previous thumb
		var goPrevious = false;
		// Define slide with infinite loop
		var slideCyclic = function(start, numOfView) {
			if (thumbnails.size() > numOfView) {
				var viewArr = new Array();
				var thumbWidth = thumbnails.eq(0).width() + opts.thumbnailMargin;				
				// Get current pos of click event
				//var currPos = Math.floor(thumbnails.eq(start).position().left / thumbWidth);
				// Get 1 or more additional thumbs for sliding purpose			
				start -= 1;
				if (start < 0) {
					start = thumbnails.size() + start;
				}
				// Loop over to get viewed thumbs
				for (var i = 0; i < numOfView + 2; i++) {
					if (start > thumbnails.size() - 1) {
						start = 0;
					}
					viewArr.push(thumbnails.eq(start));
					start++;
				}
				// Hide all other thumbs
				thumbnails.hide();
				for (var i = 0; i < viewArr.length; i++) {
					// Show only viewed thumbs
					viewArr[i].show();
					// User chose to go previous
					if (goPrevious) {
						viewArr[i].css({ "left": thumbWidth * (i - 2) });
						viewArr[i].stop().animate({ "left": thumbWidth * (i - 1) }, stts.slideSpeed);
					} else {					
						viewArr[i].css({ "left": thumbWidth * i });
						viewArr[i].stop().animate({ "left": thumbWidth * (i - 1) }, stts.slideSpeed);
					}
				}
				// Set pointer position
				$("#" + opts.pointerId).css({ "left": thumbWidth / 2 + 15 });
			} else {
				// Position the thumbnails
				thumbnails.each(function(i) {
					$(this).css({ "left": (($(this).width() + opts.thumbnailMargin) * i) + "px" });
					if ($(this).hasClass("active")) {
						// Set pointer position
						$("#" + opts.pointerId).css({ "left": $(this).position().left + $(this).width() / 2 + 15 });
					}
				});				
			}
			//Reset flag
			goPrevious = false;
		};		
		// Define slide with absolute number function
		var slideAbs = function(abs) {
			thumbnails.each(function(i) {
				if ($(this).hasClass("active")) {
					slideTo(i + abs);
					return false;
				}
			});
		};		
		// Get navigation links work!
		$("#" + opts.navigationPrevId, elem).click(function() {
			goPrevious = true; slideAbs(-1);
		});
		$("#" + opts.navigationNextId, elem).click(function() {
			slideAbs(1);
		});
		// Start the Slide Show!!!
		var timeout;
		thumbnails.each(function(i) {
			$(this).click(function() {
				// Slide to next thumb
				slideCyclic(i, 4);
				if (timeout != null) {
					timeout = clearTimeout(timeout);
				}
				timeout = setTimeout(function() {
					slideTo(i + 1);
				}, $(this).attr("itv"));				
			});
		});
		// Start the banner effect with the indexed thumbnail
		slideTo(opts.startIndex);
	};
})(jQuery);