using Domain.Models;
using MediatR;


namespace Appliction.Posts.Commands
{
    public class CreatePost : IRequest<Post>
    {
        public string? PostContant { get; set; }
    }
}
