namespace MediumStory.Domain.Entities;

public class Like : BaseEntity
{
    public int? CommentId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public Comment? Comment { get; set; } = new();
    public User User { get; set; } = new();
}
