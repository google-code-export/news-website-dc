$(function() {
	ui.jWidget.setupNotifs();
	ui.jWidget.setupDialogs();
	form.validation.setupOne("loginForm");
	
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	login: {
		// TODO: Add page-scope functions
	}	
});