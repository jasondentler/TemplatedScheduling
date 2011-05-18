/// <reference path="../../Scripts/templateBinding.js" />
/// <reference path="../../Scripts/jquery-ui-1.8.11.min.js" />
/// <reference path="../../Scripts/jquery-1.5.1.min.js" />

// afterBind is defined in templateBinding.js
// It's an array of functions to run after the jQuery-tmpl has 
// been bound to the model
afterBind.push(function () {
    $("#editInstructorNameDialog").dialog({
        autoOpen: false,
        height: 300,
        width: 350,
        modal: true,
        buttons: {
            "Change Name": function () {
                $("#editInstructorNameForm").submit();
                $(this).dialog("close");
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        }
    });
    $(".editInstructorName").click(function () {
        $("#editInstructorNameDialog").dialog("open");
    });
});