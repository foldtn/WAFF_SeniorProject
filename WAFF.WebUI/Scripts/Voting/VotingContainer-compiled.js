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
                width: '75%',
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
                    { style: { fontSize: '1.4rem' } },
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
                flexDirection: 'column',
                width: '100%',
                height: '200px',
                padding: '5px',
                backgroundColor: '#f5f5f0'
            };

            var filmElements = this.props.films.map(function (film, i) {
                return React.createElement(Film, { film: film,
                    key: i,
                    onFilmChange: _this2._onFilmChange,
                    selected: _this2.state.selectedFilmId === film.FilmID });
            });

            var blockIdTag = this.props.blockId;

            return React.createElement(
                'div',
                { style: { display: 'flex',
                        flexDirection: 'column',
                        justifyContent: 'center',
                        alignItems: 'center',
                        width: '75%',
                        margin: '15px' },
                    className: 'panel panel-default',
                    id: blockIdTag },
                React.createElement('div', { id: 'timeInfo', style: { display: 'flex', justifyContent: 'center', alignItem: 'center' } }),
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
                            width: '100%',
                            flexDirection: 'column',
                            backgroundColor: '#f5f5f0' } },
                    React.createElement(
                        'div',
                        { className: 'well well-sm',
                            style: { display: 'flex',
                                justifyContent: 'center',
                                alignItems: 'center',
                                width: '65%',
                                padding: '1px' } },
                        React.createElement(
                            'h6',
                            null,
                            this.state.selectedFilmName
                        )
                    ),
                    React.createElement(
                        'button',
                        { type: 'button',
                            onClick: this._onVoteSubmit,
                            className: 'btn btn-lg btn-primary',
                            style: { width: '30%', backgroundColor: '#0d0d0d' } },
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
            var _this3 = this;

            //temp, was to see info is being passed
            //alert(this.state.selectedFilmId + " " + this.state.selectedBlockId);
            var filmId = this.state.selectedFilmId;
            var blockedId = this.state.selectedBlockId;

            if (filmId === 0 && blockedId === 0) {
                alert("Please pick a film to submit vote!");
                return false;
            }

            var href = window.location.href;
            var VoterId = href.substr(href.lastIndexOf('/') + 1);

            var voteArg = {
                FilmId: this.state.selectedFilmId,
                BlockId: this.state.selectedBlockId,
                VoterId: VoterId

            };

            //next is make ajax call!
            $.ajax({
                url: '/Vote/SubmitVote/',
                type: 'POST',
                data: voteArg,
                success: function success(data) {
                    return _this3._greyOutBlock(data, voteArg.BlockId);
                },
                error: function error(data) {
                    return _this3._greyOutBlock(data);
                }
            });
        },

        _greyOutBlock: function _greyOutBlock(data, blockId) {
            var thanks = "";

            if (data) {
                thanks = "<h1 class='text-center' style={{fontSize: '3rem'}}>Your vote has been saved <br/>Thank You!</h1>";
            } else thanks = "<h1 style={{fontSize: '4rem'}}>Thanks for voting!!</h1>";

            var killThisBlock = document.getElementById(blockId);

            killThisBlock.innerHTML = thanks;
        }
    });

    window.VotingContainer = React.createClass({
        displayName: 'VotingContainer',

        render: function render() {
            //eager loaded data
            var blocks = Blocks.Lists;

            var blocksAndFilms = blocks.map(function (array, i) {
                return React.createElement(Block, { films: array,
                    key: i,
                    blockId: array[0].BlockId });
            });

            return React.createElement(
                'div',
                { style: { display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center',
                        flexDirection: 'column',
                        backgroundColor: '#8a8a5c' } },
                blocksAndFilms
            );
        }
    });
})(window.React);

//# sourceMappingURL=VotingContainer-compiled.js.map