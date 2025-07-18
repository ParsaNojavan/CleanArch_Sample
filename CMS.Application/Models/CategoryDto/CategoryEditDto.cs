using System.ComponentModel.DataAnnotations;

namespace CMS.Application.Models;

public class CategoryEditDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
}