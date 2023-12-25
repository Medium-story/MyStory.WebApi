using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class ReactionRepository(AppDbContext appDb) : Repository<Reaction>(appDb), IReactionInterface
{
}
