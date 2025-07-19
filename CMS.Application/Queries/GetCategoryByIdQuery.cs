using CMS.Domain.Domain;
using MediatR;

namespace CMS.Application.Queries;

public class GetCategoryByIdQuery : IRequest<Domain.Domain.Category>
{
    public int Id { get; set; }
}