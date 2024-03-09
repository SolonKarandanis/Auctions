using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Models;
using Microsoft.EntityFrameworkCore;
using Rpg.Data.Repositories;

namespace Auctions.Data.Repositories.Comments
{
    public class CommentsRepository : Repository<Comment>, ICommentsRepository, IDisposable
    {

        private readonly DataContext context;

        public CommentsRepository(DataContext context):base(context)
        {
            this.context=context;
        }

        public async Task<int> DeleteByListingId(int listingId)
        {
            return await context.Comments
                .Where(c => c.ListingId == listingId)
                .ExecuteDeleteAsync();
        }

        public async void Dispose()
        {
            await context.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        public async Task<List<Comment>> FindByListingId(int listingId)
        {
            return await context.Comments
                .Where(c => c.ListingId == listingId)
                .ToListAsync();
        }
    }
}