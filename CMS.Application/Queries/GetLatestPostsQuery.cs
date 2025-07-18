using CMS.Domain.Domain;
using MediatR;

namespace CMS.Application.Queries;

public class GetLatestPostsQuery : IRequest<List<Post>>
{
    
}