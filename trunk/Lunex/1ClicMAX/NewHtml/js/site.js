// Avoid `console` errors in browsers that lack a console.
(function() {
    var method;
    var noop = function () {};
    var methods = [
        'assert', 'clear', 'count', 'debug', 'dir', 'dirxml', 'error',
        'exception', 'group', 'groupCollapsed', 'groupEnd', 'info', 'log',
        'markTimeline', 'profile', 'profileEnd', 'table', 'time', 'timeEnd',
        'timeStamp', 'trace', 'warn'
    ];
    var length = methods.length;
    var console = (window.console = window.console || {});

    while (length--) {
        method = methods[length];

        // Only stub undefined methods.
        if (!console[method]) {
            console[method] = noop;
        }
    }
}());

/* Core */
/* --------------------------------------------------------------------------- */
var settings = {
	date: {
		dateFormat: "{yyyy}/{MM}/{dd}"
	},
	effect: {
		speed: {
			fast: 100,
			medium: 400,
			slow: 800	
		}
	}
};

/* Util helper features */
/* --------------------------------------------------------------------------- */
var util = {
	string: {
		createUUID: function() {
			// http://www.ietf.org/rfc/rfc4122.txt
			var s = [];
			var hexDigits = "0123456789abcdef";
			for (var i = 0; i < 36; i++) {
				s[i] = hexDigits.substr(Math.floor(Math.random() * 0x10), 1);
			}
			s[14] = "4";  // bits 12-15 of the time_hi_and_version field to 0010
			s[19] = hexDigits.substr((s[19] & 0x3) | 0x8, 1);  // bits 6-7 of the clock_seq_hi_and_reserved to 01
			s[8] = s[13] = s[18] = s[23] = "-";
		
			var uuid = s.join("");
			return uuid;
		}
	},
	number: {
		randomFromTo: function(from, to){
		   return Math.floor(Math.random() * (to - from + 1) + from);
		}	
	},
	date: {
		getTodayDateString: function() {
			return Date.create().format(settings.date.dateFormat);
		},
		getRewindDateString: function(dateObj) {
			return Date.create().rewind(dateObj).format(settings.date.dateFormat);
		}
	},
	array: {
		fromCsv: function(csvStr) {
			if ($.trim(csvStr) == "") {
				return [];	
			}
			var arr = [];
			var rawArr = csvStr.split(",");
			for (i = 0; i < rawArr.length; i++) {
				arr.push({ value: rawArr[i] });
			}
			return arr;
		}	
	},
	object: {
		exists: function(obj) {
			return obj != undefined && obj != null;
		}	
	},
	html: {
		getJqueryIdSelector: function(selector) {
			if (selector.substring(0,1) != "#") {
				selector = "#" + selector;
			}
			return selector;
		}
	}
};

/* UI helper features */
/* --------------------------------------------------------------------------- */
var ui = {
	clazz: {
		active: "active",
		focused: "focused",
		selected: "selected",
		collapsed: "collapsed",
		expanded: "expanded",
		docked: "docked"
	},
	layout: {
		slideAccountDropDown: function() {
			var dropDown = $("#header .hcnt .account-log .dropdown");
			$("#header .hcnt .account-log").hover(function() {
				dropDown.not(":visible").slideDown("fast");
			},
			function() {
				dropDown.slideUp("fast");
			});
		},
		dockFooter: function() {
			var autoDock = function() {
				var windowH = $(window).height();
				var headerH = $("#header").outerHeight(true);				
				var contentH = $(".site-content").outerHeight(true);
				var footerH = $("#footer").outerHeight(true);
				if (headerH + contentH + footerH < windowH) {
					$("#footer").addClass(ui.clazz.docked);
				} else {
					$("#footer").removeClass(ui.clazz.docked);	
				}
			};
			autoDock();
			$(window).resize(function() {
                autoDock();
            });
		}
	},
	jWidget: {
		// Required:
		// jquery.ui.core.min.js
		// jquery.ui.selectmenu.min.js
		setupDropDownLists: function() {
			$("select").each(function () {
				$(this).selectmenu({
					width: $(this).width() + 27 + "px",
					menuWidth:  $(this).width() + 25 + "px"
				});
				$(this).next(".ui-selectmenu").addClass("select");
				$(this).next(".ui-selectmenu").find(".ui-selectmenu-status").addClass("select-item");
				$(this).next(".ui-selectmenu").removeClass("ui-state-default").removeClass("ui-state-active");
			});	
		},
		// Required:
		// jquery.ui.core.min.js
		// jquery.ui.datepicker.min.js
		setupDatePickers: function() {
			var dateInputs = $(".date-input");			
			if (dateInputs.datepicker) {
				dateInputs.each(function(i) {
					var wrapper = $("<div>", { "class": "input-wrapper" });
					var picker = $("<a>", {
						"href": "#",
						"class": "button-picker ui-icon ui-icon-calendar"
					});
					$(this).wrap(wrapper).after(picker);
				});
				dateInputs.datepicker({
					dateFormat: "yy/mm/dd",
					constrainInput: true,
					showOn: "both",
					showAnim: "slideDown",
					showOtherMonths: true
				});
				$(".ui-datepicker-trigger").hide();
				dateInputs.siblings(".button-picker").click(function() {
					$(this).prev(".ui-datepicker-trigger").click();
				});
			}			
		},
		// Required:
		// jquery.ui.core.min.js
		// jquery.ui.button.min.js
		setupButtons: function() {
			// Don't do anything if missing jQuery UI Buttons
			if (!$(":button").button) {
				return;	
			}
			// Common buttons
			$(":button, :submit, :reset, .button").not(".gray-button").button();
			// Iconic buttons with text
			$(".button-save").button({
				icons: {
					primary: "ui-icon-disk"
				}
			});
			$(".button-add").button({
				icons: {
					primary: "ui-icon-plusthick"
				}
			});
			$(".button-update").button({
				icons: {
					primary: "ui-icon-pencil"
				}
			});
			$(".button-delete").button({
				icons: {
					primary: "ui-icon-trash"
				}
			});
			$(".button-refresh").button({
				icons: {
					primary: "ui-icon-refresh"
				}
			});
			$(".button-history").button({
				icons: {
					primary: "ui-icon-clock"
				}
			});
			$(".button-request").button({
				icons: {
					primary: "ui-icon-flag"
				}
			});
			$(".button-ok").button({
				icons: {
					primary: "ui-icon-check"
				}
			});
			$(".button-cancel").button({
				icons: {
					primary: "ui-icon-cancel"
				}
			});
			$(".button-close").button({
				icons: {
					primary: "ui-icon-close"
				}
			});
			$(".button-send").button({
				icons: {
					primary: "ui-icon-arrowthick-1-e"
				}
			});
			$(".button-submit").button({
				icons: {
					primary: "ui-icon-arrowthick-1-e"
				}
			});
			$(".button-yes").button({
				icons: {
					primary: "ui-icon-circle-check"
				}
			});
			$(".button-no").button({
				icons: {
					primary: "ui-icon-circle-close"
				}
			});
			$(".button-search").button({
				icons: {
					primary: "ui-icon-search"
				}
			});
			$(".button-clear").button({
				icons: {
					primary: "ui-icon-minusthick"
				}
			});
			$(".button-import").button({
				icons: {
					primary: "ui-icon-arrowthickstop-1-e"
				}
			});
			$(".button-export").button({
				icons: {
					secondary: "ui-icon-arrowthickstop-1-e"
				}
			});
			// Icon-only buttons
			$(".button-icon-only").button("option", { text: false });
		},
		// Required:
		// jquery.ui.core.min.js
		setupNotifs: function() {
			ui.jWidget._loadNotifs();
		},
		// Required:
		// jquery.ui.core.min.js
		reloadNotifs: function() {
			ui.jWidget._loadNotifs(true);
		},
		// Required:
		// jquery.ui.core.min.js
		_loadNotifs: function(isReload) {
			// Notif parts
			var notif, notifClazz, notifText, notifInner, notifParaf, notifIcon;
			// Extra notif clazz
			var getNotifClazz = function(notif) {
				var clazz = ["", ""];
				if (notif.hasClass("notif-info")) {
					clazz[0] = " ui-state-highlight";
					clazz[1] = " ui-icon-info";
				}
				if (notif.hasClass("notif-warning")) {
					clazz[0] = " ui-state-highlight";
					clazz[1] = " ui-icon-alert";	
				}
				if (notif.hasClass("notif-error")) {
					clazz[0] = " ui-state-error";
					clazz[1] = " ui-icon-circle-close";
				}
				return clazz;
			};
			// Pass through each notif
			$(".notif").each(function() {
                // Create new elements
				notif = $(this);
				if (!isReload || !notif.hasClass("ui-widget")) {
					notifClazz = getNotifClazz(notif);
					notifText = $.trim(notif.text());
					notifInner = $("<div>", {
						"class": "ui-corner-all" + notifClazz[0]
					}).css({
						"padding": ".2em .7em"
					});
					notifParaf = $("<p>", {
						"text": notifText
					});
					notifIcon = $("<span>", {
						"class": "ui-icon" + notifClazz[1]
					}).css({
						"float": "left",
						"margin": ".2em .3em 0 0"
					});
					// Add to DOM
					notif.empty();
					notifParaf.prepend(notifIcon);
					notifInner.append(notifParaf);
					notif.append(notifInner).addClass("ui-widget");	
				}				
            });
		},
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.dialog.min.js
		setupDialogs: function() {
			$(".dialog").each(function() {
				$(this).dialog({
					autoOpen: false,
					minWidth: 400,
					width: $(this).width(),
					modal: true,
					resizable: false,
					show: {
						effect: "drop",
						duration: 200
					},
					hide: {
						effect: "drop",
						duration: 300
					},
					buttons: {
						// Default button
						"OK": function() {
							$(this).dialog("close")
						}
					}
				});
			});
			$(".dialog .dialog-close").click(function() {
				var targetDialog = $(this).closest(".dialog");
				ui.jWidget.closeDialog(targetDialog);
			});
			$(".dialog-trigger").on("click", function() {
				var dialogId = $(this).attr("data-dialog-id");
				ui.jWidget.showDialog(dialogId);
			});
			// Auto open a dialog if it is specified
			$(".dialog-trigger").each(function() {
				if ($(this).hasClass("auto-open")) {
					$(this).click();
				}
			});
		},
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.dialog.min.js
		showDialog: function(dialogId, option, callback) {
			var dialogId = util.html.getJqueryIdSelector(dialogId);
			var targetDialog = $(dialogId);
			// Do nothing if cannot find the target dialog
			if (targetDialog.size() == 0) {
				return false;
			}
			if (!option) { option = {};	}
			targetDialog.on("dialogopen", callback);
			targetDialog.dialog("option", option).dialog("open");			
		},
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.dialog.min.js
		showDialogs: function(dialogArr) {
			for (var i = 0; i < dialogArr.length; i++) {
				ui.jWidget.showDialog(
					dialogArr[i].dialog,
					dialogArr[i].option,
					dialogArr[i].callback
				);
			}
		},
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.dialog.min.js
		closeDialog: function(dialogId, callback)  {
			var dialogId = util.html.getJqueryIdSelector(dialogId);
			var targetDialog = $(dialogId);
			// Do nothing if cannot find the target dialog
			if (targetDialog.size() == 0) {
				return false;
			}
			targetDialog.on("dialogclose", callback);
			targetDialog.dialog("close");
		},
		closeDialogs: function(dialogArr) {
			for (var i = 0; i < dialogArr.length; i++) {
				ui.jWidget.closeDialog(
					dialogArr[i].dialog,
					dialogArr[i].callback
				);
			}
		},
		// Required:
		// jquery.ui.dialog.min.js
		checkDialogOpen: function(dialogId) {
			var dialogId = util.html.getJqueryIdSelector(dialogId);
			var targetDialog = $(dialogId);
			// Do nothing if cannot find the target dialog
			if (targetDialog.size() == 0) {
				return false;
			}
			return targetDialog.dialog("isOpen");
		},		
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.dialog.min.js
		adjustDialogPosition: function(targetDialog, useAnimation) {
			var _useAnimation = useAnimation || false;
			var positionObj = {
				"left": ($(window).width() - targetDialog.outerWidth()) / 2 + "px",
				"top": (($(window).height() - targetDialog.height()) / 2) + "px"
			};
			if (_useAnimation) {
				targetDialog.animate(positionObj, 250);
			} else {
				targetDialog.css(positionObj);
			}
		},
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.dialog.min.js
		setupPopup: function() {
			var popup = $("<div id=\"popup\" />");
			$(document.body).prepend(popup);
			popup.dialog({
				autoOpen: false,
				minWidth: 400,
				modal: true,
				resizable: false,
				show: {
					effect: "drop",
					duration: 400
				},
				hide: {
					effect: "drop",
					duration: 300
				},
				dialogClass: "popup"
			});
		},
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.dialog.min.js
		showPopup: function(htmlContent, option, onOpenCallback, onCloseCallback) {
			var _option =  {
				width: "auto",
				height: "auto"	
			};
			_option = $.extend(_option, option);			
			$("#popup.ui-dialog-content").html(htmlContent.replace("data-src", "src"));
			$("#popup").on("dialogopen", onOpenCallback).on("dialogclose", function() {
				$("#popup.ui-dialog-content").empty();
				if (onCloseCallback) {
					onCloseCallback()
				};
			});
			$("#popup").dialog("option", {
				width: _option.width,
				height: _option.height	
			}).dialog("open");
		},
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.button.min.js
		// jquery.ui.dialog.min.js
		setupShoutBoxes: function() {
			// Auto create buttons
			var buttonOk = $("<a>", {
				"href": "#",
				"class": "button-ok button-default shout-box-close",
				"text": "OK"
			});
			var buttonCancel = $("<a>", {
				"href": "#",
				"class": "button-cancel shout-box-close",
				"text": "Cancel"
			});
			var buttonYes = $("<a>", {
				"href": "#",
				"class": "button-yes button-default shout-box-close",
				"text": "Yes"
			});
			var buttonNo = $("<a>", {
				"href": "#",
				"class": "button-no shout-box-close",
				"text": "No"
			});
			// Auto create dialog content
			var dialogContent = $("<div>", {
				"class": "dialog-content"
			});			
			// Auto create dialog bottom bar
			var dialogBottom = $("<div>", {
				"class": "dialog-bottom align-right"
			});
			// Auto create alert box
			var alertBox = $("<div>", {
				"id": "alert-box",
				"class": "shout-box",
				"title": "Alert"
			});
			alertBox.append(dialogContent.clone())
				.append($("<hr/>"))
				.append(dialogBottom.clone());
			alertBox.find(".dialog-bottom").append(buttonOk.clone());
			// Auto create confirm box
			var confirmBox = $("<div>", {
				"id": "confirm-box",
				"class": "shout-box",
				"title": "Confirm"
			});
			confirmBox.append(dialogContent.clone())
				.append($("<hr/>"))
				.append(dialogBottom.clone());
			confirmBox.find(".dialog-bottom").append(buttonNo.clone())
				.append(buttonYes.clone());
			// Auto create prompt box
			var promptBox = $("<div>", {
				"id": "prompt-box",
				"class": "shout-box",
				"title": "Prompt"
			});
			var promptText = $("<p>", {
				"class": "prompt-text",
				"text": "Please enter value:"
			});
			var promptInput = $("<input>", {
				"class": "prompt-input",
				"type": "text",				
				"maxlength": 50
			}).css({
				"width": "100%"
			});
			promptBox.append(dialogContent.clone())
				.append($("<hr/>"))
				.append(dialogBottom.clone());
			promptBox.find(".dialog-content").append(promptText)
				.append(promptInput);
			promptBox.find(".dialog-bottom").append(buttonCancel.clone())
				.append(buttonOk.clone());
			// Prepend to document
			$(document.body).prepend(alertBox);
			$(document.body).prepend(confirmBox);
			$(document.body).prepend(promptBox);
			// Setup shout boxes as dialogs
			$(".shout-box").dialog({
				autoOpen: false,
				width: 400,
				minHeight: 100,
				modal: true,
				resizable: false
			});			
			// Setup shout box events
			$(".shout-box .shout-box-close").click(function() {				
				var targetDialog = $(this).closest(".shout-box");
				ui.jWidget.closeDialog(targetDialog);
			});
			$(".shout-box .button-ok").click(function() {
				$(this).closest(".shout-box").trigger("ok");
			});
			$(".shout-box .button-cancel").click(function() {
				$(this).closest(".shout-box").trigger("cancel");
			});
			$(".shout-box .button-yes").click(function() {
				$(this).closest(".shout-box").trigger("yes");
			});
			$(".shout-box .button-no").click(function() {
				$(this).closest(".shout-box").trigger("no");
			});
			ui.jWidget.setupButtons();
		},
		alert: function(text, title) {
			var alertBox = $("#alert-box");			
			alertBox.find(".dialog-content").html("<p>" + text + "</p>");
			if (title != undefined) {
				alertBox.closest(".ui-dialog").find(".ui-dialog-title").text(title);	
			}
			ui.jWidget.showDialog("alert-box");
		},
		confirm: function(text, title) {
			var confirmBox = $("#confirm-box");			
			confirmBox.find(".dialog-content").html("<p>" + text + "</p>");
			if (title != undefined) {
				confirmBox.closest(".ui-dialog").find(".ui-dialog-title").text(title);	
			}
			ui.jWidget.showDialog("confirm-box");
			confirmBox.find(".button-yes").focus();
			return confirmBox;
		},
		prompt: function(text, title, value) {
			var promptBox = $("#prompt-box");
			if (text != undefined) {
				promptBox.find(".prompt-text").text(text);
			}
			if (value != undefined) {
				promptBox.find(".prompt-input").val(value);
			}
			if (title != undefined) {
				promptBox.closest(".ui-dialog").find(".ui-dialog-title").text(title);	
			}
			promptBox.bind("ok", function() {
				promptBox.data("returnValue", promptBox.find(".prompt-input").val());
			})
			ui.jWidget.showDialog("prompt-box");
			promptBox.find(".button-ok").focus();
			return promptBox;
		}
	},
	element : {
		setupSharpLinks: function() {
			$("a[href^=#]").on("click", function() {
				return false;
			});
		}
	}	
};

/* Form helper features */
/* --------------------------------------------------------------------------- */
var form = {
	mask: {
		setupMaskOne: function(formId) {
			var formId = util.html.getJqueryIdSelector(formId);
			$(formId + " input[data-mask-type=us-phone]")
				.setMask({ mask: "999-999-9999" });
			$(formId + " input[data-mask-type=number]")
				.setMask({ mask: "9", type: "repeat" });
		},
		setupMaskMany: function(formArr) {
			for (var i = 0; i < formArr.length; i++) {
				form.mask.setupMaskOne(formArr[i].form);
			}
		}
	},
	// Required:
	// jquery.validationEngine.js
	validation: {
		setupOne: function(formId, option) {
			var formId = util.html.getJqueryIdSelector(formId);
			var _option = $.extend({
				showOneMessage: false,
				binded: true,
				maxErrorsPerField: 1
			}, option);
			$(formId).validationEngine(_option);
		},
		setupMany: function(formArr) {
			for (var i = 0; i < formArr.length; i++) {
				form.validation.setupOne(formArr[i].form, formArr[i].option);
			}
		},
		attach: function(formId, option) {
			var formId = util.html.getJqueryIdSelector(formId);
			$(formId).validationEngine("attach", option);
		},
		detach: function(formId) {
			var formId = util.html.getJqueryIdSelector(formId);
			$(formId).validationEngine("detach");
		},
		validate: function(elemId) {
			var elemId = util.html.getJqueryIdSelector(elemId);
			return $(elemId).validationEngine("validate");
		},
		showPrompt: function(elemId, promptText, type, promptPosition, showArrow) {
			var elemId = util.html.getJqueryIdSelector(elemId);
			return $(elemId).validationEngine("showPrompt", promptText, type, promptPosition, showArrow);
		},
		hide: function(elemId) {
			var elemId = util.html.getJqueryIdSelector(elemId);
			return $(elemId).validationEngine("hide");
		},
		hideAll: function(formId) {
			var formId = util.html.getJqueryIdSelector(formId);
			return $(formId).validationEngine("hideAll");
		},
		updatePromptsPosition: function(formId) {
			var formId = util.html.getJqueryIdSelector(formId);
			return $(formId).validationEngine("updatePromptsPosition");
		}
	}
};

/* Default Boostrap */
/* --------------------------------------------------------------------------- */
$(function() {
	ui.element.setupSharpLinks();
	ui.layout.slideAccountDropDown();
	ui.layout.dockFooter();
	ui.jWidget.setupButtons();
});