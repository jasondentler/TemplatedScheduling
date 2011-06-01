
function drawIntro(svg) {
    var tooltips = [];
    for (var roomIdx in mapData.rooms) {
        var room = mapData.rooms[roomIdx];
        var avail = getRoomAvailability(room.number);
        if (avail) {
            var id = 'room' + room.number;
            var points = getPath(room);
            var options = {};
            switch (avail.Status) {
                case 0: // Available
                    options = { id: id, fill: 'green', fillOpacity: 0.5, stroke: 'none', strokeWidth: 3 };
                    break;
                case 1: // Unavailable
                    options = { id: id, fill: 'red', fillOpacity: 0.5, stroke: 'none', strokeWidth: 3 };
                    break;
                case 2: // ReducedCapacity
                    options = { id: id, fill: 'yellow', fillOpacity: 0.5, stroke: 'none', strokeWidth: 3 };
                    break;
                case 3: // ReducedCapacity
                    options = { id: id, fill: 'orange', fillOpacity: 0.5, stroke: 'none', strokeWidth: 3 };
                    break;
            };
            var poly = svg.polygon(points, options);

            $(poly).bind('click', { roomId: avail.RoomId }, roomSelected);
            
            if (avail.Message) {
                var tipid = id + 'tag';
                var tooltipData = {
                    polygonId: id,
                    tooltipId: tipid,
                    center: getCenter(points),
                    options: {
                        id: tipid,
                        roomId: avail.RoomId,
                        fontSize: 42,
                        fontWeight: 'bold',
                        fill: 'grey',
                        stroke: 'black',
                        strokeWidth: '1px',
                        visibility: 'hidden'
                    },
                    text: avail.Message
                };
                tooltips.push(tooltipData);
            }
        }
    }

    for (var tooltipIdx in tooltips) {
        var tooltip = tooltips[tooltipIdx];
        var tooltipid = tooltip.tooltipId;
        var center = tooltip.center;
        var tooltipObject = svg.text(null, center[0], center[1],
                tooltip.text, tooltip.options);

        var width = tooltipObject.getBBox().width;
        var offset = width / 2;
        var newX = center[0] - offset;
        $(tooltipObject).attr('x', newX);

        $('#' + tooltip.polygonId, svg.root())
                                        .bind('mouseenter', { svg: svg, tooltipid: tooltipid }, showTooltip)
                                        .bind('mouseleave', { svg: svg, tooltipid: tooltipid }, hideTooltip);

    }

}

function getRoomAvailability(roomNumber) {
    for (var availIdx in model.Availabilities) {
        var avail = model.Availabilities[availIdx];
        if (avail.Room == roomNumber)
            return avail;
    }
    return null;
}

function getPath(room) {
    var points = [];
    for (var pointIdx in room.path) {
        var point = room.path[pointIdx];
        points.push([point.x, point.y]);
    }
    return points;
}

function getCenter(points) {
    var xSum = 0;
    var ySum = 0;
    for (var pointIdx in points) {
        var point = points[pointIdx];
        xSum += point[0];
        ySum += point[1];
    }
    return [xSum / points.length, ySum / points.length];
}

function showTooltip(event) {
    var tooltipid = event.data.tooltipid;
    var svg = event.data.svg;
    $('#' + tooltipid, svg.root()).attr('visibility', 'visible');
}

function hideTooltip(event) {
    var tooltipid = event.data.tooltipid;
    var svg = event.data.svg;
    $('#' + tooltipid, svg.root()).attr('visibility', 'hidden');
}

afterBind.push(function () {
    $('#map').svg({
        loadURL: "/Content/images/buildings/G1.svg",
        onLoad: drawIntro
    });
});