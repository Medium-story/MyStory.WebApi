using MyStory.Domain.Entities;

namespace MediumStory.Domain.Entities;

public class Reply : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public int? CommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public int? ArticleId { get; set; }
    public Article? Article { get; set; } = new();
    public User User { get; set; } = new();
    public Comment? Comment { get; set; } = new();
    public virtual ICollection<ReplyLike> ReplyLikes { get; set; } = new List<ReplyLike>();
    public DateTime CreatedAt { get; set; }
}
