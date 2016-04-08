window.onload = function () {
    document.getElementById('blockR').click();
    update();
    //document.getElementById('InitialBlocks').click();
};

function update() {
    var o = document.getElementById('events');
    var event = o.options[o.selectedIndex].value;

    document.getElementById('InitialBlocks' + event).click();
       
    document.getElementById('blockR').click();
}

function changeB() {
    var radio = document.getElementsByName('radioVD');

    //if 'checked'
    if (radio[0].value == 0) {
        //do nothing
    }
    else //if 'not checked'
    {
        //make it checked and uncheck the other one, then display blocks
        radio[0].value = 0;
        radio[1].value = 1;
        
        update();
        drawChart();
    } 
}

function changeG() {
    var radio = document.getElementsByName('radioVD');

    //if 'checked'
    if (radio[1].value == 0) {
        //do nothing
    }
    else //if 'not checked'
    {
        //make it checked and uncheck the other one, then display genres
        radio[0].value = 1;
        radio[1].value = 0;

        var o = document.getElementById('events');
        var event = o.options[o.selectedIndex].value;

        document.getElementById('InitialGenres' + event).click();
        drawChart();
    }
}

function InitialFilmsBlock() {
    var block = document.getElementById('currentBlock').value;
    document.getElementById('block' + block).click();
    document.getElementById('headerBG').innerHTML = 'Block';
    //selectedBlock(block);
}

function InitialFilmsGenre() {
    var genre = document.getElementById('currentGenre').value;
    document.getElementById(genre).click();
    document.getElementById('headerBG').innerHTML = 'Genre';
    //selectedGenre(genre);
}

function selectedBlock(block) {

    var current = document.getElementById('currentBlock').value;

    document.getElementById('block' + current).style.textDecoration = 'none';
    document.getElementById('block' + block).style.textDecoration = 'underline';
    document.getElementById('currentBlock').value = block;

    document.getElementById('GraphB' + block).click();
    document.getElementById('chartTitle').innerHTML = "Block " + block;

}

function selectedGenre(genre) {

    var current = document.getElementById('currentGenre').value;

    document.getElementById(current).style.textDecoration = 'none';
    document.getElementById(genre).style.textDecoration = 'underline';
    document.getElementById('currentGenre').value = genre;

    document.getElementById('GraphG' + genre).click();
    document.getElementById('chartTitle').innerHTML = genre;
}

function selectedFilm(film) {
    var current = document.getElementById('currentFilm').value;

    document.getElementById('film' + current).style.textDecoration = 'none';
    document.getElementById('film' + film).style.textDecoration = 'underline';
    document.getElementById('currentFilm').value = film;

    selectSlice(film);
}
