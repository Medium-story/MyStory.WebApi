namespace MediumStory.Domain.Entities;

public class Follow : BaseEntity
{
    public string FollowerUserId { get; set; } = string.Empty;
    public string FollowingUserId { get; set; } = string.Empty;
    public User FollowerUser { get; set; } = new();
    public User FollowingUser { get; set; } = new();
}
