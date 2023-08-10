using Appliction.Abstractions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        public Task<Post> CreatePost(Post toCreate)
        {
            throw new NotImplementedException();
        }

        public Task<Post> DeletePost(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Post>> GetllPosts()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePost(string updateContent, int postId)
        {
            throw new NotImplementedException();
        }
    }
}
