using MediumStory.Domain.Enums;

namespace MediumStory.Domain.Entities;

public class Reaction : BaseEntity
{
    public int ArticleId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public ReactionEnum Type { get; set; }
    public User User { get; set; } = new();
    public Article Article { get; set; } = new();
}