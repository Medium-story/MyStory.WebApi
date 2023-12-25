using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class LikeRepository(AppDbContext appDb) : Repository<Like>(appDb), ILikeInterface
{
}
