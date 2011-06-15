/// <reference path="jquery-1.5.1.min.js" />
/// <reference path="jquery-ui-1.8.11.min.js" />
/// <reference path="jquery-tmpl.min.js" />
/// <reference path="knockout-1.2.1.js" />

var model;
var viewModel;
afterBind = [];

if (!console)
    var console = { log: function(msg) { } };

afterBind.push(function () {
    $(':button,:submit,.button').button();
    $('.links').buttonset();
    $('.icon-pencil').button("option", "icons", { primary: "ui-icon-pencil" });
    $('.icon-plusthick').button("option", "icons", { primary: "ui-icon-plusthick" });
    $('.icon-minusthick').button("option", "icons", { primary: "ui-icon-minusthick" });
    $('.icon-closethick').button("option", "icons", { primary: "ui-icon-closethick" });
    $('.no-text').button("option", "text", false);
    $('.tabs').tabs();
    $('.humaneDate').timeago();
});

$(document).ready(function () {
    Bind();
});

var getViewModel = function (model) {
    return model;
};

function Bind() {
    if (model) {
        viewModel = getViewModel(model);
        ko.applyBindings(viewModel);
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