namespace MediumStory.Domain.Entities;

public class Article : BaseEntity
{
    public string FIleUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string AverageReadTime => Math.Ceiling((decimal)(Body.Length / 300)).ToString();
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = new();
    public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public DateTime CreatedAt { get; set; }
}
