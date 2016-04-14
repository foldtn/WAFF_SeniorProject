(function(){

    var Film = React.createClass({
        render() {
            return (
                <div>{this.props.length}</div>
            )
        }
    });

    var Block = React.creatClass({
        render() {
            return (
                <div></div>
            )
        }
    });

    window.AdminToolsContainer = React.createClass({

        render() {

            var blocks = viewModel.AdminBlockViewModels;

            var films = viewModel.Films;

            var blockElements = filmsArray.map((film, i) =>
                <Film length={film.FilmLength}
                      key={i} />
            );

            return (
                <div>{filmElements}</div>
            )
        }
    });

})(window.React);