using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class ReplyRepository(AppDbContext appDb) : Repository<Reply>(appDb), IReplyInterface
{
    private readonly AppDbContext _appDb = appDb;

    public async Task<ICollection<Reply>> GetAllWithEntities()
    {
        var list = await _appDb.Replies
                        .Include(i => i.ReplyLikes)
                        .ToListAsync();
        return list;
    }
}
