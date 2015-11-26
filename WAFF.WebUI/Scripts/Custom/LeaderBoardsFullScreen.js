function fullScreen(docElm) {
    if (document.getElementById("isFull").value === "no") {
        enterFull(docElm);
        document.getElementById("isFull").value = "yes";
        document.getElementById("mainNav").style.display = "none";
        document.getElementById("reportsNav").style.display = "none";
        document.getElementById("footer").style.display = "none";
        document.getElementById("toFull").innerHTML = "Exit Fullscreen"
    }
    else {
        exitFull();
        document.getElementById("isFull").value = "no";
        document.getElementById("mainNav").style.display = "inline";
        document.getElementById("reportsNav").style.display = "inline";
        document.getElementById("footer").style.display = "inline";
        document.getElementById("toFull").innerHTML = "Enter Fullscreen"
    }

}

function enterFull(docElm) {
    docElm = document.documentElement;
    if (docElm.requestFullscreen) {
        docElm.requestFullscreen();
    }
    else if (docElm.mozRequestFullScreen) {
        docElm.mozRequestFullScreen();
    }
    else if (docElm.webkitRequestFullScreen) {
        docElm.webkitRequestFullScreen();
    }
    else if (docElm.msRequestFullscreen) {
        docElm.msRequestFullscreen();
    }
}

function exitFull() {
    if (document.exitFullscreen) {
        document.exitFullscreen();
    }
    else if (document.mozCancelFullScreen) {
        document.mozCancelFullScreen();
    }
    else if (document.webkitCancelFullScreen) {
        document.webkitCancelFullScreen();
    }
    else if (document.msExitFullscreen) {
        document.msExitFullscreen();
    }
}

window.addEventListener("keypress", test, false);

function test(e) {
    alert(e.keyCode);
}