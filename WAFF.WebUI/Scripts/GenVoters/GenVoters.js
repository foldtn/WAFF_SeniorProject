window.onload = function () {
    for (var x = 0; x <= 1000; x = x + 50) {
        var option = document.createElement("option");
        option.value = x;
        document.getElementById("NumberOfVoters").appendChild(option);
    }
}

function submit() {
    var numOfVoters = document.getElementById("numOfVoters").value;
}

function submitted() {

}