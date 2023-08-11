using MediatR;


namespace Appliction.Posts.Commands
{
       public class DeletePost : IRequest
    {
        public int PostId { get; set; }
    }
}
