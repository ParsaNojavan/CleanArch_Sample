using AutoMapper;
using CMS.Application.Commands;
using CMS.Application.Interfaces.Repository;
using CMS.Domain.Domain;
using MediatR;

namespace CMS.Application.Handlers;

public class CategoryEditHandler : IRequestHandler<CategoryEditCommand, Category>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryEditHandler(ICategoryRepository categoryRepository
        , IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Category> Handle(CategoryEditCommand request, CancellationToken cancellationToken)
    {
        return(await _categoryRepository
            .Edit(_mapper
                .Map<Domain.Domain.Category>(request)));
    }
}