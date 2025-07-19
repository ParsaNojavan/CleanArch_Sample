using CMS.Domain.Domain;
using MediatR;

namespace CMS.Application.Queries;

public class GetAllCategoriesQuery : IRequest<List<Category>>
{
    
}