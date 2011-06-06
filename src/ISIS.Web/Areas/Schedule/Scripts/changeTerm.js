/// <reference path="../../Scripts/templateDialog.js" />

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

templateDialog.Configure({
        dialog: "#changeTermDialog",
        activatingButton: "#changeTermLink",
        okButtonText: "Yes, change term",
        onOK: function() {
            $("#changeTermForm").submit();
        },
        allowed: function () {
            return model.CanChangeTerm;
        },
        modelUrl: model.GetAvailableTermsUrl,
        loadingTemplate: "#emptyChangeTermTemplate",
        displayTemplate: "#changeTermTemplate"
    });


//afterBind.push(function () {
//    $("#changeInstructorDialog").dialog({
//        disabled: true,
//        autoOpen: false,
//        width: 500,
//        modal: true,
//        buttons: [{
//            text: "Yes, change instructor",
//            disabled: true,
//            click: function () {
//                $("#changeInstructorForm").submit();
//                $(this).dialog("close");
//            }
//        }, {
//            text: "Cancel",
//            click: function () {
//                $(this).dialog("close");
//            }
//        }],
//        open: function () {
//            emptyDialog();
//            getQualifiedInstructors(bindTemplate);
//        }
//    });

//    $("#changeInstructorLink").click(function () {
//        if (model.CanChangeInstructor) {
//            $("#changeInstructorDialog").dialog("open");
//        }
//    });

//});

//function enableChangeInstructorDialogButton() {
//    var buttons = $("#changeInstructorDialog").dialog("option", "buttons");
//    buttons[0].disabled = false;
//    $("#changeInstructorDialog").dialog("option", "buttons", buttons);
//}

//function getQualifiedInstructors(callback) {
//    var url = model.GetQualifiedInstructorsUrl;
//    $.getJSON(url, function (data) {
//        callback(data);
//    });
//}

//function bindTemplate(model) {
//    var content = $("#changeInstructorTemplate").tmpl(model);
//    $("#changeInstructorDialog").html(content);
//    enableChangeInstructorDialogButton();
//}

//function emptyDialog() {
//    var content = $("#emptyChangeInstructorTemplate").tmpl(model);
//    $("#changeInstructorDialog").html(content);
//    $("#changeInstructorLoadingInstructorsProgress").progressbar({
//            value: 100
//        });
//}