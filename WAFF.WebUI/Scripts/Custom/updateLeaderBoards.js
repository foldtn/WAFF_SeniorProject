
var tick = 5000;

function update() {
    
    document.getElementById('updateLink').click();
}

window.onload = function () {
    update();
};

setInterval(update, tick);