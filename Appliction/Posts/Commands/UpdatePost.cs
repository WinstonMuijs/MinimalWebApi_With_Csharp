using Domain.Models;
using MediatR;


namespace Appliction.Posts.Commands
{
    public class UpdatePost : IRequest<Post>
    {
        public int Postid { get; set; }
        public string? PostContent { get; set; }
    }
}
