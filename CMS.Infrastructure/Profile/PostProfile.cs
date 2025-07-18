using CMS.Application.Commands;

namespace CMS.Application.Profile;

public class PostProfile : AutoMapper.Profile
{
    public PostProfile()
    {
        CreateMap<CMS.Domain.Domain.Post, CMS.Infrastructure.Data.Post>();
        CreateMap<CMS.Infrastructure.Data.Post, CMS.Domain.Domain.Post>();
        CreateMap<PostAddCommand,CMS.Infrastructure.Data.Post>();
    }
}