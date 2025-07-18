namespace CMS.Domain.Domain;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public int PostId { get; set; } 
    public Post Post { get; set; }
}