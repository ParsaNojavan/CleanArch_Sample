using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.Models.Dto.General;
using CMS.Application.Models.Dto.Use_Case;

namespace CMS.Application.Models.Dto.PostDto
{
    public class PostEditRequest : IUseCaseRequest<GenericResponse<PostEditResponse>>
    {
        public int Id  { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
