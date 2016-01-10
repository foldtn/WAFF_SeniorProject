function fullScreen(docElm) {
    if (document.getElementById("isFull").value === "no") {
        enterFull(docElm);
        document.getElementById("isFull").value = "yes";
        document.getElementById("mainNav").style.display = "none";
        //document.getElementById("reportsNav").style.display = "none";
        document.getElementById("footer").style.display = "none";
        document.getElementById("girlImageLayout").style.display = "none";
        document.getElementById("lbHeader").style.display = "none";
        document.getElementById("lbImgHeader").style.display = "inline";
        document.getElementById("toFull").style.display = "none";
        //document.getElementById("toFull").innerHTML = "Exit Fullscreen";
    }
    else {
        exitFull();
        document.getElementById("isFull").value = "no";
        document.getElementById("mainNav").style.display = "inline";
        //document.getElementById("reportsNav").style.display = "inline";
        document.getElementById("footer").style.display = "inline";
        document.getElementById("girlImageLayout").style.display = "inline";
        
        document.getElementById("lbImgHeader").style.display = "none";
        document.getElementById("lbHeader").style.display = "block";
        document.getElementById("toFull").style.display = "inline";
        //document.getElementById("toFull").innerHTML = "Enter Fullscreen";
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

//Used for exiting fullscreen using esc or other means.
if (document.addEventListener)
{
    document.addEventListener('webkitfullscreenchange', handler, false);
    document.addEventListener('moxfullscreenchange', handler, false);
    document.addEventListener('fullscreenchange', handler, false);
    document.addEventListener('MSFullscreenChange', handler, false);
}

function handler()
{
    /*if (document.webkitIsFullScreen || document.mozFullScreen
        || document.msFullscreenElement !== null)
    {
        // 0 means not fullscreen, 1 means fullscreen
        if (document.getElementById("test").value == 0)
        {
            document.getElementById("test").value = 1;
        }
        else
        {
            document.getElementById("test").value = 0;
            document.getElementById("isFull").value = "yes";
            fullScreen("fullScreen");
        }
        
    }*/

    // 0 means not fullscreen, 1 means fullscreen
    if (document.getElementById("test").value == 0) {
        document.getElementById("test").value = 1;
    }
    else {
        document.getElementById("test").value = 0;
        document.getElementById("isFull").value = "yes";
        fullScreen("fullScreen");
    }

}