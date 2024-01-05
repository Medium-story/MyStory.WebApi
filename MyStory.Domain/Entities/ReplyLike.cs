using MediumStory.Domain.Entities;

namespace MyStory.Domain.Entities;

public class ReplyLike : BaseEntity
{
    public int? ReplyId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public Reply? Reply { get; set; } = new();
    public User User { get; set; } = new();
}