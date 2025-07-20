using AutoMapper;
using CMS.Api.Presenter;
using CMS.Application.Commands;
using CMS.Application.Interfaces.Repository;
using CMS.Application.Models.Dto.PostDto;
using CMS.Application.Models.Dto.Use_Case;
using CMS.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers;

[ApiController]
[Route("/api/post")]
public class PostController : BaseController
{
    private readonly IEditPostUseCase _editPostUsecase;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly PostApiPresenter<PostEditResponse> _postPresenter;
    public PostController(IMediator mediator, IMapper mapper
        ,IEditPostUseCase editPostUsecase,PostApiPresenter<PostEditResponse> postPresenter)
    {
        _editPostUsecase = editPostUsecase;
        _postPresenter = postPresenter;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("GetLatestPosts")]
    public async Task<ActionResult> GetLatestPosts()
    {
        var query = new GetLatestPostsQuery();
        var result = await _mediator.Send(query);
        return CustomOk(result);
    }
    [HttpPost("AddPost")]
    public async Task<IActionResult> AddPost([FromBody] PostAddDto post)
    {
        var command = new PostAddCommand()
        {
            Title = post.Title, 
            Content = post.Content,
        };
        var result = await _mediator.Send(command);
        return CustomOk(result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(PostEditDto postDto)
    {
        var post = _mapper.Map<PostEditRequest>(postDto);
        await _editPostUsecase.HandleAsync(post, _postPresenter);
        return _postPresenter.Result;
    }
}