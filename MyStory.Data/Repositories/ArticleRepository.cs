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
                                   .ToListAsync();
        return list;
    }
}
