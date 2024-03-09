using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Data.Repositories.Bids;
using Auctions.Models;

namespace Auctions.Services.Bids
{
    public class BidsService : IBidsService
    {
        private readonly IBidsRepository bidsRepository;

        public BidsService(IBidsRepository bidsRepository)
        {
            this.bidsRepository=bidsRepository;
        }

        public async Task<int> Create(Bid entity)
        {
            return await bidsRepository.Create(entity);
        }

        public async Task<IEnumerable<Bid>> FindAll()
        {
            return await bidsRepository.FindAll();
        }
    }
}