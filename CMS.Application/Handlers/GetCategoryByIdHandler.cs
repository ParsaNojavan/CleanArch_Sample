using CMS.Application.Interfaces.Repository;
using CMS.Application.Queries;
using MediatR;

namespace CMS.Application.Handlers;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Domain.Domain.Category>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Domain.Domain.Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetById(request.Id);
        return category;
    }
}