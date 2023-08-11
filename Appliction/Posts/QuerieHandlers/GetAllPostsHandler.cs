using Appliction.Abstractions;
using Appliction.Posts.Queries;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliction.Posts.QuerieHandlers
{
     public class GetAllPostsHandler : IRequestHandler<GetAllPosts, ICollection<Post>>
    {
        private readonly IPostRepository _postsRepo;

        public GetAllPostsHandler(IPostRepository postsRepo)
        {
            _postsRepo = postsRepo;
        }

        public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            return await _postsRepo.GetAllPosts();
        }
    }
}
