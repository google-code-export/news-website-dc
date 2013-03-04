$(function() {
	form.mask.setupMaskMany([
		{ form: "phoneInputForm" },
		{ form: "newAccountForm" }
	]);
	form.validation.setupMany([
		{ form: "phoneInputForm", option: { binded: false } },
		{ form: "newAccountForm" }
	]);

	pages.oneClicMax.newAccountForm.choosePhoneType();
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	oneClicMax: {
		newAccountForm: {
			choosePhoneType: function() {
				var phoneTypeRadios = $("#newAccountForm :radio[name=phonetype]");
				var acceptTextRadios = $("#newAccountForm :radio[name=accepttext]");
				phoneTypeRadios.click(function() {
					acceptTextRadios.removeAttr("checked");
					if ($(this).val() == "cell") {
						acceptTextRadios.filter("[value=yes]").attr("checked", "checked");
					}
				});
			}
		}
	}	
});