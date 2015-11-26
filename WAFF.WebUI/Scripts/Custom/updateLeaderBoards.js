
var tick = 5000;
var count = 0;

function update() {
    document.getElementById('counterTest').innerHTML = ++count;
    
    document.getElementById('updateLink').click();
}



window.onload = function () {
    update();
};

setInterval(update, tick);