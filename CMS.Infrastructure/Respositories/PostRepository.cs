using AutoMapper;
using CMS.Application.Commands;
using CMS.Application.Interfaces.Repository;
using CMS.Application.Models.PostDto;
using CMS.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure.Data.Respository;

public class PostRepository : IPostRepository
{
    private readonly CmsDbContext _context;
    private readonly IMapper _mapper;
    public PostRepository(CmsDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<Domain.Domain.Post>> GetLatestPosts(int count)
    {
        var result = await _context.Posts
            .OrderByDescending(x=>x.CreatedDate)
                .Take(count).ToListAsync();
        return _mapper.Map<List<Domain.Domain.Post>>(result);
    }

    public async Task<int> Add(PostAddCommand command)
    {
        var data = _mapper.Map<Post>(command);
        await _context.Posts.AddAsync(data);
        await _context.SaveChangesAsync();
        return data.Id;
    }
}