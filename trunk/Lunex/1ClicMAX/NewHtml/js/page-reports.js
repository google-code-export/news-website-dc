$(function() {
	ui.jWidget.setupTooltips();
	ui.jWidget.setupDialogs();
	ui.jWidget.setupDataTables();
	form.mask.setupMaskMany([
		{ form: "addDepositForm" }
	]);
	form.validation.setupMany([
		{ form: "addDepositForm", option: { scroll: false } }
	]);
	
	// TODO: Execute page-scope functions here
});

$(window).load(function() {
	pages.report.adjustTabWidths();
	pages.report.setupMiscEvents();
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	report: {
		adjustTabWidths: function() {
			var tabs = $(".site-content .report-tabs ul li a");
			var totalTabsWidth = 0;
			tabs.each(function() {
				$(this).css({ width: "auto" });
				totalTabsWidth += $(this).width();
			});
			var padding = (1000 - totalTabsWidth) / (tabs.size() * 2) - 0.45;
			tabs.css({
				"padding-left": padding + "px",
				"padding-right": padding + "px"
			});
		},
		setupMiscEvents: function() {
			$("#addDepositButton").click(function() {
				ui.jWidget.showDialog("addDepositDialog", {
					width: 540,
					buttons: [
						{
							text: "Add",
							click: function() {
								form.validation.hide("addDepositForm");
								if (form.validation.validate("addDepositForm")) {
									ui.jWidget.closeDialog("addDepositDialog");
								}
							}
						}
					]
				});
			});
			$("#enableAutoRefill, #editAutoRefill").click(function() {
				ui.jWidget.showDialog("autoRefillDialog", {
					width: 540,
					buttons: [
						{
							text: "Save",
							click: function() {
								form.validation.hide("autoRefillForm");
								if (form.validation.validate("autoRefillForm")) {
									ui.jWidget.closeDialog("autoRefillDialog");
								}
							}
						}
					]
				});
			});
		}
	}
});