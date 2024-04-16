using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Data.Repositories.Listings;
using Auctions.Dtos.Web;
using Auctions.Models;

namespace Auctions.Services.Listings
{
    public class ListingsService : IListingsService
    {
        private readonly IListingsRepository listingsRepository;

        public ListingsService(IListingsRepository listingsRepository)
        {
            this.listingsRepository=listingsRepository;
        }

        public async Task<int> Create(Listing entity)
        {
            return await listingsRepository.Create(entity);
        }

        public async Task<IEnumerable<Listing>> FindAll()
        {
            return await listingsRepository.FindAll();
        }

        public async Task<Listing?> FindById(int id)
        {
            return await listingsRepository.FindById(id);
        }

        public async  Task<PageResponse<Listing>> FindIndexPageListings(Paging paging, string searchString)
        {
            return await listingsRepository.FindListingsByTitle(paging,searchString);
        }

        public async Task<PageResponse<Listing>> FindMyListings(Paging paging, string userId)
        {
            return await listingsRepository.FindByUserId(paging,userId);
        }
    }
}