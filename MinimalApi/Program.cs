using Appliction.Abstractions;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Windows.Markup;

var builder = WebApplication.CreateBuilder(args);
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(cs));
builder.Services.AddScoped<IPostRepository, PostRepository>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.Run();

