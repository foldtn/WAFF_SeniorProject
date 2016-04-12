using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WAFF.DataAccess.Contexts;
using WAFF.DataAccess.ViewModels;
using WAFF.DataAccess.ViewModels.Voting_Data;
using WAFF.DataAccess.ViewModels.Leader_Boards;
using WAFF.DataAccess.ViewModels.Demographics;
using WAFF.DataAccess.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace WAFF.Services.Reports
{
    public class ReportService
    {
        private EFDbContext _db = new EFDbContext();

        public List<LeaderBoardEntry> LeaderBoards(int EventID)
        {
            // declare variables
            List<LeaderBoardEntry> finalList = new List<LeaderBoardEntry>();
            List<FilmBlock> tempChosen = new List<FilmBlock>();

            List<FilmBlock> filler = new List<FilmBlock>();
            List<List<FilmBlock>> temp = new List<List<FilmBlock>>();

            List<VotesLB> filler2 = new List<VotesLB>();
            List<List<VotesLB>> tempVotes = new List<List<VotesLB>>();

            //int tempEvent = 1;

            var list = getLBData(EventID);

            // splits duplicates and non-duplicates
            temp = getDuplicates(list);
            // gets votes for duplicates
            tempVotes.Add(getVotesForList(temp[0]));
            // gets top block for each duplicate
            tempChosen = getChosenFilms(tempVotes[0]);

            tempVotes = new List<List<VotesLB>>();
            // gets votes for the "chosen" block for each duplicate
            tempVotes.Add(getVotesForList(tempChosen));
            // gets votes for non-duplicates
            tempVotes.Add(getVotesForList(temp[1]));

            finalList = getFinalList(tempVotes[0], tempVotes[1]);

            return finalList;
        }

        private List<LeaderBoardEntry> getFinalList(List<VotesLB> duplicates, List<VotesLB> nonDuplicates)
        {
            List<LeaderBoardEntry> tempFinal = new List<LeaderBoardEntry>();
            LeaderBoardEntry tempEntry = new LeaderBoardEntry();
            LeaderBoardData temp = new LeaderBoardData();
            decimal tempVotePercentage = 0;

            for (int x = 0; x < nonDuplicates.Count; x++)
            {
                temp = getFilmData(nonDuplicates[x].FilmID, nonDuplicates[x].BlockID);
                tempVotePercentage = (decimal)nonDuplicates[x].Votes / (decimal)nonDuplicates[x].VotesPerBlock;

                tempEntry.FilmName = temp.FilmName;
                tempEntry.FilmGenre = temp.FilmGenre;
                tempEntry.BlockID = temp.BlockID;
                tempEntry.BlockStart = temp.BlockStart;
                tempEntry.BlockEnd = temp.BlockEnd;
                tempEntry.BlockDayOfWeek = temp.BlockDayOfWeek;
                tempEntry.VotePercentage = tempVotePercentage * 100;

                tempFinal.Add(tempEntry);

                tempEntry = new LeaderBoardEntry();
                temp = new LeaderBoardData();
            }

            for (int x = 0; x < duplicates.Count; x++)
            {
                temp = getFilmData(duplicates[x].FilmID, duplicates[x].BlockID);
                tempVotePercentage = (decimal)duplicates[x].Votes / (decimal)duplicates[x].VotesPerBlock;

                tempEntry.FilmName = temp.FilmName;
                tempEntry.FilmGenre = temp.FilmGenre;
                tempEntry.BlockID = temp.BlockID;
                tempEntry.BlockStart = temp.BlockStart;
                tempEntry.BlockEnd = temp.BlockEnd;
                tempEntry.BlockDayOfWeek = temp.BlockDayOfWeek;
                tempEntry.VotePercentage = tempVotePercentage * 100;

                tempFinal.Add(tempEntry);

                tempEntry = new LeaderBoardEntry();
                temp = new LeaderBoardData();
            }

            List<LeaderBoardEntry> final = tempFinal.OrderByDescending(o => o.VotePercentage).Take(10).ToList();

            return final;
        }

        private List<FilmBlock> getChosenFilms(List<VotesLB> temp)
        {
            List<FilmBlock> chosenFilms = new List<FilmBlock>();
            List<VotesLB> duplicateFilms = new List<VotesLB>();

            // goes through the list temp
            for (int x = 0; x < temp.Count; x++)
            {
                // Case 1: first loop
                if (x == 0)
                {
                    duplicateFilms.Add(temp[x]);
                }
                // Case 2: duplicate film (current film matches previous film)
                else if (temp[x].FilmID == temp[x - 1].FilmID)
                {
                    // last film in list temp
                    if (x == temp.Count - 1)
                    {
                        duplicateFilms.Add(temp[x]);
                        chosenFilms.Add(compareFilms(duplicateFilms));
                    }
                    else
                    {
                        duplicateFilms.Add(temp[x]);
                    }
                }
                // Case 3: New set of duplicates (current film doesn't match previous film)
                else
                {
                    chosenFilms.Add(compareFilms(duplicateFilms));
                    duplicateFilms = new List<VotesLB>();
                    duplicateFilms.Add(temp[x]);
                }
            }

            return chosenFilms;
        }

        private FilmBlock compareFilms(List<VotesLB> temp)
        {
            decimal tempPerc1;
            decimal tempPerc2;
            decimal tempChosen = 0;

            FilmBlock chosen = new FilmBlock();

            for (int x = 0; x < temp.Count - 1; x++)
            {
                if (x == 0)
                {
                    tempPerc1 = (decimal)temp[x].Votes / (decimal)temp[x].VotesPerBlock;
                    tempPerc2 = (decimal)temp[x + 1].Votes / (decimal)temp[x + 1].VotesPerBlock;

                    if (tempPerc1 >= tempPerc2)
                    {
                        chosen.FilmID = temp[x].FilmID;
                        chosen.BlockID = temp[x].BlockID;
                        tempChosen = tempPerc1;
                    }
                    else
                    {
                        chosen.FilmID = temp[x + 1].FilmID;
                        chosen.BlockID = temp[x + 1].BlockID;
                        tempChosen = tempPerc2;
                    }
                }
                else
                {
                    tempPerc2 = (decimal)temp[x + 1].Votes / (decimal)temp[x + 1].VotesPerBlock;

                    if (tempChosen < tempPerc2)
                    {
                        chosen.FilmID = temp[x + 1].FilmID;
                        chosen.BlockID = temp[x + 1].BlockID;
                    }
                }
            }
            return chosen;
        }

        private List<VotesLB> getVotesForList(List<FilmBlock> list)
        {
            // temp[0] is duplicates, temp[1] is non-duplicates
            List<VotesLB> temp = new List<VotesLB>();

            // Gets the votes and votesPerBlock for each "duplicate film"
            for (int x = 0; x < list.Count; x++)
            {
                var tempGetVotes = getVotes(list[x].FilmID, list[x].BlockID);
                temp.Add(tempGetVotes);
            }

            return temp;
        }

        private List<List<FilmBlock>> getDuplicates(List<FilmBlock> list)
        {
            // declare variables
            List<List<FilmBlock>> temp = new List<List<FilmBlock>>();
            List<FilmBlock> tempList1 = new List<FilmBlock>();
            List<FilmBlock> tempList2 = new List<FilmBlock>();
            FilmBlock test = new FilmBlock();

            int tempFilm1;
            int tempFilm2 = 0;
            int count = 0;
            Boolean first = true;
            Boolean noDuplicate = true;

            // This loop is meant to get any films that are in multiple blocks and store them in a 'temp' list to be processed.
            for (int x = 0; x < list.Count; x++)
            {

                tempFilm1 = list[x].FilmID;

                // don't get tempFilm2 if this is the last loop
                if (x == list.Count - 1) { tempFilm2 = 0; }
                else { tempFilm2 = list[x + 1].FilmID; }

                // if filmIDs are the same
                if (tempFilm1 == tempFilm2)
                {
                    // if first match
                    if (first == true)
                    {
                        test.FilmID = tempFilm1;
                        test.BlockID = list[x].BlockID;
                        tempList1.Add(test);
                        test = new FilmBlock();

                        test.FilmID = tempFilm2;
                        test.BlockID = list[x + 1].BlockID;
                        tempList1.Add(test);
                        test = new FilmBlock();

                        count = count + 2;
                        first = false;
                        noDuplicate = false;
                    }
                    // if match w/ tempFilm1 already in list
                    else if (tempList1[count - 1].FilmID == tempFilm1)
                    {
                        test.FilmID = tempFilm1;
                        test.BlockID = list[x].BlockID;
                        tempList1.Add(test);
                        test = new FilmBlock();

                        count++;
                    }
                    // if match w/o tempFilm1 already in list
                    else
                    {
                        test.FilmID = tempFilm1;
                        test.BlockID = list[x].BlockID;
                        tempList1.Add(test);
                        test = new FilmBlock();

                        test.FilmID = tempFilm2;
                        test.BlockID = list[x + 1].BlockID;
                        tempList1.Add(test);
                        test = new FilmBlock();

                        count = count + 2;
                    }
                }
                else
                {
                    // don't do anything if the last film in the loop was already used
                    if (noDuplicate == true)
                    {
                        test.FilmID = tempFilm1;
                        test.BlockID = list[x].BlockID;
                        tempList2.Add(test);
                        test = new FilmBlock();
                    }
                    else if (tempFilm1 == tempList1[count - 1].FilmID) { }
                    else
                    {
                        test.FilmID = tempFilm1;
                        test.BlockID = list[x].BlockID;
                        tempList2.Add(test);
                        test = new FilmBlock();
                    }
                }
            }
            temp.Add(tempList1);
            temp.Add(tempList2);
            return temp;
        }

        private LeaderBoardData getFilmData(int film, int block)
        {
            var pFilm = new SqlParameter("@film", film);
            var pBlock = new SqlParameter("@block", block);

            var results = _db.Database.SqlQuery<LeaderBoardData>("getLBDataFinal @film, @block", pFilm, pBlock).First();

            return results;
        }

        private List<FilmBlock> getLBData(int Event)
        {
            var pEvent = new SqlParameter("@event", Event);

            var results = _db.Database.SqlQuery<FilmBlock>("getLBVoted @event", pEvent).ToList();

            return results;
        }

        private VotesLB getVotes(int film, int block)
        {
            var pFilm = new SqlParameter("@film", film);
            var pBlock = new SqlParameter("@block", block);

            var results = _db.Database.SqlQuery<VotesLB>("getVotes @film, @block", pFilm, pBlock).First();

            return results;
        }

        public List<blockVD> GetBlocks(int eventID)
        {
            var pEvent = new SqlParameter("@event", eventID);

            var list = _db.Database.SqlQuery<blockVD>("getBlocks @event", pEvent).ToList();

            return list;
        } // End GetBlocks

        public List<genreVD> GetGenres(int eventID)
        {
            var pEvent = new SqlParameter("@event", eventID);

            var list = _db.Database.SqlQuery<genreVD>("getGenres @event", pEvent).ToList();

            return list;
        } // End GetGenres

        public List<eventDate> GetEvents()
        {
            var list = _db.Database.SqlQuery<eventDate>("getEvents").ToList();

            return list;
        }

        public IEnumerable<filmsVD> GetFilms(int block, string genre, int eventID)
        {
            if (block != -1)
            {
                var pBlock = new SqlParameter("@block", block);
                var results = _db.Database.SqlQuery<filmsVD>("getFilmsB @block", pBlock).ToList();

                return results;
            }
            else
            {
                var pGenre = new SqlParameter("@genre", genre);
                var pEvent = new SqlParameter("@event", eventID);
                var results = _db.Database.SqlQuery<filmsVD>("getFilmsG @genre, @event", pGenre, pEvent).ToList();

                return results;
            }
        } // End GetFilms

        public IEnumerable<graphVD> GetGraph(int block, string genre, int eventID)
        {
            if (block != -1)
            {
                var pBlock = new SqlParameter("@block", block);
                var pEvent = new SqlParameter("@event", eventID);
                var results = _db.Database.SqlQuery<graphVD>("getGraphsB @block, @event", pBlock, pEvent).ToList();

                return results;
            }
            else
            {
                var pGenre = new SqlParameter("@genre", genre);
                var pEvent = new SqlParameter("@event", eventID);
                var results = _db.Database.SqlQuery<graphVD>("getGraphsG @genre, @event", pGenre, pEvent).ToList();

                return results;
            }
        } // End GetGraph

        public IEnumerable<filmInfoVD> GetFilmInfo(int filmID)
        {
            var pFilm = new SqlParameter("@film", filmID);
            var results = _db.Database.SqlQuery<filmInfoVD>("getFilmInfo @film", pFilm).ToList();

            return results;
        } // End GetFilmInfo

        private voterCount getIncomeCount(int eventID, int begin, double end)
        {
            var pEvent = new SqlParameter("@event", eventID);
            var pBegin = new SqlParameter("@begin", begin);
            var pEnd = new SqlParameter("@end", end);

            var temp = _db.Database.SqlQuery<voterCount>("getVoterIncomeCount @begin, @end, @event", pBegin, pEnd, pEvent).First();

            return temp;
        } // End getIncomeCount
        
        public IEnumerable<voterCount> GetIncomeChart(int eventID)
        {
            List<voterCount> results = new List<voterCount>();

            //Household Income "Less than $35,000"
            results.Add(getIncomeCount(eventID, 1, 34999.99));
            //Household Income "$35,000 to $50,000"
            results.Add(getIncomeCount(eventID, 35000, 49999.99));
            //Household Income "#50,000 to #100,000"
            results.Add(getIncomeCount(eventID, 50000, 99999.99));
            //Household Income "$100,000 to $150,000"
            results.Add(getIncomeCount(eventID, 100000, 149999.99));
            //Household Income "$150,000 to $200,000"
            results.Add(getIncomeCount(eventID, 150000, 199999.99));
            //Household Income "$200,000 & Up"
            results.Add(getIncomeCount(eventID, 200000, 999999999999.99)); // Made it highly unlikely to reach "max" of $999 billion income...

            return results;
        } // End GetIncomeChart

        private voterCount getAgeCount(int eventID, int begin, int end)
        {
            var pEvent = new SqlParameter("@event", eventID);
            var pBegin = new SqlParameter("@begin", begin);
            var pEnd = new SqlParameter("@end", end);

            var temp = _db.Database.SqlQuery<voterCount>("getVoterAgeCount @begin, @end, @event", pBegin, pEnd, pEvent).First();

            return temp;
        } // End getAgeCount

        public IEnumerable<voterCount> GetAgeChart(int eventID)
        {
            List<voterCount> results = new List<voterCount>();

            //Age 19 & Younger
            results.Add(getAgeCount(eventID, 1, 19));
            //Age 20 to 29
            results.Add(getAgeCount(eventID, 20, 29));
            //Age 30 to 44
            results.Add(getAgeCount(eventID, 30, 44));
            //Age 45 to 54
            results.Add(getAgeCount(eventID, 45, 54));
            //Age 55 & Older
            results.Add(getAgeCount(eventID, 55, 200));

            return results;
        } // End GeAgeChart

        private voterCount getEducationCount(int eventID, string education)
        {
            var pEvent = new SqlParameter("@event", eventID);
            var pEducation = new SqlParameter("@education", education);

            var temp = _db.Database.SqlQuery<voterCount>("getVoterEducationCount @education, @event", pEducation, pEvent).First();

            return temp;
        } // End getEducationCount

        public IEnumerable<voterCount> GetEducationChart(int eventID)
        {
            List<voterCount> results = new List<voterCount>();

            results.Add(getEducationCount(eventID, "High School Diploma"));
            results.Add(getEducationCount(eventID, "Some College"));
            results.Add(getEducationCount(eventID, "Bachelor's"));
            results.Add(getEducationCount(eventID, "Some Graduate School"));
            results.Add(getEducationCount(eventID, "Master's"));
            results.Add(getEducationCount(eventID, "Doctorate"));

            return results;
        } // End GetEducationChart

        private voterCount getEthnicityCount(int eventID, string ethnicity)
        {
            var pEvent = new SqlParameter("@event", eventID);
            var pEthnicity = new SqlParameter("@ethnicity", ethnicity);

            var temp = _db.Database.SqlQuery<voterCount>("getVoterEthnicityCount @ethnicity, @event", pEthnicity, pEvent).First();

            return temp;
        } // End getEthnicityCount

        public IEnumerable<voterCount> GetEthnicityChart(int eventID)
        {
            List<voterCount> results = new List<voterCount>();

            results.Add(getEthnicityCount(eventID, "Native American/Alaska Native"));
            results.Add(getEthnicityCount(eventID, "Black/African American"));
            results.Add(getEthnicityCount(eventID, "Hispanic"));
            results.Add(getEthnicityCount(eventID, "Other/Multi-Racial"));
            results.Add(getEthnicityCount(eventID, "Asian/Pacific Islander"));
            results.Add(getEthnicityCount(eventID, "Caucasian"));
            results.Add(getEthnicityCount(eventID, "Prefer Not to Answer"));

            return results;
        } // End GetEthnicityChart

        public IEnumerable<VoterIDs> GetVoters()
        {
            var results = _db.Database.SqlQuery<VoterIDs>("GetVoterIDs").ToList();

            return results;
        }
    } // End ReportService
}
