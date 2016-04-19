(function () {

    var Film = React.createClass({
        render() {

            var filmContain = {
                display: 'flex',
                flexDirection: 'row',
                border: 'solid 1px',
                padding: '5px',
                justifyContent: 'center',
                alignItems: 'center'
            };

            var filmInfoDiv = {
                display: 'flex',
                flexDirection: 'row',
                border: 'solid 1px',
                padding: '5px',
                justifyContent: 'center',
                alignItems: 'center'
            };

            return (
                <div style={filmContain}>
                    <div style={filmInfoDiv}>Name:{this.props.filmName}</div>
                    <div style={filmInfoDiv}>Duration:{this.props.filmDuration}</div>
                    <div>
                        <button type="button"
                                onClick={this._removeFilmFromBlock.bind(null, this.props.filmId)}
                                className="btn btn-lg btn-primary"
                                style={{backgroundColor:'#0d0d0d'}}>
                            Remove
                        </button>
                    </div>
                </div>
            )
        },

        _removeFilmFromBlock(filmId){
            var filmId = filmId;
            var blockId = this.props.blockId;

            var queryString = '?blockId=' + blockId +
                                '&filmId=' + filmId;

            $.ajax({
                url: '/Events/RemoveFilmFromBlock' + queryString,
                success: () => this._renewBlock(),
                error: (e) => console.log(e)
            })
        },

        _renewBlock() {
            this.props.getFilmsInBlock(this.props.blockId);
            this.props.calculateDurationRemaining();
        }
    });

    var Block = React.createClass({
        getInitialState() {
            return {
                selectedFilmId: 0,
                selectedBlockId: 0,
                currentDuration: 0,
                blockDuration: this.props.block.Duration,
                currentFilms: []
            }
        },

        componentWillMount(){
            this._getFilmsInBlock(this.props.block.BlockId);

        },

        componentDidMount() {
            this._calculateDurationRemaining()
        },

        render() {
            //region styles
            var containingBlock = {
                display: 'flex', flexDirection: 'row', border: 'solid 1px', padding: '10px', margin: '10px'
            };

            var insideBlock = {
                width: '75%',
                display: 'flex',
                flexDirection: 'column',
                border: 'solid 1px',
                justifyContent: 'center',
                alignItems: 'center'
            };

            var filmElementHolder = {
                display: 'flex', justifyContent: 'center', flexDirection: 'column'
            };
            //endregion

            var bInfo = this.props.block;
            var blockRef = "block" + bInfo.BlockId;

            var filmSelectElements = this.props.films.map(function (x, i) {
                return (
                    <option value={x.FilmID} key={i}>{x.FilmName}</option>
                )
            });

            var filmElements = this.state.currentFilms.map((film, i) =>
                <Film filmId={film.FilmId}
                      blockId={film.BlockId}
                      eventId={film.EventId}
                      filmDuration={film.FilmLength}
                      filmName={film.FilmName}
                      getFilmsInBlock={this._getFilmsInBlock}
                      calculateDurationRemaining={this._calculateDurationRemaining}
                      key={i}/>
            );

            return (
                <div style={containingBlock}>

                    <div style={insideBlock}>

                        <h4>Current Time Used: {this.state.currentDuration}</h4>

                        <h4>Total Block Duration: {bInfo.Duration}</h4>

                        <div id={blockRef} style={filmElementHolder}>
                            {filmElements}
                        </div>

                    </div>

                    <div style={{border: 'solid 1px', width:'25%'}}>

                        <div>
                            <select id="films" onChange={this._filmChange} value={this.state.value}>
                                <option value="0" selected="selected"></option>
                                {filmSelectElements}
                            </select>

                            <button onClick={this._addFilmToBlock}>
                                ADD FILM TO BLOCk
                            </button>
                        </div>

                    </div>
                </div>
            )
        },

        _filmChange(e){
            this.setState({selectedFilmId: e.target.value});
        },

        _addFilmToBlock(){

            if(this.state.selectedFilmId === 0) {
                alert("Please select a film to add!")
            }
            else {
                var selectedFilmId = this.state.selectedFilmId;
                var blockId = this.props.block.BlockId;

                $.ajax({
                    url: '/Events/AddFilmToBlock?blockId=' + blockId + '&filmId=' + selectedFilmId,
                    type: 'POST',
                    success: (data) => this._renewBlock(data),
                    error: (e) => console.log(e)
                });
            }

        },

        _renewBlock(blockId){
            this._getFilmsInBlock(blockId);
            this._calculateDurationRemaining();
        },

        _calculateDurationRemaining() {
            $.ajax({
                url: '/Events/GetBlockRemainingDuration?blockId=' + this.props.block.BlockId,
                success: (data) => this.setState({
                    currentDuration: data
                }),
                error: () => alert("error in setting current duration in block:" + this.props.block.BlockId)
            })
        },

        _getFilmsInBlock(blockId) {

            var queryString = '?blockId=' + blockId
                + '&eventId=' + viewModel.EventId;

            $.ajax({
                url: '/Events/GetBlocksCurrentFilms' + queryString,
                success: (data) => this.setState({
                    currentFilms: data
                }),
                error: () => alert("error")
            });
        }
    });

    window.AdminToolsContainer = React.createClass({

        render() {

            var blocks = viewModel.AdminBlockViewModels;

            var films = viewModel.Films;


            var blockElements = blocks.map((block, i) =>
                <Block films={films}
                       key={i}
                       block={block}/>
            );

            return (
                <div style={{display: 'flex', flexDirection:'column'}}>
                    {blockElements}
                </div>
            )
        }
    });

})(window.React);