$(function() {	
	ui.jWidget.setupDialogs();
	form.mask.setupMaskMany([
		{ form: "phoneInputForm" },
		{ form: "newAccountForm" },
		{ form: "quickAdd1Clic2" },
		{ form: "quickAdd1Clic1" },
		{ form: "rechargeAccountForm" },
		{ form: "addMulti1ClicNoForm" },
		{ form: "edit1ClicNoDialog" },
		{ form: "addUsNoDialog" },
		{ form: "editUsNoDialog" }
	]);
	form.validation.setupMany([
		{ form: "phoneInputForm", option: { binded: false } },
		{ form: "newAccountForm" },
		{ form: "quickAdd1Clic2", option: { binded: false } },
		{ form: "quickAdd1Clic1", option: { binded: false } },
		{ form: "rechargeAccountForm"},
		{ form: "addMulti1ClicNoForm" },
		{ form: "edit1ClicNoDialog" },
		{ form: "addUsNoDialog" },
		{ form: "editUsNoDialog" }
	]);
	
	pages.oneClicMax.refineTabContent();

	pages.oneClicMax.showNewCustomerDialog();
	pages.oneClicMax.showAddMultiNumbersDialog();
	pages.oneClicMax.showEdit1ClicPhoneDialog();
	pages.oneClicMax.showAddUsPhoneDialog();
	pages.oneClicMax.showEditUsPhoneDialog();

	pages.oneClicMax.confirmDelete1ClicNo();

	pages.oneClicMax.slidePrintDropDown();

	pages.oneClicMax.newAccountForm.choosePhoneType();
	
	pages.oneClicMax.rechargeAccountForm.addAmount();
	pages.oneClicMax.rechargeAccountForm.voidAmount();
	
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
					width: 740,
					buttons: [
						{
							text: "Cancel",
							class: "sub-button",
							click: function() {
								ui.jWidget.closeDialog("addMulti1ClicNoDialog");	
							}
						},
						{
							text: "Save",
							click: function() {
								ui.jWidget.closeDialog("addMulti1ClicNoDialog");	
							}
						}
					]
				});	
			});
		},
		showEdit1ClicPhoneDialog: function() {
			$("#oneClicPhonesList .edit-link").click(function(e) {
                ui.jWidget.showDialog("edit1ClicNoDialog", {
					width: 872,
					buttons: [
						{
							text: "Cancel",
							class: "sub-button",
							click: function() {
								ui.jWidget.closeDialog("edit1ClicNoDialog");	
							}
						},
						{
							text: "Save",
							click: function() {
								ui.jWidget.closeDialog("edit1ClicNoDialog");	
							}
						}
					]
				});
            });
		},
		showAddUsPhoneDialog: function() {
			$("#addUsNo").click(function(e) {
                ui.jWidget.showDialog("addUsNoDialog", {
					width: 842,
					buttons: [
						{
							text: "Cancel",
							class: "sub-button",
							click: function() {
								ui.jWidget.closeDialog("addUsNoDialog");	
							}
						},
						{
							text: "Save",
							click: function() {
								ui.jWidget.closeDialog("addUsNoDialog");	
							}
						}
					]
				});
            });
		},
		showEditUsPhoneDialog: function() {
			$("#usPhonesList .edit-link").click(function(e) {
                ui.jWidget.showDialog("editUsNoDialog", {
					width: 842,
					buttons: [
						{
							text: "Cancel",
							class: "sub-button",
							click: function() {
								ui.jWidget.closeDialog("editUsNoDialog");	
							}
						},
						{
							text: "Save",
							click: function() {
								ui.jWidget.closeDialog("editUsNoDialog");	
							}
						}
					]
				});
            });
		},
		confirmDelete1ClicNo: function() {
			$("#oneClicPhonesList .delete-link").each(function(i, el) {
                $(this).click(function() {
					var clicNumber = $.trim($(this).parents("tr").find("td:eq(1)").text());
                    ui.jWidget.confirm(
						"Are you sure you want to delete 1Clic&trade; Number <strong class=\"emp\">" + clicNumber + "</strong>?", 
						"Confirmation",
						function() {
							alert("Yes!");
						},
						function() {
							alert("No!");
						}
					);
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
		refineTabContent: function() {
			if (!$("#phonesListTabs").idTabs) {
				return;	
			}
			ui.jWidget.setupDataTable("oneClicPhonesList");
			$("#phonesListTabs").idTabs(function(id,list,set){ 
				$("a",set).removeClass("selected") 
				.filter("[href='"+id+"']",set).addClass("selected"); 
				for(i in list) 
				  $(list[i]).hide(); 
				$(id).fadeIn("fast", function() {
					ui.layout.dockFooter();
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
				phoneTypeRadios.change(function() {
					acceptTextRadios.removeAttr("checked");
					if ($(this).val() == "cell") {
						acceptTextRadios.filter("[value=yes]").attr("checked", "checked");
					}
				});
			}
		},
		rechargeAccountForm: {
			addAmount: function() {
			
			},
			voidAmount: function() {
				$("#rechargeVoidButton").click(function() {
                	var payment = $("#rechargeAccountForm :radio[name=payment]:checked").val();
					console.log(payment);
					if (payment == "cash") {
						ui.jWidget.confirm(
							"Are you sure you want to VOID this transaction?", 
							"Confirmation",
							function() {
								alert("Yes!");
							},
							function() {
								alert("No!");
							}
						);
					} else {
						ui.jWidget.alert(
							"For assistance with voiding this Credit Card purchase,"
							+ " please contact our Customer Support at <strong class=\"emp\">1-888-333-2404.</strong>",
							"Attention");
					} 
                });				
			}
		}
	}	
});