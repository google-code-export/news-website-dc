$(function() {
	ui.jWidget.setupDataTables();
	
	// TODO: Execute page-scope functions here
});

$(window).load(function() {
	pages.report.adjustTabWidths();
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
		}
	}
});