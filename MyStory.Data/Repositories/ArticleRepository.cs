using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class ArticleRepository(AppDbContext appDb) : Repository<Article>(appDb), IArticleInterface
{
    private readonly AppDbContext _appDb = appDb;

    public async Task<ICollection<Article>> GetAllWithEntitiesAsync()
    {
        var list = await _appDb.Articles
                                   .Include(i => i.Users)
                                   .Include(i => i.Reactions)
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.CommentLikes)
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.Replies)
                                   .ThenInclude(i => i.ReplyLikes)
                                   .AsNoTracking()
                                   .ToListAsync();
        return list;
    }

    public async Task<Article> GetByIdWithEntitiesAsync(int id)
    {
        var article = await _appDb.Articles
                                   .Include(i => i.Users)
                                   .Include(i => i.Reactions)
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.CommentLikes)
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.Replies)
                                   .ThenInclude(i => i.ReplyLikes)
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(i => i.Id == id);

        return article ?? new Article();
    }

    public async Task<List<Article>> GetLatestArticlesAsync()
    {
        var articles = await _appDb.Articles
                                   .Include(i => i.Users)
                                   .Include(i => i.Reactions)
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.CommentLikes)
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.Replies)
                                   .ThenInclude(i => i.ReplyLikes)
                                   .OrderByDescending(i => i.CreatedAt)
                                   .AsNoTracking()
                                   .ToListAsync();

        return articles;
    }

    public async Task<List<Article>> GetToptArticlesAsync()
    {
        var articles = await _appDb.Articles
                                   .Include(i => i.Users)
                                   .Include(i => i.Reactions)
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.CommentLikes)
                                   .Include(i => i.Comments)
                                   .ThenInclude(i => i.Replies)
                                   .ThenInclude(i => i.ReplyLikes)
                                   .OrderByDescending(i => i.Comments.Count() + i.Reactions.Count())
                                   .AsNoTracking()
                                   .ToListAsync();

        return articles;
    }


}
