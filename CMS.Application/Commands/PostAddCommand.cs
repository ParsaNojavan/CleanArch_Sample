using CMS.Application.Models.Dto.PostDto;
using MediatR;

namespace CMS.Application.Commands;

public class PostAddCommand: IRequest<AddPostResponse>
{
    public string Title { get; set; }
    public string Content { get; set; }
}