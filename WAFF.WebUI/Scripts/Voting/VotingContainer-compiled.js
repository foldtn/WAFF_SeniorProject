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
            return React.createElement(
                'div',
                { style: blockStyle },
                this.props.filmName,
                React.createElement('div', null)
            );
        }
    });

    window.VotingContainer = React.createClass({
        displayName: 'VotingContainer',

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
        }
    });
})(window.React);

//# sourceMappingURL=VotingContainer-compiled.js.map