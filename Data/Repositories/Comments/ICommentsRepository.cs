using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Models;

namespace Auctions.Data.Repositories.Comments
{
    public interface ICommentsRepository: IRepository<Comment>
    {
        Task<List<Comment>> FindByListingId(int listingId);

        Task<int> DeleteByListingId(int listingId);
    }
}