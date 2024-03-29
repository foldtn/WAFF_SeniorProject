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
                    <div style={{fontSize: '1.4rem'}}>{this.props.film.FilmName}</div>
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
                width: '100%',
                height: '200px',
                padding: '5px',
                backgroundColor:'#f5f5f0'
            };

            var filmElements = this.props.films.map((film, i) =>
                <Film film={film}
                      key={i}
                      onFilmChange={this._onFilmChange}
                      selected={this.state.selectedFilmId === film.FilmID}/>
            );

            var blockIdTag = this.props.blockId;

            var blockDay = this.props.films[0].BlockDay;
            var blockStart = this.props.films[0].BlockStartString;
            var blockEnd = this.props.films[0].BlockEndString;

            return (

                <div style={{display:'flex',
                             flexDirection:'column',
                             justifyContent:'center',
                             alignItems:'center',
                             width:'75%',
                             margin: '15px',
                             backgroundColor: '#f5f5f0'}}
                     className="panel panel-default"
                     id={blockIdTag}>

                    <div id="timeInfo"
                         style={{display:'flex', justifyContent:'center', alignItem: 'center', flexDirection: 'column',backgroundColor:'#f5f5f0'}}>
                        <div>
                            {blockDay}
                        </div>
                        <div style={{textAlign:'center'}}>
                            {blockStart + "-" + blockEnd}
                        </div>
                    </div>

                    <div style={blockStyle}>
                        {filmElements}
                    </div>

                    <div style={{display:'flex',
                                    justifyContent:'center',
                                    alignItems:'center',
                                    padding:'10px',
                                    width: '100%',
                                    flexDirection: 'column',
                                    backgroundColor:'#f5f5f0'}}>
                        <div className="well well-sm"
                             style={{display:'flex',
                                        justifyContent: 'center',
                                        alignItems: 'center',
                                        width: '65%',
                                        padding: '1px'}}>
                            <h6>{this.state.selectedFilmName}</h6>
                        </div>

                        <button type="button"
                                onClick={this._onVoteSubmit}
                                className="btn btn-lg btn-primary"
                                style={{width:'30%',backgroundColor:'#0d0d0d'}}>
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
                thanks = "<h1 class='text-center' style={{fontSize: '3rem'}}>Your vote has been saved <br/>Thank You!</h1>"
            } else  (
                thanks = "<h1 style={{fontSize: '4rem'}}>Thanks for voting!!</h1>"
            )

            var killThisBlock = document.getElementById(blockId);

            killThisBlock.innerHTML = thanks;
        }
    });

    window.VotingContainer = React.createClass({

        render(){
            //eager loaded data
            var model = VoteDetail.Model;

            var blocksAndFilms = model.BlockViewModels.map((array, i) =>
                <Block films={array}
                       key={i}
                       blockId={array[0].BlockId}/>
            );

            return (
                <div style={{display:'flex',
                             justifyContent: 'center',
                             alignItems: 'center',
                             flexDirection: 'column',
                             backgroundColor:'#8a8a5c'}}>

                    {model.Voter.VoterFirstTimer ?
                    this._renderDemoForm()
                    :
                        <div></div>
                    }

                    {blocksAndFilms}
                </div>)
        },
            _renderDemoForm(){
                //styles
                var demoBox = {
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    width: '50%',
                    flexDirection: 'column'
                    // border: 'solid 1px'
                };

                var inputBox = {
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    width: '75%',
                    border: 'solid 1px'
                };

                return (
                    <div style={demoBox} id="demoSubmitBox">
                        <div className="input-group" style={{padding: '5px', margin: '5px'}}>
                            <span className="input-group-addon" id="basic-addon3">Your Age:</span>
                            <input type="text" className="form-control" id="inputAge" aria-describedby="basic-addon3" />
                        </div>
                        <div className="input-group" style={{padding: '5px', margin: '5px'}}>
                            <span className="input-group-addon" id="basic-addon3">Your Ethnicity: </span>
                            <input type="text" className="form-control" id="inputEthnicity" aria-describedby="basic-addon3" />
                        </div>
                        <div className="input-group" style={{padding: '5px', margin: '5px'}}>
                            <span className="input-group-addon" id="basic-addon3">Your Education: </span>
                            <input type="text" className="form-control" id="inputEducation" aria-describedby="basic-addon3" />
                        </div>
                        <div className="input-group" style={{padding: '5px', margin: '5px'}}>
                            <span className="input-group-addon" id="basic-addon3">Your Income: </span>
                            <input type="text" className="form-control" id="inputIncome" aria-describedby="basic-addon3" />
                        </div>
                        <button type="button"
                                onClick={this._onDemoSubmit}
                                className="btn btn-lg btn-primary"
                                style={{width:'30%',backgroundColor:'#0d0d0d'}}>
                            Submit Info
                        </button>
                    </div>

                )
            },

            _onDemoSubmit(){
                var voterAge = document.getElementById("inputAge").value;
                var voterEthnicity = document.getElementById("inputEthnicity").value;
                var voterEducation = document.getElementById("inputEducation").value;
                var voterIncome = document.getElementById("inputIncome").value;

                var voterInfo = {
                    VoterID: VoteDetail.Model.Voter.VoterID,
                    VoterAge: voterAge,
                    VoterEthnicity: voterEthnicity,
                    VoterEducation: voterEducation,
                    VoterIncome: voterIncome
                };

                $.ajax({
                    url: '/Vote/SubmitDemoInfo/',
                    type: 'POST',
                    data: voterInfo,
                    success:() => this._greyOutDemoBlock(),
                    error:() => alert("error?")
                })
            },

            _greyOutDemoBlock() {
                //demoSubmitBox
                var thanks = "";

                if(true){
                    thanks = "<h1 class='text-center' style={{fontSize: '3rem'}}>Your info has been saved <br/>Thank You!</h1>"
                } else  (
                    thanks = "<h1 style={{fontSize: '4rem'}}>Thanks for submitting your info!</h1>"
                );

                var killThisBlock = document.getElementById("demoSubmitBox");

                killThisBlock.innerHTML = thanks;
        }
    });

})(window.React);
