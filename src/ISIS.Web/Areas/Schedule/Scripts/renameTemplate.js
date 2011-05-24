/// <reference path="../../Scripts/templateDialog.js" />
ConfigureDialog(
    "#renameTemplateDialog",
    "#renameTemplateForm",
    "Yes, rename this template",
    "#renameTemplate",
    function () { return model.CanRename; });

