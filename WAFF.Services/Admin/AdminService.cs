using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WAFF.DataAccess.Contexts;
using WAFF.DataAccess.Entity;
using WAFF.DataAccess.ViewModels.Admin;

namespace WAFF.Services.Admin
{
    public class AdminService
    {
        private readonly EFDbContext _dbContext = new EFDbContext();

        public AdminEventViewModel GetAdminEventViewModelById(int? id)
        {
            var waffEvent = _dbContext.Events.Find(id);

            var blockList = _dbContext.Blocks
                .Where(y => y.EventID == id)
                .Select(x => new AdminBlockViewModel()
                {
                    BlockId = x.BlockID,
                    EventId = x.EventID,
                    BlockStart = x.BlockStart,
                    BlockEnd = x.BlockEnd,
                    BlockLocation = x.BlockLocation,
                    BlockType = x.BlockType,
                    BlockDescription = x.BlockDescription
                })
                .ToList();

            var films = _dbContext.Films.ToList();

            var viewModel = AdminEventViewModel.Create(waffEvent, blockList, films);

            return viewModel;
        }

        public async Task<IEnumerable<BlocksCurrentFilmViewModel>> GetBlocksCurrentFilmsByBlockAndEvent(int blockId, int eventId)
        {
            var result = await _dbContext.GetBlocksCurrentFilmsByBlockAndEvent(blockId, eventId);

            return result;
        }

        public async Task<int> GetBlockRemainingDuration(int blockId)
        {
            var result = await _dbContext.GetBlockRemainingDuration(blockId);

            return result;
        }

        public int RemoveFilmFromBlock(int blockId, int filmId)
        {
            var result = 0;

            var filmBlockToDelete = _dbContext.FilmBlocks.FirstOrDefault(x => x.BlockID == blockId && x.FilmID == filmId);

            _dbContext.FilmBlocks.Remove(filmBlockToDelete);
            result = _dbContext.SaveChanges();

            return result;
        }

        public int AddFilmToBlock(int blockId, int filmId)
        {
            var filmToAdd = new FilmBlock
            {
                BlockID = blockId,
                FilmID = filmId
            };

            _dbContext.FilmBlocks.Add(filmToAdd);
            _dbContext.SaveChanges();

            return blockId;
        }
    }
}
