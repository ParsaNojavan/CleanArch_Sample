using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.Models.Dto.Use_Case.Interfaces;

namespace CMS.Application.Models.Dto.Use_Case
{
    public interface IUseCaseRequestHandler<in TUseCaseRequest,out TUseCaseResponse>
        where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
    {
        Task HandleAsync(TUseCaseRequest message, IOutputPort<TUseCaseResponse> outputPort);
    }

}
