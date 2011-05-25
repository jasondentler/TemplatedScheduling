/// <reference path="../../Scripts/jquery-ui-1.8.11.min.js" />
/// <reference path="../../Scripts/jquery-1.5.1.min.js" />

afterBind.push(function () {
    $("#changeInstructorDialog").dialog({
        disabled: true,
        autoOpen: false,
        width: 500,
        modal: true,
        buttons: [{
            text: "Yes, change instructor",
            disabled: true,
            click: function () {
                $("#changeInstructorForm").submit();
                $(this).dialog("close");
            }
        }, {
            text: "Cancel",
            click: function () {
                $(this).dialog("close");
            }
        }],
        open: function () {
            emptyDialog();
            getQualifiedInstructors(bindTemplate);
        }
    });

    $("#changeInstructorLink").click(function () {
        if (model.CanChangeInstructor) {
            $("#changeInstructorDialog").dialog("open");
        }
    });

});

function enableChangeInstructorDialogButton() {
    var buttons = $("#changeInstructorDialog").dialog("option", "buttons");
    buttons[0].disabled = false;
    $("#changeInstructorDialog").dialog("option", "buttons", buttons);
}

function getQualifiedInstructors(callback) {
    var url = model.GetQualifiedInstructorsUrl;
    $.getJSON(url, function (data) {
        callback(data);
    });
}

function bindTemplate(model) {
    var content = $("#changeInstructorTemplate").tmpl(model);
    $("#changeInstructorDialog").html(content);
    enableChangeInstructorDialogButton();
}

function emptyDialog() {
    var content = $("#emptyChangeInstructorTemplate").tmpl(model);
    $("#changeInstructorDialog").html(content);
    $("#changeInstructorLoadingInstructorsProgress").progressbar({
            value: 100
        });
}