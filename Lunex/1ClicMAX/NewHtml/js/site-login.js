$(function() {
	ui.jWidget.setupNotifs();
	ui.jWidget.setupDialogs();
	
	$("#fp-link").click(function() {
		var dialog = $("#fp-dialog");
		ui.jWidget.showDialog(dialog, {
			width: 500,
			buttons: {
				"OK": function() {
					ui.jWidget.closeDialog(dialog);
				}
			}
		});
	});
});