using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Models;
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
    }
}