using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Bid>> FindByUserId(int pageNumber, int pageSize, string userId)
        {
            var efQuery = context.Bids.Where(b=> b.IdentityUserId== userId);
            var page = pageNumber -1;
            var skippedElements = page * pageSize;
            return await efQuery
                .Skip(skippedElements)
                .OrderBy(x => x.Id)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}