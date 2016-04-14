"use strict";

(function () {

    var Film = React.createClass({
        displayName: "Film",

        render: function render() {
            return React.createElement(
                "div",
                null,
                this.props.length
            );
        }
    });

    var Block = React.creatClass({
        render: function render() {
            return React.createElement("div", null);
        }
    });

    window.AdminToolsContainer = React.createClass({
        displayName: "AdminToolsContainer",

        render: function render() {

            var blocks = viewModel.AdminBlockViewModels;

            var films = viewModel.Films;

            var blockElements = filmsArray.map(function (film, i) {
                return React.createElement(Film, { length: film.FilmLength,
                    key: i });
            });

            return React.createElement(
                "div",
                null,
                filmElements
            );
        }
    });
})(window.React);

//# sourceMappingURL=AdminToolsContainer-compiled.js.map