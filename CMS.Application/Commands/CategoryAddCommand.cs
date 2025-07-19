using CMS.Domain.Domain;
using MediatR;

namespace CMS.Application.Commands;

public class CategoryAddCommand : IRequest<Category>
{
    public string Title { get; set; }
}