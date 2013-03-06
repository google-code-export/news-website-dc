$(function() {
	ui.jWidget.setupDataTable();
	ui.jWidget.setupDialogs();
	form.mask.setupMaskMany([
		{ form: "phoneInputForm" },
		{ form: "newAccountForm" },
		{ form: "add1ClicPhoneNo" },
		{ form: "quickAdd1ClicPhoneNo" },
		{ form: "rechargeAccountForm" }
	]);
	form.validation.setupMany([
		{ form: "phoneInputForm", option: { binded: false } },
		{ form: "newAccountForm" },
		{ form: "add1ClicPhoneNo", option: { binded: false } },
		{ form: "quickAdd1ClicPhoneNo", option: { binded: false } },
		{ form: "rechargeAccountForm", option: { binded: true } }
	]);
	
	//pages.oneClicMax.showNewCustomerDialog();
	pages.oneClicMax.showAddMultiNumbersDialog();
	pages.oneClicMax.slidePrintDropDown();
	pages.oneClicMax.newAccountForm.choosePhoneType();
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	oneClicMax: {
		showNewCustomerDialog: function() {
			if ($("#newCustomerDialog").size() > 0) {
				ui.jWidget.showDialog("newCustomerDialog", { width: 980, buttons: {} });	
			}
		},
		showAddMultiNumbersDialog: function() {
			$("#addMultiNo1, #addMultiNo2").click(function() {
				ui.jWidget.closeDialog("newCustomerDialog");
				ui.jWidget.showDialog("addMultiNumbersDialog", {
					width: 600,
					buttons: {
						"Save": function() {
							
							ui.jWidget.closeDialog("addMultiNumbersDialog");
						},
						"Cancel": function() {
							ui.jWidget.closeDialog("addMultiNumbersDialog");
						}	
					}
				});	
			});
		},
		slidePrintDropDown: function() {
			$("#oneClicAccountInfo .print-feature").hover(function() {
				$(this).find(".dropdown").not(":visible").slideDown("fast");
			},
			function() {
				$(this).find(".dropdown").slideUp("fast");	
			});
		},
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