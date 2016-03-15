(function () {

    var Film = React.createClass({
        getInitialState(){
            return {
                selected: false
            }
        },
        render() {

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

            return (
                <button style={filmInfoStyle}
                    className="btn btn-out"
                    onClick={this._setFilmSelected}>
                    <div style={{fontSize: '2.25rem'}}>{this.props.film.FilmName}</div>
                </button>
            )
        },

        _setFilmSelected(){
            var nextSelected = !this.state.selected;

            this.setState({
                selected: nextSelected
            }, () => {
                this.props.onFilmChange(this.props.film.FilmId, this.props.film.BlockId, this.props.film.FilmName)
            });
        }
    });

    var Block = React.createClass({

        getInitialState(){
          return {
              selectedFilmId: 0,
              selectedBlockId: 0,
              selectedFilmName: ''
          }
        },
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

            var filmElements = this.props.films.map((film, i) =>
                <Film film={film}
                      key={i}
                      onFilmChange={this._onFilmChange}
                      selected={this.state.selectedFilmId === film.FilmID}/>
            );

            return (

                <div style={{display:'flex',
                             flexDirection:'column',
                             justifyContent:'center',
                             alignItems:'center',
                             width:'75%',
                             margin: '15px'}}
                     className="panel panel-default">

                    <div style={blockStyle}>
                        {filmElements}
                    </div>

                    <div style={{display:'flex',
                                    justifyContent:'center',
                                    alignItems:'center',
                                    padding:'10px',
                                    width: '75%',
                                    flexDirection: 'column'}}>
                        <div className="well well-sm"
                             style={{display:'flex',
                                        justifyContent: 'center',
                                        alignItems: 'center',
                                        width: '75%',
                                        padding: '1px'}}>
                            <h3>{this.state.selectedFilmName}</h3>
                        </div>

                        <button type="button"
                                onclick={this._onVoteSubmit}
                                className="btn btn-lg btn-primary"
                                style={{width:'75%'}}>
                            Vote
                        </button>
                    </div>
                </div>
            )

        },

        _onFilmChange(filmId, blockId, filmName){

            this.setState({
                selectedFilmId: filmId,
                selectedBlockId: blockId,
                selectedFilmName: filmName
            });
        },

        _onVoteSubmit(){
            //temp, was to see info is being passed
            alert(this.state.selectedFilmId + " " + this.state.selectedBlockId);

            //next is make ajax call!
        }
    });

    window.VotingContainer = React.createClass({

        render(){
            //eager loaded data
            var blocks = Blocks.Lists;

            var blocksAndFilms = blocks.map((array, i) =>
                <Block films={array}
                       key={i}/>
            );

            return (
                <div style={{display:'flex',
                             justifyContent: 'center',
                             alignItems: 'center',
                             flexDirection: 'column'}}>

                    {blocksAndFilms}
                </div>)
        },
    });

})(window.React);
