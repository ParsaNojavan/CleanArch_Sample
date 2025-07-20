using CMS.Application.Commands;
using CMS.Domain.Domain;

namespace CMS.Application.Interfaces.Repository;

public interface IPostRepository
{
    Task<List<Post>> GetLatestPosts(int count);
    Task<int> Add(PostAddCommand command);
    Task<int> Edit(Post post);
}