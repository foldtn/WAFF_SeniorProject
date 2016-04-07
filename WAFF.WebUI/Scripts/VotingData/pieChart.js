
google.load("visualization", "1", { packages: ["corechart"] });

function drawChart() {
    var max = document.getElementById('maxGraphCount').value;

    if (max > 0) {
        var film = document.getElementById('currentFilm').value;

        document.getElementById('film' + film).click();
    }

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Film');
    data.addColumn('number', 'Votes');
    data.addColumn('string', 'ID');

    for (var x = 0; x < max; x++) {
        var film = document.getElementById('FilmName' + x).value;
        var votes = parseInt(document.getElementById('FilmVotes' + x).value);
        var id = document.getElementById('FilmID' + x).value;
        data.addRow([film, votes, id]);
    }

    var options = {
        title: 'Block',
        height: '100%',
        width: '100%',
        chartArea: {
            top: "3%",
            height: "80%",
            width: "100%"
        }
    };

    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

    chart.draw(data, options);

    google.visualization.events.addListener(chart, 'select', selectHandler);

    function selectHandler() {
        var selectedItem = chart.getSelection()[0];
        if (selectedItem) {
            var id = data.getValue(selectedItem.row, 2);
            document.getElementById('film' + id).click();
        }
    }
}

function resizeChart() {
    drawChart();
}

if (document.addEventListener) {
    window.addEventListener('resize', resizeChart);
}
else if (document.attachEvent) {
    window.attachEvent('onresize', resizeChart);
}
else {
    window.resize = resizeChart;
}