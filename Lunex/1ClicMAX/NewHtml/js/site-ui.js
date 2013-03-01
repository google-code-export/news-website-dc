// UI helper features
var ui = {
	clazz: {
		active: "active",
		focused: "focused",
		selected: "selected",
		collapsed: "collapsed",
		expanded: "expanded",
		docked: "docked",
		hCenter: "h-center",
		autoCenter: "auto-center"
	},
	layout: {
		centerContent: function() {
			if (!$("#content").hasClass(ui.clazz.autoCenter)) {
				return;
			}
			var autoCenter = function() {
				var windowH = $(window).height();
				var windowW = $(window).width();
				var headerH = $("#header").outerHeight(true);
				var contentH = $("#content").outerHeight(true);
				if (headerH + contentH < windowH) {
					$("#content").addClass(ui.clazz.hCenter);
				} else {
					$("#content").removeClass(ui.clazz.hCenter);	
				}
				$("#content").css({
					top: (windowH - contentH) / 2 + "px",
					left: (windowW - 1000) / 2 + "px"
				});
			}
			autoCenter();
			$(window).resize(function() {
                autoCenter();
            });
		},
		dockFooter: function() {
			var autoDock = function() {
				var windowH = $(window).height();
				var headerH = $("#header").outerHeight(true);
				var contentH = $("#content").outerHeight(true);
				if (headerH + contentH < windowH) {
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
			$(":button, :submit, :reset, .button").button();
			// Iconic buttons with text
			$(".button-login").button({
				icons: {
					primary: "ui-icon-key"
				}
			});
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
		},
		alert: function(text, title) {
			var alertBox = $("#alert-box");			
			alertBox.find(".dialog-content").html("<p>" + text + "</p>");
			if (title != undefined) {
				alertBox.closest(".ui-dialog").find(".ui-dialog-title").text(title);	
			}
			ui.jWidget.showDialog(alertBox);
		},
		confirm: function(text, title) {
			var confirmBox = $("#confirm-box");			
			confirmBox.find(".dialog-content").html("<p>" + text + "</p>");
			if (title != undefined) {
				confirmBox.closest(".ui-dialog").find(".ui-dialog-title").text(title);	
			}
			ui.jWidget.showDialog(confirmBox);
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
			ui.jWidget.showDialog(promptBox);
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

$(function() {
	ui.element.setupSharpLinks();
	ui.layout.centerContent();
	ui.layout.dockFooter();
	ui.jWidget.setupButtons();
});