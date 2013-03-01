$(function() {
	ui.jWidget.setupNotifs();
	ui.jWidget.setupDialogs();
	form.validation.setupOne("loginForm");
	
	$("#fp-link").click(function() {
		var dialog = $("#fp-dialog");
		ui.jWidget.showDialog(dialog, {
			width: 450,
			buttons: {
				"OK": function() {
					ui.jWidget.closeDialog(dialog);
				}
			}
		});
	});
});