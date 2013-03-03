$(function() {
	form.mask.setupMaskMany([{ form: "phoneInputForm" }]);
	form.validation.setupMany([{ form: "phoneInputForm" }]);
	
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	oneClicMax: {
		// TODO: Add page-scope functions
	}	
});