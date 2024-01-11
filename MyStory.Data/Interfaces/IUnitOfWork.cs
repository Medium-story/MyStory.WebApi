namespace MyStory.Data.Interfaces;

public interface IUnitOfWork
{
    public IArticleInterface Article { get; }
    public ICommentInterface Comment { get; }
    public IFollowInterface Follow { get; }
    public ILikeInterface Like { get; }
    public IReplyLikeInterface ReplyLike { get; }
    public IReactionInterface Reaction { get; }
    public IReplyInterface Reply { get; }
    public ITagInterface Tag { get; }

    Task SaveChangesAsync();
}
