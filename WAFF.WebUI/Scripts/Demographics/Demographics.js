window.onload = function () {
    update();
}

function update() {
    var o = document.getElementById('events');
    var event = o.options[o.selectedIndex].value;

    document.getElementById('Income' + event).click();
    document.getElementById('Age' + event).click();
    document.getElementById('Education' + event).click();
    document.getElementById('Ethnicity' + event).click();
}