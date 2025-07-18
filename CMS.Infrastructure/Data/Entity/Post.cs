using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Data;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; } =
        DateTime.Now;
    public string Content { get; set; }
    public int CategoryId { get; set; } = 1;
    public Category Category { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<PostTag> PostTags { get; set; }
}

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).HasMaxLength(50);
        builder.Property(x => x.Content).HasMaxLength(1000);
    }
}