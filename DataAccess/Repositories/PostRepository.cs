using Appliction.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _ctx;

        public PostRepository(SocialDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Post> CreatePost(Post toCreate) //Creeren van een Post
        {
            toCreate.DateCreated = DateTime.Now; //DateCreated krigt waarde
            toCreate.LastModified = DateTime.Now;//LastModified krijgt default waarde
            _ctx.Posts.Add(toCreate); // Post tooegevooegd aan Posts
            await _ctx.SaveChangesAsync();//Bewaar veranderingen
            return toCreate; // Post wordt gecreerd,teruggegeven en krijgt Id
        }

        public async Task DeletePost(int postId)
        {
            var post = await _ctx.Posts
                .FirstOrDefaultAsync(p => p.Id == postId);
            if (post == null) return;

            _ctx.Posts.Remove(post);

            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            return await _ctx.Posts.ToListAsync();
        }

        public async Task<Post> GetPostById(int postId)
        {
            return await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<Post> UpdatePost(string updateContent, int postId)
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            post.LastModified = DateTime.Now;
            post.Content = updateContent;
            await _ctx.SaveChangesAsync();
            return post;
        }
    }
}
