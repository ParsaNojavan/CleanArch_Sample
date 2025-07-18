using CMS.Application.Commands;
using CMS.Application.Interfaces.Repository;
using CMS.Application.Models.PostDto;
using MediatR;

namespace CMS.Application.Handlers;

public class AddPostHandler : IRequestHandler<PostAddCommand,AddPostResponse>
{
    private readonly IPostRepository _postRepository;
    public AddPostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<AddPostResponse> Handle(PostAddCommand request, CancellationToken cancellationToken)
    {
        var result = await _postRepository.Add(request);
        return new AddPostResponse{Id = result};
    }
}