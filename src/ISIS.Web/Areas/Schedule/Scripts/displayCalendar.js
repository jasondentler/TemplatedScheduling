// afterBind is defined in templateBinding.js
// It's an array of functions to run after the jQuery-tmpl has 
// been bound to the model
function parseDate(jsonDate) {
    if (jsonDate)
        return new Date(parseInt(jsonDate.substr(6)));
    return null;
}

function eventGenerator() {
    var events = [];
    var colorMap = [];
    var colorSchemes = [
        { top: '#000099', body: "#666699", border: "#333399", text: "white" },
        { top: '#009900', body: "#669966", border: "#339933", text: "white" },
        { top: '#990000', body: "#996666", border: "#993333", text: "white" },
        { top: '#999900', body: "#999966", border: "#999933", text: "white" },
        { top: '#990099', body: "#996699", border: "#993399", text: "white" },
        { top: '#009999', body: "#669999", border: "#339999", text: "white" }
    ];
    var nextSchemeIndex = 0;
    
    var itemCount = model.Items.length;
    for (var idx in model.Items) {
        var e = model.Items[idx];
        var title = e.Title;
        var currentScheme;
        if (!colorMap[title]) {
            colorMap[title] = colorSchemes[nextSchemeIndex];
            nextSchemeIndex = (nextSchemeIndex + 1) % colorSchemes.length;
        }

        var newEvent = {
            title: e.Title,
            start: GetEventStart(e, model),
            end: GetEventEnd(e, model),
            url: e.Link,
            allDay: (e.Start == null),
            color: colorMap[title].top,
            backgroundColor: colorMap[title].body,
            borderColor: colorMap[title].border,
            textColor: colorMap[title].text
        };
        events.push(newEvent);
    }
    return events;
}

function GetEventStart(event, model) {
    if (event.Start == null)
        return parseDate(model.Start);
    return parseDate(event.Start);
}

function GetEventEnd(event, model) {
    if (event.End == null)
        return parseDate(model.End);
    return parseDate(event.End);
}

afterBind.push(function () {
    var startDate = parseDate(model.Start);
    $("#calendar").fullCalendar({
            header: { left: '', center: '', right: '' },
            columnFormat: {week: 'dddd'},
            defaultView: 'agendaWeek',
            editable: false,
            allDayText: 'Internet, TBA',
            events: eventGenerator()
        });

    $("#calendar").fullCalendar('gotoDate', startDate);
});
