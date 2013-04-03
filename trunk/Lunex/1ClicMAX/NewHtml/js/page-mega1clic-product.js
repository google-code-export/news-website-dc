$(function() {	
	ui.jWidget.setupDialogs();
	ui.jWidget.setupTvAds();
	ui.jWidget.setupTooltips();
	form.mask.setupMaskMany([
		{ form: "phoneInputForm" },
		{ form: "newAccountForm" },
		{ form: "quickAdd1Clic2" },
		{ form: "quickAdd1Clic1" },
		{ form: "rechargeAccountForm" },
		{ form: "addMulti1ClicNoForm" },
		{ form: "edit1ClicNoDialog" },
		{ form: "addUsNoDialog" },
		{ form: "editUsNoDialog" },
		{ form: "creditCardForm" },
		{ form: "custInfoForm" },
		{ form: "ratesDialog form" }
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
		{ form: "editUsNoDialog" },
		{ form: "creditCardForm", option: { promptPosition: "topLeft", scroll: false } },
		{ form: "custInfoForm", option: { promptPosition: "topLeft", scroll: false } }
	]);
	
	// Support CSS Styling
	pages.mega1Clic.identify();
	
	pages.mega1Clic.refineTabContent();

	pages.mega1Clic.showNewCustomerDialog();
	pages.mega1Clic.showAddMultiNumbersDialog();
	pages.mega1Clic.showEdit1ClicPhoneDialog();
	pages.mega1Clic.showAddUsPhoneDialog();
	pages.mega1Clic.showEditUsPhoneDialog();
	pages.mega1Clic.showEditCustInfoDialog();
	pages.mega1Clic.showRatesDialog();

	pages.mega1Clic.confirmDelete1ClicNo();

	pages.mega1Clic.slidePrintDropDown();

	pages.mega1Clic.newAccountForm.choosePhoneType();
	
	pages.mega1Clic.rechargeAccountForm.addAmount();
	pages.mega1Clic.rechargeAccountForm.voidAmount();
	
	// TODO: Execute page-scope functions here
});

if (!pages) {
	var pages = {};	
}
pages = $.extend(pages, {
	mega1Clic: {
		identify: function() {
			$(document.body).addClass("mega1clic");
		},
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
			$("#oneClicPhonesList").find(".edit-link, .qedit-link").click(function(e) {
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
			$("#usPhonesList").find(".edit-link, .qedit-link").click(function(e) {
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
		showEditCustInfoDialog: function() {
			$("#editCustInfoButton").click(function(e) {
                ui.jWidget.showDialog("custInfoDialog", {
					width: 600,
					buttons: [
						{
							text: "Cancel",
							class: "sub-button",
							click: function() {
								ui.jWidget.closeDialog("custInfoDialog");	
							}
						},
						{
							text: "Save",
							click: function() {
								form.validation.hide("custInfoForm");
								if (form.validation.validate("custInfoForm")) {
									ui.jWidget.closeDialog("custInfoDialog");	
								}	
							}
						}
					],
					open: function() {
						var phoneType = $(this).find(".phone-type");
						phoneType.find(":radio[name=phonetype]").change(function() {
							if ($(this).val() == "cell") {
								phoneType.find(".child-options").slideDown("fast", function() {
									phoneType.find(":radio[name=accepttext]:first").attr("checked", "checked");
								});
							} else {
								phoneType.find(".child-options").slideUp("fast");
							}
							form.validation.hide("custInfoForm");
						});
						phoneType.find("span.default > :radio").attr("checked", "checked").change();
					}
				});
            });
		},
		showRatesDialog: function() {
			$("#ratesLink").click(function() {
                ui.jWidget.showDialog("ratesDialog", {
					open: function() {
						ui.jWidget.setupDataTable("ratesTable");
					}
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
				$("a",set).removeClass("selected").filter("[href='" + id + "']", set).addClass("selected"); 
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
				$("#rechargeAddButton").click(function() {
					var payment = $("#rechargeAccountForm :radio[name=payment]:checked").val();
					if (form.validation.validate("rechargeAccountForm")) {
						if (payment == "credit") {
							ui.jWidget.showDialog("creditCardDialog", {
								width: 600,
								buttons: [
									{
										text: "Submit",
										click: function() {
											form.validation.hide("creditCardForm");
											if (form.validation.validate("creditCardForm")) {
												ui.jWidget.closeDialog("creditCardDialog");
											}
										}
									}
								],
								open: function() {
									var ccExtra = $(this).find(".cc-extra");
									var ccForm = $(this).find(".cc-form");
									ccForm.next(".cc-terms").appendTo($(this).next(".ui-dialog-buttonpane"));
									ccExtra.find(".action :radio").unbind("change").change(function() {
										if ($(this).val() == "new") {
											ccForm.find(".cc-list").slideUp(100, function() {
												ccForm.find(".cc-number").removeAttr("readonly").removeClass("read-only");
												$(".cc-save").show();
												form.validation.hide("creditCardForm");
											});
										} else {
											ccForm.find(".cc-list").slideDown(100, function() {
												ccForm.find(".cc-number").attr("readonly", "readonly").addClass("read-only");
												$(".cc-save").hide();
												form.validation.hide("creditCardForm");
											});
										}
									});
									ccExtra.find(".amount :text").val($("#rechargeAmount").val());
									ccExtra.find(".action span.default :radio").attr("checked", "checked").change();
								}
							});
						}
					}					
				});
			},
			voidAmount: function() {
				$("#rechargeVoidButton").click(function() {
                	var payment = $("#rechargeAccountForm :radio[name=payment]:checked").val();
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