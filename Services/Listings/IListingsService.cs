using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Models;

namespace Auctions.Services.Listings
{
    public interface IListingsService
    {
        Task<IEnumerable<Listing>> FindAll();

        Task<IEnumerable<Listing>> FindIndexPageListings(int pageNumber,int pageSize , string searchString);

        Task<IEnumerable<Listing>> FindMyListings(int pageNumber,int pageSize, string userId);

        Task<int> Create(Listing entity);

        Task<Listing?> FindById(int id);

        
    }
}