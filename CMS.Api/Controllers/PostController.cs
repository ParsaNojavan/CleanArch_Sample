using CMS.Application.Commands;
using CMS.Application.Interfaces.Repository;
using CMS.Application.Models.PostDto;
using CMS.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Controllers;

[ApiController]
[Route("/api/post")]
public class PostController : BaseController
{
    private readonly IMediator _mediator;
    public PostController(IMediator mediator)
    {
        _mediator = mediator;
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
}