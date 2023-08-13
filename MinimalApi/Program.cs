using Appliction.Abstractions;
using Appliction.Posts.Commands;
using Appliction.Posts.Queries;
using DataAccess;
using DataAccess.Repositories;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Windows.Markup;

var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(cs));
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddMediatR(typeof(CreatePost));


// Add services to the container.

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/api/posts/{id}", async (IMediator mediator, int id) =>
{
    var getPost = new GetPostById { PostId = id };
    var post = await mediator.Send(getPost);
    return Results.Ok(post);
})
    .WithName("GetPostById");

app.MapPost("/api/posts", async (IMediator mediator, Post post) =>
{
    var createPost = new CreatePost { PostContent = post.Content };
    var createdPost = await mediator.Send(createPost);
    return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
});

app.MapGet("/api/posts", async (IMediator mediator) =>
{
    var getCommand = new GetPostById();
    var posts = await mediator.Send(getCommand);
    return Results.Ok(posts);   
});

app.MapPut("api/posts/{id}", async (IMediator mediator, Post post, int id) =>
{
    var updatePost = new UpdatePost { Postid = id, PostContent = post.Content };
    var updatedPost = await mediator.Send(updatePost);
    return Results.Ok(updatedPost);

});

app.MapDelete("/api/posts/{id}", async (IMediator mediator, int id) =>
{
    var deletePost = new DeletePost { PostId = id };
    await mediator.Send(deletePost);    
    return Results.NoContent(); 
});


app.Run();

