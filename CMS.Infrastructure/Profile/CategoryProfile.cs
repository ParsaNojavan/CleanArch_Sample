namespace CMS.Application.Profile;
using AutoMapper;
using CMS.Application.Models.Dto.CategoryDto;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CMS.Domain.Domain.Category, CMS.Infrastructure.Data.Category>();
        CreateMap<CMS.Infrastructure.Data.Category, CMS.Domain.Domain.Category>();
        CreateMap<CategoryAddDto, CMS.Domain.Domain.Category>();
        CreateMap<CategoryEditDto, CMS.Domain.Domain.Category>();
        CreateMap<Application.Commands.CategoryAddCommand, CMS.Domain.Domain.Category>();
        CreateMap<Application.Commands.CategoryEditCommand, CMS.Domain.Domain.Category>();
    }
}