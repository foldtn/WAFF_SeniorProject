'use strict';

(function () {

    var Film = React.createClass({
        displayName: 'Film',

        getInitialState: function getInitialState() {
            return {
                selected: false
            };
        },
        render: function render() {

            var filmInfoStyle = {
                display: 'flex',
                flexDirection: 'column',
                width: '25%',
                height: '100px',
                padding: '5px',
                margin: '5px',
                justifyContent: 'center',
                alignItems: 'center'
            };

            return React.createElement(
                'button',
                { style: filmInfoStyle,
                    className: 'btn btn-out',
                    onClick: this._setFilmSelected },
                React.createElement(
                    'div',
                    { style: { fontSize: '2.25rem' } },
                    this.props.film.FilmName
                )
            );
        },

        _setFilmSelected: function _setFilmSelected() {
            var _this = this;

            var nextSelected = !this.state.selected;

            this.setState({
                selected: nextSelected
            }, function () {
                _this.props.onFilmChange(_this.props.film.FilmId, _this.props.film.BlockId, _this.props.film.FilmName);
            });
        }
    });

    var Block = React.createClass({
        displayName: 'Block',

        getInitialState: function getInitialState() {
            return {
                selectedFilmId: 0,
                selectedBlockId: 0,
                selectedFilmName: ''
            };
        },
        render: function render() {
            var _this2 = this;

            var blockStyle = {
                // border: 'solid',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'row',
                width: '98%',
                height: '200px',
                padding: '5px'
            };

            var filmElements = this.props.films.map(function (film, i) {
                return React.createElement(Film, { film: film,
                    key: i,
                    onFilmChange: _this2._onFilmChange,
                    selected: _this2.state.selectedFilmId === film.FilmID });
            });

            return React.createElement(
                'div',
                { style: { display: 'flex',
                        flexDirection: 'column',
                        justifyContent: 'center',
                        alignItems: 'center',
                        width: '75%',
                        margin: '15px' },
                    className: 'panel panel-default' },
                React.createElement(
                    'div',
                    { style: blockStyle },
                    filmElements
                ),
                React.createElement(
                    'div',
                    { style: { display: 'flex',
                            justifyContent: 'center',
                            alignItems: 'center',
                            padding: '10px',
                            width: '75%',
                            flexDirection: 'column' } },
                    React.createElement(
                        'div',
                        { className: 'well well-sm',
                            style: { display: 'flex',
                                justifyContent: 'center',
                                alignItems: 'center',
                                width: '75%',
                                padding: '1px' } },
                        React.createElement(
                            'h3',
                            null,
                            this.state.selectedFilmName
                        )
                    ),
                    React.createElement(
                        'button',
                        { type: 'button',
                            onclick: this._onVoteSubmit,
                            className: 'btn btn-lg btn-primary',
                            style: { width: '75%' } },
                        'Vote'
                    )
                )
            );
        },

        _onFilmChange: function _onFilmChange(filmId, blockId, filmName) {

            this.setState({
                selectedFilmId: filmId,
                selectedBlockId: blockId,
                selectedFilmName: filmName
            });
        },

        _onVoteSubmit: function _onVoteSubmit() {
            //temp, was to see info is being passed
            alert(this.state.selectedFilmId + " " + this.state.selectedBlockId);

            //next is make ajax call!
        }
    });

    window.VotingContainer = React.createClass({
        displayName: 'VotingContainer',

        render: function render() {
            //eager loaded data
            var blocks = Blocks.Lists;

            var blocksAndFilms = blocks.map(function (array, i) {
                return React.createElement(Block, { films: array,
                    key: i });
            });

            return React.createElement(
                'div',
                { style: { display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        flexDirection: 'column' } },
                blocksAndFilms
            );
        }
    });
})(window.React);

//# sourceMappingURL=VotingContainer-compiled.js.map