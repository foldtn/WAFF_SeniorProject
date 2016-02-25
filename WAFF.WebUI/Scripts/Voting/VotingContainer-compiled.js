'use strict';

(function () {

    var Block = React.createClass({
        displayName: 'Block',

        render: function render() {
            var blockStyle = {
                border: 'solid',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                flexDirection: 'column',
                width: '75%',
                height: '200px',
                padding: '5px'
            };

            var filmSegment = {
                border: 'solid',
                display: 'flex',
                justifyContent: 'flex-start',
                flexDirection: 'row',
                alignItems: 'flex-start',
                width: '25%',
                height: '180px',
                padding: '5px'
            };
            return React.createElement(
                'div',
                { style: blockStyle },
                this.props.filmName,
                React.createElement(
                    'div',
                    { style: filmSegment },
                    React.createElement(
                        'div',
                        null,
                        React.createElement(
                            'ul',
                            null,
                            React.createElement(
                                'li',
                                null,
                                '1'
                            )
                        )
                    )
                )
            );
        }
    });

    window.VotingContainer = React.createClass({
        displayName: 'VotingContainer',

        //Once the component is made , give me the state it should start in
        getInitialState: function getInitialState() {
            return {
                BlockDetailList: []
            };
        },
        // Call this function when it mounts.
        componentDidMount: function componentDidMount() {
            this._getAllBlocksForEvents();
        },

        render: function render() {
            return React.createElement(
                'div',
                { style: { display: 'flex', justifyContent: 'center', alignItems: 'center', flexDirection: 'column' } },
                React.createElement(Block, { filmName: ' Late at Night' }),
                React.createElement(Block, { filmName: ' Pinocho' }),
                React.createElement(Block, { filmName: ' Somenthing Crazy' }),
                React.createElement(Block, { filmName: ' React is an array of weirdness' }),
                React.createElement(Block, { filmName: ' Late at Night' })
            );
        },

        //Where is this call going, if return right data do something
        _getAllBlocksForEvents: function _getAllBlocksForEvents() {
            var currentDate = new Date().toJSON();

            $.ajax({
                url: "/Vote/GetAllBlockForEvent/?currentDate=" + currentDate,
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