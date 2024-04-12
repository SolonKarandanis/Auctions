using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Models;

namespace Auctions.Services.Bids
{
    public interface IBidsService
    {
        Task<int> Create(Bid entity);

        Task<IEnumerable<Bid>> FindAll();

        Task<IEnumerable<Bid>> FindMyBids(int pageNumber,int pageSize, string userId);
    }
}