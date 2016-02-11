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
            return(
             <div style = {blockStyle}>
                 {this.props.filmName}
                 <div></div>
             </div>
            )

        }
    });





    window.VotingContainer= React.createClass({

        render(){
            return(
                <div style = {{display:'flex', justifyContent: 'center', alignItems: 'center', flexDirection: 'column'}}>
                    <Block filmName = " Late at Night" />
                    <Block filmName = " Pinocho"/>
                    <Block filmName = " Somenthing Crazy"/>
                    <Block filmName = " React is an array of weirdness"/>
                    <Block filmName = " Late at Night"/>
                </div>)
        }
    });


})(window.React);
