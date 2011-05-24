/// <reference path="../../Scripts/templateDialog.js" />
ConfigureDialog(
    "#removeTemplateDialog",
    "#removeTemplateForm",
    "Yes, remove this template",
    "#removeTemplateLink",
    function () { return model.CanRemove; });
     
