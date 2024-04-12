using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Models;

namespace Auctions.Data.Repositories.Bids
{
    public interface IBidsRepository: IRepository<Bid>
    {
        Task<IEnumerable<Bid>> FindByUserId(int pageNumber,int pageSize, string userId);
    }
}