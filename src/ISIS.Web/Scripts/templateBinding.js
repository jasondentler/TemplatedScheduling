/// <reference path="../../Scripts/jquery-ui-1.8.11.min.js" />
/// <reference path="../../Scripts/jquery-1.5.1.min.js" />
var model;
afterBind = [];

$(document).ready(function () {
    afterBind.push(function () {
        $(':button').button();
        $(':button.icon-pencil').button("option", "icons", { primary: "ui-icon-pencil" });
        $(':button.icon-plusthick').button("option", "icons", { primary: "ui-icon-plusthick" });
        $(':button.icon-closethick').button("option", "icons", { primary: "ui-icon-closethick" });
        $(':button.no-text').button("option", "text", false);
    });
    Bind();
});

function Bind() {
    if (model) {
        $('#template').tmpl(model).appendTo('#placeholder');
        for (var index = 0; index < afterBind.length; index++) {
            afterBind[index]();
        }
    }
}
        
