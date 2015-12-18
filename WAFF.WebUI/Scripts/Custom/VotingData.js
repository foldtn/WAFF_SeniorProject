window.onload = function () {
    document.getElementById('blockR').click();
    document.getElementById('InitialBlocks').click();
};

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
        document.getElementById('InitialBlocks').click();
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
        document.getElementById('InitialGenres').click();
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
}

function selectedGenre(genre) {

    var current = document.getElementById('currentGenre').value;

    document.getElementById(current).style.textDecoration = 'none';
    document.getElementById(genre).style.textDecoration = 'underline';
    document.getElementById('currentGenre').value = genre;
}



