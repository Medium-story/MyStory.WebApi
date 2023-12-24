namespace MediumStory.Domain.Entities;

public class Like : BaseEntity
{
    public int CommentId { get; set; }
    public int ReplyId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public Comment Comment { get; } = new();
    public Reply Reply { get; } = new();
    public User User { get; } = new();
}