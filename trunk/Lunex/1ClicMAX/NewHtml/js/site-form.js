// Form helper features
var form = {
	mask: {
		setupMaskOne: function(formId) {
			var formId = util.html.getJqueryIdSelector(formId);
			$(formId + " input[data-mask-type=us-phone]")
				.mask({ mask: "###-###-####", placeholder: "  " });
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