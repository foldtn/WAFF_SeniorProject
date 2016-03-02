(function () {

    var Film = React.createClass({
        render() {
            return (
                <div style={{display:'flex', flexDirection:'row'}}>
                    {this.props.film.FilmName}
                </div>
            )
        }
    });

    var Block = React.createClass({
        render(){
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

            var filmElements = this.props.films.map(film =>
                <Film film={film} />
            );

            return (
                <div style={blockStyle}>
                    <div>
                        {filmElements}
                    </div>
                </div>
            )

        }
    });

    window.VotingContainer = React.createClass({


        getInitialState() {
            return {
                BlockDetailList: []
            }
        },

        componentDidMount(){

        },

        render(){
            var blocks = Blocks.Lists;

            var blocksAndFilms = blocks.map(array =>
                <Block films={array} />
            );

            return (
                <div style={{display:'flex', justifyContent: 'center', alignItems: 'center', flexDirection: 'column'}}>
                    {blocksAndFilms}
                </div>)
        },

        _getAllBlocksForEvent() {
            var currentDate = new Date().toJSON();

            $.ajax({
                url: "/Vote/GetAllBlocksForEvent/?currentDate=" + currentDate,
                success: function (data) {
                    this.setState({
                        BlockDetailList: data
                    })
                }
            })
        }

    });


})(window.React);
