using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Dtos.Web;
using Auctions.Models;

namespace Auctions.Data.Repositories.Listings
{
    public interface IListingsRepository: IRepository<Listing>
    {
        new Task<Listing?> FindById(int id);

        Task<PageResponse<Listing>> FindListingsByTitle(Paging paging, string searchString);

        Task<PageResponse<Listing>> FindByUserId(Paging paging, string userId);
    }
}