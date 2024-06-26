using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Dtos.Web;
using Auctions.Models;

namespace Auctions.Services.Bids
{
    public interface IBidsService
    {
        Task<int> Create(Bid entity);

        Task<IEnumerable<Bid>> FindAll();

        Task<PageResponse<Bid>> FindMyBids(Paging paging, string userId);
    }
}