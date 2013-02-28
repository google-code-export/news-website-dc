// UI helper features
var ui = {
	clazz: {
		active: "active",
		focused: "focused",
		selected: "selected",
		collapsed: "collapsed",
		expanded: "expanded"
	},
	layout: {
		
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
					console.log(i);
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
            });
		},
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.dialog.min.js
		setupDialogs: function() {
			$(".dialog, dialog").each(function() {
				$(this).dialog({
					autoOpen: false,
					minWidth: 400,
					width: $(this).width(),
					modal: true,
					resizable: false
				});
			});
			$(".dialog .dialog-close").click(function() {
				var targetDialog = $(this).closest(".dialog");
				ui.jWidget.closeDialog(targetDialog);
			});
			$(".dialog-trigger").on("click", function() {
				var dialogId = $(this).attr("data-dialog-id");
				var targetDialog = $("#" + dialogId);
				ui.jWidget.showDialog(targetDialog);
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
		showDialog: function(targetDialog, option) {
			// Do nothing if cannot find the target dialog
			if (targetDialog.size() == 0) {
				return false;
			}
			targetDialog.dialog("option", option).dialog("open");
		},
		// Required:
		// jquery.ui.interations.min.js (Dragging Ability)
		// jquery.ui.dialog.min.js
		closeDialog: function(targetDialog)  {
			// Do nothing if cannot find the target dialog
			if (targetDialog.size() == 0) {
				return false;
			}
			targetDialog.dialog("close");
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
	ui.jWidget.setupButtons();
});