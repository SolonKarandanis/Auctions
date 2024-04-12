using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Models;
using Microsoft.EntityFrameworkCore;
using Rpg.Data.Repositories;

namespace Auctions.Data.Repositories.Listings
{
    public class ListingsRepository : Repository<Listing>, IListingsRepository, IDisposable
    {
        private readonly DataContext context;

        public ListingsRepository(DataContext context):base(context)
        {
            this.context=context;
        }

        new public async Task<Listing?> FindById(int id){
            var listing = await context.Listings
                .Include(l => l.User)
                .Include(l => l.Comments)
                .Include(l => l.Bids)
                .FirstOrDefaultAsync(m => m.Id == id);
            return listing;
        } 
        public async void Dispose()
        {
            await context.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Listing>> FindListingsByTitle(int pageNumber, int pageSize, string searchString)
        {
            var efQuery = context.Listings.Where(l => l.IsSold == false);
            if(!string.IsNullOrEmpty(searchString)){
                dbSet.Where(a => a.Title.Contains(searchString));
            }
            var page = pageNumber -1;
            var skippedElements = page * pageSize;
            return await efQuery
                .Skip(skippedElements)
                .OrderBy(x => x.Id)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Listing>> FindByUserId(int pageNumber, int pageSize, string userId)
        {
            var efQuery = context.Listings.Where(l=> l.IdentityUserId== userId);
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