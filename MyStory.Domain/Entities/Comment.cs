namespace MediumStory.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;
    public int ArticleId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = new();
    public Article Article { get; set; } = new();
    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    public DateTime CreatedAt { get; set; }
}
