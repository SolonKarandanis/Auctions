using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Data.Repositories.Bids;

namespace Auctions.Services.Bids
{
    public class BidsService : IBidsService
    {
        private readonly IBidsRepository bidsRepository;

        public BidsService(IBidsRepository bidsRepository)
        {
            this.bidsRepository=bidsRepository;
        }
    }
}