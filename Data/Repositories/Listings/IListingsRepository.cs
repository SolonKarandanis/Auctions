using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Models;

namespace Auctions.Data.Repositories.Listings
{
    public interface IListingsRepository: IRepository<Listing>
    {
        new Task<Listing?> FindById(int id);

        Task<IEnumerable<Listing>> FindIndexPageListings(int pageNumber,int pageSize, string searchString);
    }
}