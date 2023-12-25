using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class ReplyRepository(AppDbContext appDb) : Repository<Reply>(appDb), IReplyInterface
{
}
