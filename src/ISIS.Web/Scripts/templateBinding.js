/// <reference path="jquery-1.5.1.min.js" />
/// <reference path="jquery-ui-1.8.11.min.js" />
/// <reference path="jquery-tmpl.min.js" />
/// <reference path="knockout-1.2.1.js" />

var model;
afterBind = [];

if (!console)
    var console = { log: function(msg) { } };

afterBind.push(function () {
    $(':button,:submit,.button').button();
    $('.links').buttonset();
    $('.icon-pencil').button("option", "icons", { primary: "ui-icon-pencil" });
    $('.icon-plusthick').button("option", "icons", { primary: "ui-icon-plusthick" });
    $('.icon-closethick').button("option", "icons", { primary: "ui-icon-closethick" });
    $('.no-text').button("option", "text", false);
    $('.tabs').tabs();
});

$(document).ready(function () {
    Bind();
});

function Bind() {
    if (model) {
        ko.applyBindings(model);
        for (var index = 0; index < afterBind.length; index++) {
            afterBind[index]();
        }
    }
}

function mapIsEmpty(map) {
    for (var key in map) {
        if (map.hasOwnProperty(key))
            return false;
    }
    return true;
}

function mapHasKeys(map) {
    return !mapIsEmpty(map);
}