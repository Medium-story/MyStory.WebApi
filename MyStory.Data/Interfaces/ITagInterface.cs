using MediumStory.Domain.Entities;

namespace MyStory.Data.Interfaces;

public interface ITagInterface : IRepository<Tag>
{
    Task<Tag> GetByName(string name);
}
