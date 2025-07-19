using AutoMapper;
using CMS.Application.Commands;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Domain;
using MediatR;

namespace CMS.Application.Handlers;

public class CategoryAddHandler : IRequestHandler<CategoryAddCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryAddHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Category> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Domain.Domain.Category>(request);
        await _categoryRepository.Add(category);
        return category;
    }
}