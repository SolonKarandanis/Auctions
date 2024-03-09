using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Data.Repositories.Listings;

namespace Auctions.Services.Listings
{
    public class ListingsService : IListingsService
    {
        private readonly IListingsRepository listingsRepository;

        public ListingsService(IListingsRepository listingsRepository)
        {
            this.listingsRepository=listingsRepository;
        }
        
    }
}