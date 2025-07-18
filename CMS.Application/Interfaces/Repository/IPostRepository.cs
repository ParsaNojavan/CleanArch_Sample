using CMS.Application.Commands;
using CMS.Application.Models.PostDto;
using CMS.Domain.Domain;

namespace CMS.Application.Interfaces.Repository;

public interface IPostRepository
{
    Task<List<Post>> GetLatestPosts(int count);
    Task<int> Add(PostAddCommand command);
}