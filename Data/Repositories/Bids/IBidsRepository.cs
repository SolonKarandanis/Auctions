using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Dtos.Web;
using Auctions.Models;

namespace Auctions.Data.Repositories.Bids
{
    public interface IBidsRepository: IRepository<Bid>
    {
        Task<PageResponse<Bid>> FindByUserId(Paging paging, string userId);
    }
}