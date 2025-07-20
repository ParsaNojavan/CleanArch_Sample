using CMS.Application.Commands;
using CMS.Application.Models.Dto.PostDto;
using CMS.Domain.Domain;

namespace CMS.Application.Profile;

public class PostProfile : AutoMapper.Profile
{
    public PostProfile()
    {
        CreateMap<CMS.Domain.Domain.Post, CMS.Infrastructure.Data.Post>();
        CreateMap<CMS.Infrastructure.Data.Post, CMS.Domain.Domain.Post>();
        CreateMap<PostAddCommand,CMS.Infrastructure.Data.Post>();
        CreateMap<PostEditRequest, Post>();
    }
}