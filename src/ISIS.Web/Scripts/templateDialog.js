/// <reference path="templateBinding.js" />
/// <reference path="jquery-ui-1.8.11.min.js" />
/// <reference path="jquery-1.5.1.min.js" />

// options:
// 	dialog: jQuery selector, required
// 	activatingButton: jQuery selector, required, item(s) that will open the dialog when clicked
// 	okButtonText: string, optional, default "OK"
// 	onOK: function (), optional, runs when user clicks OK button, do not include dialog.close
// 	onCancel: function (), optional, runs when user clicks cancel button, do not include dialog.close
// 	allowed: function (), optional, returns true when dialog is allowed to open, otherwise false.
// 	
// 	modelUrl: url for JSON GET request to load dialog's template view model
// 	loadingTemplate: jQuery selector, required when using modelUrl. jQuery template to be bound while waiting for JSON GET to complete
// 	displayTemplate: jQuery selector, required when using modelUrl. jQuery template to be bound to JSON GET result and displayed inside dialog.
// 	Note: any item in the loading template with css class .progress will be turned in to a jQuery UI progress bar with progress at 100%

var templateDialog = {};

templateDialog.Configure = function (options) {

    var disableOKButton = function (dialog) {
        var buttons = dialog.dialog("option", "buttons");
        buttons[0].disabled = true;
        dialog.dialog("option", "buttons", buttons);
    };

    var enableOKButton = function (dialog) {
        var buttons = dialog.dialog("option", "buttons");
        buttons[0].disabled = false;
        dialog.dialog("option", "buttons", buttons);
    };

    var bindEmptyTemplate = function (dialog, emptyTemplate) {
        var content = emptyTemplate.tmpl(model);
        dialog.html(content);
    };

    var spinBarberPole = function (dialog) {
        dialog.find(".progress").progressbar({ value: 100 });
    };

    var bindContent = function (dialog, dialogTemplate, dialogModel) {
        var content = dialogTemplate.tmpl(dialogModel);
        dialog.html(content);
    };

    var doAjaxDialog = function (dialog, emptyTemplate, dialogTemplate, modelUrl) {
        disableOKButton(dialog);
        bindEmptyTemplate(dialog, emptyTemplate);
        spinBarberPole(dialog);
        $.getJSON(modelUrl, function (data) {
            doAfterAjaxDialog(dialog, dialogTemplate, data);
        });
    };

    var doAfterAjaxDialog = function (dialog, dialogTemplate, data) {
        bindContent(dialog, dialogTemplate, data);
        enableOKButton(dialog);
    };

    afterBind.push(function () {
        var dialog = $(options.dialog);
        var okButtonText = options.okButtonText;

        if (okButtonText == null)
            okButtonText = 'OK';

        var okAction = options.onOK;
        var cancelAction = options.onCancel;

        var activatingButton = $(options.activatingButton);
        var allowed = options.allowed;

        var loadingTemplate = $(options.loadingTemplate);
        var displayTemplate = $(options.displayTemplate);
        var modelUrl = options.modelUrl;

        var dialogOptions = {
            autoOpen: false,
            width: 500,
            modal: true,
            buttons: [{
                text: okButtonText,
                click: function () {
                    if (okAction)
                        okAction();
                    $(this).dialog("close");
                }
            }, {
                text: "Cancel",
                click: function () {
                    if (cancelAction)
                        cancelAction();
                    $(this).dialog("close");
                }
            }]
        };

        if (modelUrl) {
            dialogOptions.open = function () {
                doAjaxDialog(dialog, loadingTemplate, displayTemplate, modelUrl);
            };
        }

        dialog.dialog(dialogOptions);

        var buttonId = activatingButton.attr('id');
        var dialogId = dialog.attr('id');
        console.log('Binding #' + buttonId + ' to #' + dialogId);

        activatingButton.click(function () {
            console.log(allowed);
            console.log(allowed());
            var showDialog = true;
            if (allowed)
                showDialog = allowed();
            if (showDialog)
                dialog.dialog("open");
        });
    });

};

function ConfigureDialog(dialog, form, okButtonText, activatingButton, allowed) {
    templateDialog.Configure({
        dialog: dialog,
        activatingButton: activatingButton,
        okButtonText: okButtonText,
        onOK: function() {
            $(form).submit();
        },
        allowed: allowed
    });
}

afterBind.push(function () {
    var ConfigureHelp = function (dialog, activatingButton) {
        var isOpen = false;
        $(dialog).dialog({
            autoOpen: false,
            width: "60%",
            buttons: [],
            close: function () { isOpen = false; }
        });
        $(activatingButton).click(function () {
            if (!isOpen)
                $(dialog).dialog('open');
        });
    };

    if ($("#helpDialog").length) {
        ConfigureHelp("#helpDialog", "#help");
        $("#help").show();
    }
})