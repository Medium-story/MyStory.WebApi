using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class CommentRepository(AppDbContext appDb) : Repository<Comment>(appDb), ICommentInterface
{
    private readonly AppDbContext _appDb = appDb;

    public async Task<ICollection<Comment>> GetAllWithReplies()
    {
        var comments = await _appDb.Comments.Include(i => i.Replies).ToListAsync();
        return comments;
    }
}
