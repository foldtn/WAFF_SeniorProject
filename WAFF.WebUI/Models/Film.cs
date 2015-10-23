using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAFF.WebUI.Models
{
    public class Film
    {
    public int VoteId { get; set; }
    public string VoteComment { get; set; }
    public DateTime VoteTimeStamp { get; set; }
    public int VoterId { get; set; }
    public int FilmId { get; set; }
    }
}