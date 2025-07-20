using System.Net;
using CMS.Application.Models.Dto.General;
using CMS.Application.Models.Dto.PostDto;
using CMS.Application.Models.Dto.Use_Case.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Api.Presenter
{
    public class PostApiPresenter<T> : IOutputPort<GenericResponse<T>>
    {
        public readonly JsonContentResult Result;
        public PostApiPresenter()
        {
            Result = new JsonContentResult();
        }
        public void Handle(GenericResponse<T> response)
        {
            Result.StatusCode = 
                (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            Result.Content = Result
                .Serialize(response.Success ? (object)response.Data : (object)response.Errors);
        }
    }
}
