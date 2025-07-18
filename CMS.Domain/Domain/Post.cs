namespace CMS.Domain.Domain;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string Content { get; set; }
    public int CategoryId { get; set; } = 1;
    public Category Category { get; set; }
    public ICollection<Comment> Comments { get; set; }
}