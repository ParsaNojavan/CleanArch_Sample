using System.ComponentModel.DataAnnotations;

namespace CMS.Application.Models.Dto.PostDto;

public class PostAddDto
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; }
}