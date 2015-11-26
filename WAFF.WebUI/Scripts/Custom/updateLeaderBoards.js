
var tick = 5000;
var count = 0;

function update() {
    document.getElementById('counterTest').innerHTML = ++count;
}

setInterval(update, tick);