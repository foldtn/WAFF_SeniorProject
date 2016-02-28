(function (){

    var Block = React.createClass({
        render(){
            var blockStyle = {
                border: 'solid',
                display: 'flex',
                justifyContent:'center',
                alignItems:'center',
                flexDirection:'column',
                width:'75%',
                height: '200px',
                padding: '5px'
            };
            var segOne = {
                display: 'flex',
                border: 'solid',
                justifyContent: 'flex-start',
                flexDirection: 'row',
                width: '75%',
                height: '100px',
                padding: '5px'
            };

            return(
             <div style = {blockStyle}>
                 {this.props.filmName}
                <div>
                    <div>
                        <ul>
                            <li style = {segOne}></li>
                        </ul>
                    </div>
                </div>

             </div>
            )
        }
    });





    window.VotingContainer= React.createClass({

        //Once the component is made , give me the state it should start in
        getInitialState() {
            return{
                BlockDetailList: []
            }
        },
        // Call this function when it mounts.
        componentDidMount(){
            this._getAllBlocksForEvents();
        },

        render(){
            return(
                <div>
                    <Block filmName = " Late at Night" />
                </div>)
        },

        //Where is this call going, if return right data do something
        _getAllBlocksForEvents()
        {
            var currentDate = new Date().toJSON();

            $.ajax({
                url: "/Vote/GetAllBlockForEvent/?currentDate=" + currentDate,
                success: function (data) {
                    this.setState({
                        BlockDetailList: data
                    })
                }
            })

        }
    });



})(window.React);
