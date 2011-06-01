/// <reference path="../../Scripts/templateBinding.js" />
/// <reference path="../../Scripts/jquery-ui-1.8.11.min.js" />
/// <reference path="../../Scripts/jquery-1.5.1.min.js" />

function GetCourses(model) {
    var courses = {};
    for (var i = 0; i < model.Sections.length; i++) {
        var section = model.Sections[i];
        if (courses[section.CourseName] == null)
            courses[section.CourseName] = { sections: [] };
        courses[section.CourseName].sections.push({ id: section.Id, name: section.SectionName });
    }
    return courses;
}

// afterBind is defined in templateBinding.js
// It's an array of functions to run after the jQuery-tmpl has 
// been bound to the model
afterBind.push(function () {
    var options = {};
    if (model.CourseName) {
        options['active'] = 'h3[courseName="' + model.CourseName +'"]';
    }
    $("#sectionList").accordion(options);

});