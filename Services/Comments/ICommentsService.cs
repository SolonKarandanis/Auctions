using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Models;

namespace Auctions.Services.Comments
{
    public interface ICommentsService
    {
        Task<int> Create(Comment entity);
    }
}