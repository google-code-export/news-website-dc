// Form helper features
var form = {
	// Required:
	// jquery.validationEngine.js
	validation: {
		setupOne: function(formId, option) {
			var formId = util.html.getJqueryIdSelector(formId);
			$(formId).validationEngine(option);
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