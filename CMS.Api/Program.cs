using CMS.Application.Handlers;
using CMS.Application.Interfaces.Repository;
using CMS.Application.Profile;
using CMS.Application.Queries;
using CMS.Infrastructure.Data.Context;
using CMS.Infrastructure.Data.Respository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



var baseDir = AppContext.BaseDirectory;
var projectRoot = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", ".."));
var dbPath = Path.Combine(projectRoot, "CMS.Infrastructure", "CmsDB.db");

builder.Services.AddDbContext<CmsDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetLatestPostsHandler).Assembly);
});
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddAutoMapper(typeof(PostProfile)
    ,typeof(CategoryProfile));
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

app.Run();