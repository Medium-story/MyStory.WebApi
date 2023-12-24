namespace MediumStory.Domain.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<User> User { get; set; } = new List<User>();
}
