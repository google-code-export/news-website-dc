$(function() {
	form.mask.setupMaskMany([
		{ form: "topupForm" }
	]);
	form.validation.setupMany([
		{ form: "topupForm" }
	]);

	
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	topUpWorld: {
		
	}	
});