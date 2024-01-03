using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class ArticleRepository(AppDbContext appDb) : Repository<Article>(appDb), IArticleInterface
{
    private readonly AppDbContext _appDb = appDb;

    public async Task<ICollection<Article>> GetAllWithEntities()
    {
        var list = await _appDb.Articles
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.Replies)
                                   .ThenInclude(i => i.Likes)
                                   .ToListAsync();
        return list;
    }

    public async Task<Article> GetByIdWithEntities(int id)
    {
        var article = await _appDb.Articles
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.Replies)
                                   .ThenInclude(i => i.Likes)
                                   .FirstOrDefaultAsync(i => i.Id == id);

        return article ?? new Article();
    }
}
