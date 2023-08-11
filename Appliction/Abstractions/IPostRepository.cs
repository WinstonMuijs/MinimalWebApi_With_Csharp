using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliction.Abstractions
{
    public interface IPostRepository
    {

        Task<ICollection<Post>> GetAllPosts();
     
        Task<Post> GetPostById(int postId);

        Task<Post> CreatePost(Post toCreate);

        Task<Post> UpdatePost(string updateContent, int postId);

        Task DeletePost(int postId);
    }
}
