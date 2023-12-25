using MediumStory.Data.DataContext;
using MyStory.Data.Interfaces;

namespace MyStory.Data.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext _appDb;
    public UnitOfWork(AppDbContext appDb)
    {
        _appDb = appDb;
        Article = new ArticleRepository(appDb);
        Comment = new CommentRepository(appDb);
        Follow = new FollowRepository(appDb);
        Like = new LikeRepository(appDb);
        Reaction = new ReactionRepository(appDb);
        Reply = new ReplyRepository(appDb);
        Tag = new TagRepository(appDb);
    }

    public IArticleInterface Article { get; }
    public ICommentInterface Comment { get; }
    public IFollowInterface Follow { get; }
    public ILikeInterface Like { get; }
    public IReactionInterface Reaction { get; }
    public IReplyInterface Reply { get; }
    public ITagInterface Tag { get; }
    public void Dispose() => GC.SuppressFinalize(this);
    public async Task SaveChangesAsync()
    {
        await _appDb.SaveChangesAsync();
    }
}
