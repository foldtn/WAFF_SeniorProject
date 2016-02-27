
var tick = 5000;

function update() {
    var o = document.getElementById('events');
    var event = o.options[o.selectedIndex].value;
    
    document.getElementById('Event' + event).click();
}

window.onload = function () {
    document.getElementById('eventLoadSelect').click();
    document.getElementById('eventLoadLB').click();
    
};

function beginUpdate()
{
    update();
    setInterval(update, tick);
}


