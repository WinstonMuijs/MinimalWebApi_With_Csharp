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
    public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
    {
        private readonly IPostRepository _postsRepo;

        public GetPostByIdHandler(IPostRepository postsRepo)
        {
            _postsRepo = postsRepo;
        }
        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            return await _postsRepo.GetPostById(request.PostId);

        }
    }
}
