$(function() {
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTooltips();
	form.mask.setupMaskMany([
		{ form: "kuCardForm" },
		{ form: "creditCardForm" }
	]);
	form.validation.setupMany([
		{ form: "kuCardForm", option: { binded: false } },
		{ form: "creditCardForm", option: { promptPosition: "topLeft", scroll: false } }
	]);

	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	
});