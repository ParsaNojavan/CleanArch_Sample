namespace CMS.Application.Profile;
using AutoMapper;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CMS.Domain.Domain.Category, CMS.Infrastructure.Data.Category>();
        CreateMap<CMS.Infrastructure.Data.Category, CMS.Domain.Domain.Category>();
        CreateMap<CMS.Application.Models.CategoryAddDto, CMS.Domain.Domain.Category>();
        CreateMap<CMS.Application.Models.CategoryEditDto, CMS.Domain.Domain.Category>();
    }
}