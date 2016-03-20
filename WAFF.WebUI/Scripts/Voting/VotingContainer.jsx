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
              width: '75%',
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
                    <div style={{fontSize: '1rem'}}>{this.props.film.FilmName}</div>
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
                flexDirection: 'column',
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

            var blockIdTag = this.props.blockId;

            return (

                <div style={{display:'flex',
                             flexDirection:'column',
                             justifyContent:'center',
                             alignItems:'center',
                             width:'75%',
                             margin: '15px'}}
                     className="panel panel-default"
                     id={blockIdTag}>

                    <div id="timeInfo" style={{display:'flex', justifyContent:'center', alignItem: 'center'}}>
                    </div>

                    <div style={blockStyle}>
                        {filmElements}
                    </div>

                    <div style={{display:'flex',
                                    justifyContent:'center',
                                    alignItems:'center',
                                    padding:'10px',
                                    width: '100%',
                                    flexDirection: 'column'}}>
                        <div className="well well-sm"
                             style={{display:'flex',
                                        justifyContent: 'center',
                                        alignItems: 'center',
                                        width: '75%',
                                        padding: '1px'}}>
                            <h4>{this.state.selectedFilmName}</h4>
                        </div>

                        <button type="button"
                                onClick={this._onVoteSubmit}
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
            //alert(this.state.selectedFilmId + " " + this.state.selectedBlockId);
            var filmId = this.state.selectedFilmId;
            var blockedId = this.state.selectedBlockId;

            if (filmId === 0 && blockedId === 0){
                alert("Please pick a film to submit vote!");
                return false;
            }

            var href = window.location.href;
            var VoterId = href.substr(href.lastIndexOf('/') + 1);

            var voteArg = {
                FilmId: this.state.selectedFilmId,
                BlockId: this.state.selectedBlockId,
                VoterId : VoterId

            };

            //next is make ajax call!
            $.ajax({
                url: '/Vote/SubmitVote/',
                type: 'POST',
                data: voteArg,
                success:(data) => this._greyOutBlock(data, voteArg.BlockId),
                error:(data) => this._greyOutBlock(data)
            })
        },

        _greyOutBlock(data, blockId){
            var thanks = "";

            if(data){
                thanks = "<h1 style={{fontSize: '3.5rem'}}>A vote for that film and block has already been saved!</h1>"
            } else  (
                thanks = "<h1 style={{fontSize: '5rem'}}>Thanks fpr voting!!</h1>"
            )

            var killThisBlock = document.getElementById(blockId);

            killThisBlock.innerHTML = thanks;
        }
    });

    window.VotingContainer = React.createClass({

        render(){
            //eager loaded data
            var blocks = Blocks.Lists;

            var blocksAndFilms = blocks.map((array, i) =>
                <Block films={array}
                       key={i}
                       blockId={array[0].BlockId}/>
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
