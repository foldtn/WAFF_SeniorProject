'use strict';

(function () {

    var Film = React.createClass({
        displayName: 'Film',

        render: function render() {
            return React.createElement(
                'div',
                { style: { border: 'solid', display: 'flex', flexDirection: 'column' } },
                this.props.film.FilmName
            );
        }
    });

    var Block = React.createClass({
        displayName: 'Block',

        render: function render() {
            var blockStyle = {
                border: 'solid',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'row',
                width: '75%',
                height: '200px',
                padding: '5px'
            };

            /*var filmElementStyle = {
              border:'solid',
              float:'left',
              display:'flex',
              justifyContent:'flex-start',
              alignItems:'flex-start',
              flexDirection:'row',
              width:'25%',
              height:'100px',
              padding:'5px'
            };*/

            var filmElements = this.props.films.map(function (film) {
                return React.createElement(Film, { film: film });
            });

            return React.createElement(
                'div',
                { style: blockStyle },
                React.createElement(
                    'div',
                    null,
                    filmElements
                )
            );
        }
    });

    window.VotingContainer = React.createClass({
        displayName: 'VotingContainer',

        getInitialState: function getInitialState() {
            return {
                BlockDetailList: []
            };
        },

        componentDidMount: function componentDidMount() {},

        render: function render() {
            var blocks = Blocks.Lists;

            var blocksAndFilms = blocks.map(function (array) {
                return React.createElement(Block, { films: array });
            });

            return React.createElement(
                'div',
                { style: { display: 'flex', justifyContent: 'center', alignItems: 'center', flexDirection: 'column' } },
                blocksAndFilms
            );
        },

        _getAllBlocksForEvent: function _getAllBlocksForEvent() {
            var currentDate = new Date().toJSON();

            $.ajax({
                url: "/Vote/GetAllBlocksForEvent/?currentDate=" + currentDate,
                success: function success(data) {
                    this.setState({
                        BlockDetailList: data
                    });
                }
            });
        }

    });
})(window.React);

//# sourceMappingURL=VotingContainer-compiled.js.map