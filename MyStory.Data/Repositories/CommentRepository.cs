using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class CommentRepository(AppDbContext appDb) : Repository<Comment>(appDb), ICommentInterface
{

}
