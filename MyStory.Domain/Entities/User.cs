using Microsoft.AspNetCore.Identity;

namespace MediumStory.Domain.Entities;

public class User : IdentityUser
{//merged
    public string FullName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string LinkedIn { get; set; } = string.Empty;
    public string GitHub { get; set; } = string.Empty;
    public virtual ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    public virtual ICollection<Like> Like { get; set; } = new List<Like>();
    public virtual ICollection<Article> Saved { get; set; } = new List<Article>();
    public virtual ICollection<Follow> Followers { get; set; } = new List<Follow>();
    public virtual ICollection<Follow> Following { get; set; } = new List<Follow>();
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
