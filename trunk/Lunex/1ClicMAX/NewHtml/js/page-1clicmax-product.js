$(function() {	
	ui.jWidget.setupDialogs();
	form.mask.setupMaskMany([
		{ form: "phoneInputForm" },
		{ form: "newAccountForm" },
		{ form: "quickAdd1Clic2" },
		{ form: "quickAdd1Clic1" },
		{ form: "rechargeAccountForm" }
	]);
	form.validation.setupMany([
		{ form: "phoneInputForm", option: { binded: false } },
		{ form: "newAccountForm" },
		{ form: "quickAdd1Clic2", option: { binded: false } },
		{ form: "quickAdd1Clic1", option: { binded: false } },
		{ form: "rechargeAccountForm", option: { binded: true } }
	]);
	
	pages.oneClicMax.refineTables();
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
				ui.jWidget.showDialog("addMulti1ClicNoDialog", {
					width: 600,
					buttons: {
						"Cancel": function() {
							ui.jWidget.closeDialog("addMultiNumbersDialog");
						},
						"Save": function() {
							
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
		refineTables: function() {
			ui.jWidget.setupDataTable("oneClicPhonesList");
			$("#phonesListTabs").idTabs(function(id,list,set){ 
				$("a",set).removeClass("selected") 
				.filter("[href='"+id+"']",set).addClass("selected"); 
				for(i in list) 
				  $(list[i]).hide(); 
				$(id).fadeIn("fast", function() {
					if (id == "#usNumbersTab") {
						ui.jWidget.setupDataTable("usPhonesList");	
					}
				}); 
				return false; 
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