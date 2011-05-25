/// <reference path="../../Scripts/templateBinding.js" />
/// <reference path="../../Scripts/jquery-ui-1.8.11.min.js" />
/// <reference path="../../Scripts/jquery-1.5.1.min.js" />

function ConfigureDialog(dialog, form, okButtonText, activatingButton, allowed) {
    // afterBind is defined in templateBinding.js
    // It's an array of functions to run after the jQuery-tmpl has 
    // been bound to the model
    afterBind.push(function () {
        $(dialog).dialog({
                autoOpen: false,
                width: 500,
                modal: true,
                buttons: [{
                    text: okButtonText,
                    click: function() {
                        $(form).submit();
                        $(this).dialog("close");
                    }
                }, {
                    text: "Cancel",
                    click: function() {
                        $(this).dialog("close");
                    }
                }]
            });

        $(activatingButton).click(function () {
            if (allowed())
                $(dialog).dialog("open");
        });
        $(activatingButton).button("option", "disabled", !allowed());
    });
}