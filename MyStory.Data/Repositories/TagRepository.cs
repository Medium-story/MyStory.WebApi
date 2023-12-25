using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class TagRepository(AppDbContext appDb) : Repository<Tag>(appDb), ITagInterface
{
}
