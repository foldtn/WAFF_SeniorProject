google.load("visualization", "1", { packages: ["corechart"] });

function drawChartIncome() {
    
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Income');
    data.addColumn('number', 'Number of Voters');

    data.addRow(['Less than $35,000', parseInt(document.getElementById('graphIncome0').value)]);
    data.addRow(['$35,000 to $50,000', parseInt(document.getElementById('graphIncome1').value)]);
    data.addRow(['$50,000 to $100,000', parseInt(document.getElementById('graphIncome2').value)]);
    data.addRow(['$100,000 to $150,000', parseInt(document.getElementById('graphIncome3').value)]);
    data.addRow(['$150,000 to $200,000', parseInt(document.getElementById('graphIncome4').value)]);
    data.addRow(['$200,000 & Up', parseInt(document.getElementById('graphIncome5').value)]);

    var options = {
        title: 'Block',
        height: '100%',
        width: '100%',
        sliceVisibilityThreshold: 0,
        chartArea: {

            left: "10%",
            top: "3%",
            height: "80%",
            width: "100%"
        }
    };

    var chart = new google.visualization.PieChart(document.getElementById('demoIncome'));
    chart.draw(data, options);
}

function drawChartAge() {

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Age');
    data.addColumn('number', 'Number of Voters');

    data.addRow(['19 & Younger', parseInt(document.getElementById('graphAge0').value)]);
    data.addRow(['20 to 29', parseInt(document.getElementById('graphAge1').value)]);
    data.addRow(['30 to 44', parseInt(document.getElementById('graphAge2').value)]);
    data.addRow(['45 to 54', parseInt(document.getElementById('graphAge3').value)]);
    data.addRow(['55 & Older', parseInt(document.getElementById('graphAge4').value)]);

    var options = {
        title: 'Block',
        height: '100%',
        width: '100%',
        sliceVisibilityThreshold: 0,
        chartArea: {

            left: "10%",
            top: "3%",
            height: "80%",
            width: "100%"
        }
    };

    var chart = new google.visualization.PieChart(document.getElementById('demoAge'));
    chart.draw(data, options);
}

function drawChartEducation() {

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Education');
    data.addColumn('number', 'Number of Voters');

    data.addRow(['High School Diploma', parseInt(document.getElementById('graphEducation0').value)]);
    data.addRow(['Some College', parseInt(document.getElementById('graphEducation1').value)]);
    data.addRow(["Bachelor's", parseInt(document.getElementById('graphEducation2').value)]);
    data.addRow(['Some Graduate School', parseInt(document.getElementById('graphEducation3').value)]);
    data.addRow(["Master's", parseInt(document.getElementById('graphEducation4').value)]);
    data.addRow(['Doctorate', parseInt(document.getElementById('graphEducation5').value)]);

    var options = {
        title: 'Block',
        height: '100%',
        width: '100%',
        sliceVisibilityThreshold: 0,
        chartArea: {

            left: "10%",
            top: "3%",
            height: "80%",
            width: "100%"
        }
    };

    var chart = new google.visualization.PieChart(document.getElementById('demoEducation'));
    chart.draw(data, options);
}

function drawChartEthnicity() {

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Ethnicity');
    data.addColumn('number', 'Number of Voters');

    data.addRow(['Native American/Alaska Native', parseInt(document.getElementById('graphEthnicity0').value)]);
    data.addRow(['Black/African American', parseInt(document.getElementById('graphEthnicity1').value)]);
    data.addRow(['Hispanic', parseInt(document.getElementById('graphEthnicity2').value)]);
    data.addRow(['Other/Multi-Racial', parseInt(document.getElementById('graphEthnicity3').value)]);
    data.addRow(['Asian/Pacific Islander', parseInt(document.getElementById('graphEthnicity4').value)]);
    data.addRow(['Caucasian', parseInt(document.getElementById('graphEthnicity5').value)]);
    data.addRow(['Prefer Not to Answer', parseInt(document.getElementById('graphEthnicity6').value)]);

    var options = {
        title: 'Block',
        height: '100%',
        width: '100%',
        sliceVisibilityThreshold: 0,
        chartArea: {

            left: "10%",
            top: "3%",
            height: "80%",
            width: "100%"
        }
    };

    var chart = new google.visualization.PieChart(document.getElementById('demoEthnicity'));
    chart.draw(data, options);
}

function resizeChart() {
    drawChartIncome();
    drawChartAge();
    drawChartEducation();
    drawChartEthnicity()
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