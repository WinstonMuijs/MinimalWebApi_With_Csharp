﻿using Domain.Models;
using MediatR;


namespace Appliction.Posts.Queries
{
    public class GetPostById : IRequest<Post>
    {
        public int PostId { get; set; }
    }
}
