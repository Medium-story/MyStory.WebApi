using MediumStory.Data.DataContext;
using MyStory.Data.Interfaces;
using MyStory.Domain.Entities;

namespace MyStory.Data.Repositories;

public class ReplyLikeRepository(AppDbContext appDb) : Repository<ReplyLike>(appDb), IReplyLikeInterface
{
}
