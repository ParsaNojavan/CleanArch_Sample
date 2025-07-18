using CMS.Application.Interfaces.Repository;
using CMS.Application.Queries;
using CMS.Domain.Domain;
using MediatR;

namespace CMS.Application.Handlers;

public class GetLatestPostsHandler : IRequestHandler<GetLatestPostsQuery, List<Post>>
{
    private readonly IPostRepository _postRepository;
    public GetLatestPostsHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<List<Post>> Handle(GetLatestPostsQuery request, CancellationToken cancellationToken)
    {
        return (await _postRepository.GetLatestPosts(10));
    }
}