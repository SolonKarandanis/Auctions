using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Dtos.Web;
using Auctions.Models;
using Microsoft.EntityFrameworkCore;
using Rpg.Data.Repositories;

namespace Auctions.Data.Repositories.Bids
{
    public class BidsRepository : Repository<Bid>, IBidsRepository, IDisposable
    {

        private readonly DataContext context;

        public BidsRepository(DataContext context):base(context)
        {
            this.context=context;
        }
        public async void Dispose()
        {
            await context.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        public async Task<PageResponse<Bid>> FindByUserId(Paging paging, string userId)
        {
            var efQuery = context.Bids.Where(b=> b.IdentityUserId== userId);
            var page = paging.Page -1;
            var pageSize = paging.Size;
            var skippedElements = page * pageSize;

            var totalNumber = await efQuery.CountAsync();
            var pageCount = (totalNumber + page)/ paging.Page;

            var result =  await efQuery
                .Skip(skippedElements)
                .OrderBy(x => x.Id)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return new PageResponse<Bid>(result,totalNumber,pageCount);
        }
    }
}