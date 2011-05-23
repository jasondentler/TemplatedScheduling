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
        'event-class1',
        'event-class2',
        'event-class3',
        'event-class4',
        'event-class5',
        'event-class6'];

    var allDayColorSchemes = [
        'event-class1-allday',
        'event-class2-allday',
        'event-class3-allday',
        'event-class4-allday',
        'event-class5-allday',
        'event-class6-allday'];

    var nextSchemeIndex = 0;
    
    var itemCount = model.Items.length;
    for (var idx in model.Items) {
        var e = model.Items[idx];
        var title = e.Title;

        var currentScheme;

        if (e.Class == null) {
            if (!colorMap[title]) {
                colorMap[title] = nextSchemeIndex;  //colorSchemes[nextSchemeIndex];
                nextSchemeIndex = (nextSchemeIndex + 1) % colorSchemes.length;
            }

            var currentSchemeIndex = colorMap[title];
            currentScheme = colorSchemes[currentSchemeIndex];
            if (e.Start == null)
                currentScheme = allDayColorSchemes[currentSchemeIndex];
        } else {
            currentScheme = e.Class;
        }

        var newEvent = {
            title: e.Title,
            start: GetEventStart(e, model),
            end: GetEventEnd(e, model),
            url: e.Link,
            allDay: (e.Start == null),
            className: currentScheme
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
