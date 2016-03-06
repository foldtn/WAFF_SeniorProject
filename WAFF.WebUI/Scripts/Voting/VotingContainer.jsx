(function () {

    var Film = React.createClass({
        render() {

            return (
                <div style={{border:'solid', display:'flex', flexDirection:'column',width:'25%', height:'100px', padding:'5px', margin:'5px'}}>
                    <div>{this.props.film.FilmName}</div>
                    <input type="radio"/>


                </div>
            )
        }
    });

    var Block = React.createClass({
        render(){
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

                <div style={{display:'flex', flexDirection:'column', border:'solid', justifyContent:'center',alignItems:'center', width:'75%'}}>

                       <div style={blockStyle}>
                           {filmElements}
                       </div>

                       <div style={{display:'flex',justifyContent:'center',alignItems:'center', padding:'10px'}}>
                        <input type="button" value="BLA"/>
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
