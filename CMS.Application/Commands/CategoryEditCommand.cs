using MediatR;

namespace CMS.Application.Commands;

public class CategoryEditCommand : IRequest<Domain.Domain.Category>
{
    public int Id { get; set; }
    public string Title { get; set; }
}