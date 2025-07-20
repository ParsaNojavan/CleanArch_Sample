using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.Interfaces.Repository;
using CMS.Application.Models.Dto.General;
using CMS.Application.Models.Dto.PostDto;
using CMS.Application.Models.Dto.Use_Case.Interfaces;
using CMS.Domain.Domain;

namespace CMS.Application.Models.Dto.Use_Case
{
    public class EditPostUseCase : IEditPostUseCase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public EditPostUseCase(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task HandleAsync(PostEditRequest message, IOutputPort<GenericResponse<PostEditResponse>> outputPort)
        {
            var post = _mapper.Map<Post>(message);
            var id = await _postRepository.Edit(post);
            outputPort.Handle(new GenericResponse<PostEditResponse> 
            {
                Data = new PostEditResponse { Id = id }
            });
        }
    }
}
