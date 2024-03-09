using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.Data.Repositories.Comments;
using Auctions.Models;

namespace Auctions.Services.Comments
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository commentsRepository;

        public CommentsService(ICommentsRepository commentsRepository)
        {
            this.commentsRepository=commentsRepository;
        }

        public async Task<int> Create(Comment entity)
        {
            return await commentsRepository.Create(entity);
        }
    }
}