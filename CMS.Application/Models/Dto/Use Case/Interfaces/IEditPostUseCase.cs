using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.Models.Dto.General;
using CMS.Application.Models.Dto.PostDto;

namespace CMS.Application.Models.Dto.Use_Case
{
    public interface IEditPostUseCase : IUseCaseRequestHandler<PostEditRequest, GenericResponse<PostEditResponse>>
    {
    }
}
