'use strict';

(function () {

    var Film = React.createClass({
        displayName: 'Film',

        render: function render() {

            var filmContain = {
                display: 'flex',
                flexDirection: 'row',
                border: 'solid 1px',
                padding: '5px',
                justifyContent: 'center',
                alignItems: 'center'
            };

            var filmInfoDiv = {
                display: 'flex',
                flexDirection: 'row',
                border: 'solid 1px',
                padding: '5px',
                justifyContent: 'center',
                alignItems: 'center'
            };

            return React.createElement(
                'div',
                { style: filmContain },
                React.createElement(
                    'div',
                    { style: filmInfoDiv },
                    'Name:',
                    this.props.filmName
                ),
                React.createElement(
                    'div',
                    { style: filmInfoDiv },
                    'Duration:',
                    this.props.filmDuration
                ),
                React.createElement(
                    'div',
                    null,
                    React.createElement(
                        'button',
                        { type: 'button',
                            onClick: this._removeFilmFromBlock.bind(null, this.props.filmId),
                            className: 'btn btn-lg btn-primary',
                            style: { backgroundColor: '#0d0d0d' } },
                        'Remove'
                    )
                )
            );
        },

        _removeFilmFromBlock: function _removeFilmFromBlock(filmId) {
            var _this = this;

            var filmId = filmId;
            var blockId = this.props.blockId;

            var queryString = '?blockId=' + blockId + '&filmId=' + filmId;

            $.ajax({
                url: '/Events/RemoveFilmFromBlock' + queryString,
                success: function success() {
                    return _this._renewBlock();
                },
                error: function error(e) {
                    return console.log(e);
                }
            });
        },

        _renewBlock: function _renewBlock() {
            this.props.getFilmsInBlock(this.props.blockId);
            this.props.calculateDurationRemaining();
        }
    });

    var Block = React.createClass({
        displayName: 'Block',

        getInitialState: function getInitialState() {
            return {
                selectedFilmId: 0,
                selectedBlockId: 0,
                currentDuration: 0,
                blockDuration: this.props.block.Duration,
                currentFilms: []
            };
        },

        componentWillMount: function componentWillMount() {
            this._getFilmsInBlock(this.props.block.BlockId);
        },

        componentDidMount: function componentDidMount() {
            this._calculateDurationRemaining();
        },

        render: function render() {
            var _this2 = this;

            //region styles
            var containingBlock = {
                display: 'flex', flexDirection: 'row', border: 'solid 1px', padding: '10px', margin: '10px'
            };

            var insideBlock = {
                width: '75%',
                display: 'flex',
                flexDirection: 'column',
                border: 'solid 1px',
                justifyContent: 'center',
                alignItems: 'center'
            };

            var filmElementHolder = {
                display: 'flex', justifyContent: 'center', flexDirection: 'column'
            };
            //endregion

            var bInfo = this.props.block;
            var blockRef = "block" + bInfo.BlockId;

            var filmSelectElements = this.props.films.map(function (x, i) {
                return React.createElement(
                    'option',
                    { value: x.FilmID, key: i },
                    x.FilmName
                );
            });

            var filmElements = this.state.currentFilms.map(function (film, i) {
                return React.createElement(Film, { filmId: film.FilmId,
                    blockId: film.BlockId,
                    eventId: film.EventId,
                    filmDuration: film.FilmLength,
                    filmName: film.FilmName,
                    getFilmsInBlock: _this2._getFilmsInBlock,
                    calculateDurationRemaining: _this2._calculateDurationRemaining,
                    key: i });
            });

            return React.createElement(
                'div',
                { style: containingBlock },
                React.createElement(
                    'div',
                    { style: insideBlock },
                    React.createElement(
                        'h4',
                        null,
                        'Current Time Used: ',
                        this.state.currentDuration
                    ),
                    React.createElement(
                        'h4',
                        null,
                        'Total Block Duration: ',
                        bInfo.Duration
                    ),
                    React.createElement(
                        'div',
                        { id: blockRef, style: filmElementHolder },
                        filmElements
                    )
                ),
                React.createElement(
                    'div',
                    { style: { border: 'solid 1px', width: '25%' } },
                    React.createElement(
                        'div',
                        null,
                        React.createElement(
                            'select',
                            { id: 'films', onChange: this._filmChange, value: this.state.value },
                            React.createElement('option', { value: '0', selected: 'selected' }),
                            filmSelectElements
                        ),
                        React.createElement(
                            'button',
                            { onClick: this._addFilmToBlock },
                            'ADD FILM TO BLOCk'
                        )
                    )
                )
            );
        },

        _filmChange: function _filmChange(e) {
            this.setState({ selectedFilmId: e.target.value });
        },

        _addFilmToBlock: function _addFilmToBlock() {
            var _this3 = this;

            if (this.state.selectedFilmId === 0) {
                alert("Please select a film to add!");
            } else {
                var selectedFilmId = this.state.selectedFilmId;
                var blockId = this.props.block.BlockId;

                $.ajax({
                    url: '/Events/AddFilmToBlock?blockId=' + blockId + '&filmId=' + selectedFilmId,
                    type: 'POST',
                    success: function success(data) {
                        return _this3._renewBlock(data);
                    },
                    error: function error(e) {
                        return console.log(e);
                    }
                });
            }
        },

        _renewBlock: function _renewBlock(blockId) {
            this._getFilmsInBlock(blockId);
            this._calculateDurationRemaining();
        },

        _calculateDurationRemaining: function _calculateDurationRemaining() {
            var _this4 = this;

            $.ajax({
                url: '/Events/GetBlockRemainingDuration?blockId=' + this.props.block.BlockId,
                success: function success(data) {
                    return _this4.setState({
                        currentDuration: data
                    });
                },
                error: function error() {
                    return alert("error in setting current duration in block:" + _this4.props.block.BlockId);
                }
            });
        },

        _getFilmsInBlock: function _getFilmsInBlock(blockId) {
            var _this5 = this;

            var queryString = '?blockId=' + blockId + '&eventId=' + viewModel.EventId;

            $.ajax({
                url: '/Events/GetBlocksCurrentFilms' + queryString,
                success: function success(data) {
                    return _this5.setState({
                        currentFilms: data
                    });
                },
                error: function error() {
                    return alert("error");
                }
            });
        }
    });

    window.AdminToolsContainer = React.createClass({
        displayName: 'AdminToolsContainer',

        render: function render() {

            var blocks = viewModel.AdminBlockViewModels;

            var films = viewModel.Films;

            var blockElements = blocks.map(function (block, i) {
                return React.createElement(Block, { films: films,
                    key: i,
                    block: block });
            });

            return React.createElement(
                'div',
                { style: { display: 'flex', flexDirection: 'column' } },
                blockElements
            );
        }
    });
})(window.React);

//# sourceMappingURL=AdminToolsContainer-compiled.js.map