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

        Task<int> Create(Listing entity);

        Task<Listing?> FindById(int id);

        
    }
}