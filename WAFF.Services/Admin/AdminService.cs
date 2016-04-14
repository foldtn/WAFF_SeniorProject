using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
