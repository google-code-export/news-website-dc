/**
 * Lalaport Top Banner Plugin
 * http://toyosu.lalaport.jp/
 *
 * Copyright (c) 2011 DNP DigitalCom Co.,Ltd
 * http://www.dnp-digi.com/
 * ----------------------------------------------------------------------------------------------------
 * V001: 2011/07/14   CYBERSOFT\cuongqn    Create New
 * ----------------------------------------------------------------------------------------------------
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
				thumnailWidth: 158,
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
				// Add 'wait' for slider element
				elem.addClass("wait");
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
						});
						// Append sub elements
						elem.append(_thumbnailContainerElem);
						elem.append(_pointerElem);
						elem.append(_navigationPrevElem);
						elem.append(_navigationNextElem);
						// Remove 'wait' for out of element
						elem.removeClass("wait");
						// Apply animation events and effects to the banner
						$.fn.topBanner.animateBanner(elem, opts);					
					}, error: function(xhr, status, err) {
						// TODO: Handle error here whenever needed
					}
				});
			});
		}
	});
	// Configuration for banner effect
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
			title: $.trim($("title", item).text())
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
			// Get thumbnail width
			var thumbWidth = opts.thumnailWidth + opts.thumbnailMargin;
			// Get current pos of click event
			var currPos = Math.floor(thumbnails.eq(start).position().left / thumbWidth);
			// Define show banner function
			var showMainBanner = function() {
				// Get active thumbnail
				var thumb = $("." + opts.thumbnailClass + ".active:eq(0)");
				// Hide all main banners
				mainBanners.hide();
				// Show the one that matched
				var match = $("img." + opts.mainBannerClass + "[match=" + thumb.attr("match") + "]:eq(0)", elem);
				match.show();
				// Remove all 'active' class
				mainBanners.removeClass("active");
				// Add 'active' to the matched
				match.addClass("active");
			};
			// Define fade in banner function
			var fadeInMainBanner = function() {
				// Get active thumbnail
				var thumb = $("." + opts.thumbnailClass + ".active:eq(0)");
				// Get pointer
				var pointer = $("#" + opts.pointerId);
				pointer.hide();
				// Hide all main banners
				mainBanners.hide();
				// Show the one that matched
				var match = $("img." + opts.mainBannerClass + "[match=" + thumb.attr("match") + "]:eq(0)", elem);
				match.show();
				// Set its opacity to 10% to create the effect
				match.css({ "opacity": 0.1 });
				// Fade in and add 'active' class to the main banner that match with this thumbnail
				// show out at the same time the sliding effect finish
				match.stop().animate({ "opacity": 1 }, stts.fadeInSpeed, function() {
					mainBanners.removeClass("active");
					$(this).addClass("active");
					pointer.fadeIn(stts.fadeInSpeed);
				});
			}
			if (thumbnails.size() > numOfView) {				
				// Get number of thumbnails
				var numOfThumb = thumbnails.size();
				// Get 1 or more additional thumbs for sliding purpose
				start -= currPos;
				if (start < 0) {
					start = numOfThumb + start;
				}
				// Indicate the start over pointer
				var startOver = start;
				
				$("." + opts.thumbnailClass + ".clone").remove();
				
				// Loop over to get viewed thumbs
				var viewArr = new Array();
				for (var i = 0; i < numOfView + currPos * 2; i++) {					
					if (start > numOfThumb - 1) {
						start = 0;
					}
					if (i > 0 && start == startOver) {
						var cloneThumb = thumbnails.eq(start).clone();
						cloneThumb.addClass("clone");
						cloneThumb.css({ "border": "1px solid #ff0000" });
						$("#" + opts.thumbnailContainerId).append(cloneThumb);
						viewArr.push(cloneThumb);
						numOfThumb++;
						startOver++;
					} else {
						viewArr.push(thumbnails.eq(start));
					}
					start++;
				}
				// Hide all other thumbs
				thumbnails.hide();
				for (var i = 0; i < viewArr.length; i++) {
					var currThumb = viewArr[i];
					// Show only viewed thumbs
					currThumb.show();
					// User chose to go previous
					if (goPrevious) {
						currThumb.css({ "left": thumbWidth * (i - 2) });
						currThumb.stop().animate({ "left": thumbWidth * (i - 1) }, stts.slideSpeed);
						// Fade in the main banner
						fadeInMainBanner();
					} else {
						// Check if user click on active thumbnail
						if (currPos > 0) {
							// Create the effect by moving the thumbnails to the left then to the right
							currThumb.css({ "left": thumbWidth * i });
							currThumb.stop().animate({ "left": thumbWidth * (i - currPos) }, stts.slideSpeed);
							// Fade in the main banner
							fadeInMainBanner();
						} else {
							// Fix the thumbnails to the right
							currThumb.css({ "left": thumbWidth * (i - currPos) });
							// Show the main banner
							showMainBanner();
						}
					}
				}
				// Set pointer position
				$("#" + opts.pointerId).css({ "left": thumbWidth / 2 + 15 });
			} else {
				// Position the thumbnails
				thumbnails.each(function(i) {
					$(this).css({ "left": thumbWidth * i + "px" });
					if ($(this).hasClass("active")) {
						// Set pointer position
						$("#" + opts.pointerId).css({ "left": $(this).position().left + opts.thumnailWidth / 2 + 15 });
					}
				});	
				// Fade in the main banner
				fadeInMainBanner();
			}
			// Reset flag
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
				// Remove all 'active' class on all thumbnails and add again to itself
				thumbnails.removeClass("active");
				$(this).addClass("active");				
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
				// Slide to next thumb
				slideCyclic(i, 4);
				// Automate the effect
				if (timeout != null) {
					timeout = clearTimeout(timeout);
				}
				timeout = setTimeout(function() {
					//slideTo(i + 1);
				}, $(this).attr("itv"));				
			});
		});
		// Start the banner effect with the indexed thumbnail
		slideTo(opts.startIndex);
	};
})(jQuery);