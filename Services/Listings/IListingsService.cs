using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Dtos.Web;
using Auctions.Models;

namespace Auctions.Services.Listings
{
    public interface IListingsService
    {
        Task<IEnumerable<Listing>> FindAll();

        Task<PageResponse<Listing>> FindIndexPageListings(Paging paging, string searchString);

        Task<PageResponse<Listing>> FindMyListings(Paging paging, string userId);

        Task<int> Create(Listing entity);

        Task<Listing?> FindById(int id);

        
    }
}