using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class FollowRepository(AppDbContext appDb) : Repository<Follow>(appDb), IFollowInterface
{

}
