using CMS.Application.Interfaces.Repository;
using CMS.Application.Queries;
using CMS.Domain.Domain;
using MediatR;

namespace CMS.Application.Handlers;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;
    public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAll();
        return category;
    }
}